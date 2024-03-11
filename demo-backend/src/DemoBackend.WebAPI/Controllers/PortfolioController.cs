using kPers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Security.AccessTokenHandling;
using System;
using System.Data.Fuse;
using UShellDemo;

namespace BFF {

  [ApiController]
  [ApiExplorerSettings(GroupName = "ApiV3")]
  [Route("BFF/Portfolio")]
  public class PortfolioController {

    private IRepository<CarEntity, string> _CarsApi;

    public PortfolioController(
      ILogger<PortfolioController> logger, IRepository<CarEntity, string> carsApi
    ) {
      _CarsApi = carsApi;
    }

    ////http://localhost:44351/BFF/portfolio/default.module.json
    [HttpGet("modules/{moduleId}.module.json")]
    [Produces("application/json")]
    public ModuleDescription GetModuleinfo(string moduleId) {
      var moduleConfig = new ModuleDescription();
      moduleConfig.ModuleTitle = "DemoModule";






      return moduleConfig;
    }

  }

}
