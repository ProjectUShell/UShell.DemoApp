using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using System.IO;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Writers;
using Security.AccessTokenHandling;
using Security.AccessTokenHandling.CommonVendors;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Security.AccessTokenHandling.OAuthServer;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Web.UJMW;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using UShellDemo;
using System.Data.AccessControl;
using Microsoft.AspNetCore;
using DistributedDataFlow;
using System.Data.Fuse;

namespace Security {

  public class Startup {

    public Startup(IConfiguration configuration) {
      _Configuration = configuration;
      UShellDemoDbContext.ConnectionString = configuration.GetValue<String>("SqlConnectionString");
    }

    private static IConfiguration _Configuration = null;
    public static IConfiguration Configuration { get { return _Configuration; } }

    const string _ApiTitle = "Demo Backend";
    Version _ApiVersion = null;

    public void ConfigureServices(IServiceCollection services) {

      services.AddLogging();

      _ApiVersion = typeof(CarsService).Assembly.GetName().Version;

      UShellDemoDbContext.Migrate();

      string outDir = AppDomain.CurrentDomain.BaseDirectory;

      var carsService = new CarsService(
      );

      services.AddSingleton<IRepository<CarEntity,string>>(carsService);

      services.AddCors(opt => {
        opt.AddPolicy(
          "MyCustomCorsPolicy",
          c => c
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            //.DisallowCredentials()
        );
      });

      services.AddControllers();

      ////////////////////////////////////////////////////////////////////////////////////////////
      // HERE COMES THE MAGIC OF SMART-STANDRADS                                                //
      ////////////////////////////////////////////////////////////////////////////////////////////
      
      //A: we want a DYNAMIC CONTROLLER instead of programming one manually
      services.AddDynamicUjmwControllers(r => {

        r.AddControllerFor<IRepository<CarEntity, String>>(new DynamicUjmwControllerOptions {
          ControllerRoute = "{0}",
          ControllerTitle = "{0}-Repo",
          ClassNameDiscriminator = "{0}",
          EnableRequestSidechannel = true, //generate an "_" property to support this way in general
          //all functions within the dynamic controller should have a EvaluateBearerTokenAttribute
          AuthAttribute = typeof(EvaluateBearerTokenAttribute),
          AuthAttributeConstructorParams = EvaluateBearerTokenAttribute.BuildConstructorParams("CarManagement") //< require this scope
        }); ;

      });

      //B: as authorization, we want to use google tokens, to validate them we can use
      //the introspector from the AuthTokenHandling library: 
      IAccessTokenIntrospector googleTokenAti = new GoogleTokenIntrospector(
        "googleapikey",
        //google has no tenant-management, so were asuming every subject to be a tenant:
        //this method will inject new scopes instead of picking it from the claims... 
        (claims) => new string[] { "API:CarManagement", "Tenant:" + claims["sub"] }
      );
      //the 'AccessTokenValidator' will be used automatically, because we have placed
      //the 'EvaluateBearerTokenAttribute' over the methods within our controllers...
      AccessTokenValidator.ConfigureTokenValidation(
        googleTokenAti, // 1. -> use the GOOGLE introspector to validate the tokens
        (cfg) => {
          // 2. pass the evaluated information to the (AMBIENT-)StateManager
          cfg.UseScopeVisitor(StateManager.ApplyCurrentAuthTokenInformation);
        }    
      );

      //C: also pass information from incomming request-sidechannel into the AmbienceHub,
      //which will automatically inject the values into the AmbientFiels (used inside of the StateManager)
      UjmwHostConfiguration.ConfigureRequestSidechannel((contractType, cfg) => {
        cfg.ProcessDataVia(AmbienceHub.RestoreValuesFrom);
        cfg.AcceptUjmwUnderlineProperty();
        cfg.AcceptNoChannelProvided(
          (ref IDictionary<string, string> defaultsToUse) => {
            defaultsToUse["Tenant"] = "DefaultTenant";
          }
        );
      });

      //D: couple the current access scopes with the persistence layer to filter the tenant
      EntityAccessControl.ClearanceGetter = StateManager.GetCurrentScopes;
      EntityAccessControl.RegisterPropertyAsAccessControlClassification(
        (TenantEntity e) => e.Uid, "Tenant"
      );

      ////////////////////////////////////////////////////////////////////////////////////////////

      services.AddSwaggerGen(c => {

        c.ResolveConflictingActions(apiDescriptions => {
          return apiDescriptions.First();
        });
        c.EnableAnnotations(true, true);

        //c.IncludeXmlComments(outDir + ".......Contract.xml", true);
        //c.IncludeXmlComments(outDir + "........Service.xml", true);
        //c.IncludeXmlComments(outDir + "........WebAPI.xml", true);

        #region bearer

        //string getLinkMd = "";
        //if (!string.IsNullOrWhiteSpace(masterApiClientSecret)) {
        //  getLinkMd = " [get one...](../oauth?state=myState&client_id=master&login_hint=API-CLIENT&redirect_uri=/oauth/display)";
        //}

        //https://www.thecodebuzz.com/jwt-authorization-token-swagger-open-api-asp-net-core-3-0/
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
          Name = "Authorization",
          Type = SecuritySchemeType.ApiKey,
          Scheme = "Bearer",
          BearerFormat = "JWT",
          In = ParameterLocation.Header,
          Description = "API-TOKEN" //+ getLinkMd
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
          {
              {
                    new OpenApiSecurityScheme
                      {
                          Reference = new OpenApiReference
                          {
                              Type = ReferenceType.SecurityScheme,
                              Id = "Bearer"
                          }
                      },
                      new string[] {}

              }
          });

        #endregion

        c.UseInlineDefinitionsForEnums();

        c.SwaggerDoc(
          "ApiV3",
          new OpenApiInfo {
            Title = _ApiTitle + " - API",
            Version = _ApiVersion.ToString(3),
            Description = "NOTE: This is not intended be a 'RESTful' api, as it is NOT located on the persistence layer and is therefore NOT focused on doing CRUD operations! This HTTP-based API uses a 'call-based' approach to known BL operations. IN-, OUT- and return-arguments are transmitted using request-/response- wrappers (see [UJMW](https://github.com/SmartStandards/UnifiedJsonMessageWrapper)), which are very lightweight and are a compromise for broad support and adaptability in REST-inspired technologies as well as soap-inspired technologies!",
            Contact = new OpenApiContact {
              Name = "???",
              Email = "??.com",
              Url = new Uri("https://www.???.com")
            },
          }
        );

      });

    }
    
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerfactory) {

      var logFileFullName = _Configuration.GetValue<string>("LogFileName");
      var logDir = Path.GetFullPath(Path.GetDirectoryName(logFileFullName));
      Directory.CreateDirectory(logDir);
      loggerfactory.AddFile(logFileFullName);

      //required for the www-root
      app.UseStaticFiles();

      if (!_Configuration.GetValue<bool>("ProdMode")) {
        app.UseDeveloperExceptionPage();
      }

      //THIS CONFIGURES THE RUNTIME FOR AMBIENT-FIELDS!
      //The StateManager will use them, so this is necessary
      app.UseAmbientFieldAdapterMiddleware();

      if (_Configuration.GetValue<bool>("EnableSwaggerUi")) {
        var baseUrl = _Configuration.GetValue<string>("BaseUrl");

        app.UseSwagger(o => {
          //warning: needs subfolder! jsons cant be within same dir as swaggerui (below)
          o.RouteTemplate = "docs/schema/{documentName}.{json|yaml}";
          //o.SerializeAsV2 = true;
        });

        app.UseSwaggerUI(c => {

          c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
          c.DefaultModelExpandDepth(2);
          c.DefaultModelsExpandDepth(2);
          //c.ConfigObject.DefaultModelExpandDepth = 2;

          c.DocumentTitle = _ApiTitle + " - OpenAPI Definition(s)";

          //represents the sorting in SwaggerUI combo-box
          c.SwaggerEndpoint("schema/ApiV3.json", _ApiTitle + " - API v" + _ApiVersion.ToString(3));

          c.RoutePrefix = "docs";

          //requires MVC app.UseStaticFiles();
          c.InjectStylesheet(baseUrl + "swagger-ui/custom.css");

        });

      }

      app.UseHttpsRedirection();

      app.UseRouting();

      //CORS: muss zwischen 'UseRouting' und 'UseEndpoints' liegen!
      app.UseCors(p =>
          p.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader()
      );

      app.UseAuthentication(); //<< WINDOWS-AUTH
      app.UseAuthorization();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
       });

    }

  }

}
