using AccountManagement.Model;
using AccountManagement.Persistence;
using DepotManagement.WebApi;
using FundsManagement;
using FundsManagement.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Data.Fuse;
using System.Data.Fuse.Convenience;
using System.Data.Fuse.Ef;
using System.Web.UJMW;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(
  (options) => options.AddPolicy(
    "CorsAll",
    (builder) => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
  )
);

builder.Services.AddDbContext<AccountManagementDbContext>(
  options => options.UseSqlServer(
    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DepotManagementDev;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
  )
);
builder.Services.AddDbContext<FundsManagementDbContext>(
  options => options.UseSqlServer(
    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DepotManagementDev;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
  )
);

// AccountManagement: UniversalRepository

builder.Services.AddScoped<EfDictUniversalRepository>((s) => { 
  return new EfDictUniversalRepository(
    s.GetService<AccountManagementDbContext>(),
    typeof(Person).Assembly
  );
});

builder.Services.AddScoped<IRepository<Person, int>>((s) => {
  return new EfRepository<Person, int>(s.GetService<AccountManagementDbContext>());
});

// FundsManagement: MoodelVsEntityRepositories

builder.Services.AddScoped<IEfDataStore<FundsManagementDbContext>>((s) => {
  return new EfDataStore<FundsManagementDbContext>(s.GetService<FundsManagementDbContext>()!, typeof(Fund).Assembly);
});

builder.Services.AddScoped<RepositoryCollection>((s) => {
  RepositoryCollection? dataStore = new RepositoryCollection();
  dataStore.RegisterRepository(
    ConversionHelper.CreateModelVsEntityRepositry<Depot, DepotEntity, int>(
      s.GetService<IEfDataStore<FundsManagementDbContext>>(), dataStore
    )
  );
  dataStore.RegisterRepository(
    ConversionHelper.CreateModelVsEntityRepositry<FundsTransaction, FundsTransactionEntity, int>(
      s.GetService<IEfDataStore<FundsManagementDbContext>>(), dataStore
    )
  );
  dataStore.RegisterRepository(
    ConversionHelper.CreateModelVsEntityRepositry<Fund, FundEntity, int>(
      s.GetService<IEfDataStore<FundsManagementDbContext>>(), dataStore
    )
  );
  return dataStore;
});

builder.Services.AddScoped<DummyFundsDataStore>((s) => {
  RepositoryCollection? dataStore = s.GetService<RepositoryCollection>();
  if (dataStore == null) {
    throw new Exception("IFundsManagementDataStore is null");
  }
  return new DummyFundsDataStore(dataStore);
});

builder.Services.AddScoped<IRepository<Fund, int>>((s) => {
  RepositoryCollection? dataStore = s.GetService<RepositoryCollection>();
  if (dataStore == null) {
    throw new Exception("IFundsManagementDataStore is null");
  } 
  return dataStore.GetRepository<Fund,int>();
});

builder.Services.AddScoped<IRepository<Depot, int>>((s) => {
  RepositoryCollection? dataStore = s.GetService<RepositoryCollection>();
  if (dataStore == null) {
    throw new Exception("IFundsManagementDataStore is null");
  }
  return dataStore.GetRepository<Depot, int>();
});

builder.Services.AddScoped<IRepository<FundsTransaction, int>>((s) => {
  RepositoryCollection? dataStore = s.GetService<RepositoryCollection>();
  if (dataStore == null) {
    throw new Exception("IFundsManagementDataStore is null");
  }
  return dataStore.GetRepository<FundsTransaction, int>();
});

DynamicUjmwControllerOptions controllerOptions = new DynamicUjmwControllerOptions() {
  ControllerRoute = "Depot",
  EnableRequestSidechannel = false,
  EnableResponseSidechannel = false
};
builder.Services.AddDynamicUjmwControllers(r => {
  r.AddControllerFor<EfDictUniversalRepository>("AccountManagement");
  //r.AddControllerFor<DummyFundsDataStore>("FundsManagement"); //TODO_KRN: Naming Conflict of Response/Request objects???
  r.AddControllerFor<IRepository<Depot, int>>("FundsManagement/Depot");
  r.AddControllerFor<IRepository<Fund, int>>("FundsManagement/Fund");
  r.AddControllerFor<IRepository<FundsTransaction, int>>("FundsManagement/FundsTransaction");
  r.AddControllerFor<IRepository<Person, int>>("FundsManagement/Person");
});

var app = builder.Build();

app.UseCors("CorsAll");

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope()) {
  AccountManagementDbContext? context = serviceScope.ServiceProvider.GetService<AccountManagementDbContext>();
  if (context != null) {
    context.Database.Migrate();
  }
  FundsManagementDbContext? context2 = serviceScope.ServiceProvider.GetService<FundsManagementDbContext>();
  if (context2 != null) {
    context2.Database.Migrate();
  }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
