using DepotManagement.PortfolioHandling;
using Microsoft.AspNetCore.Mvc;
using UShell;

namespace DepotManagement.WebApi.Controllers {

  [ApiController]
  public class PortfolioController : ControllerBase {

    private readonly ILogger<PortfolioController> _Logger;

    public PortfolioController(ILogger<PortfolioController> logger) {
      _Logger = logger;
    }

    [HttpGet()]
    [Route("Portfolio/{portfolioName}.json")]
    public ActionResult<PortfolioDescription> GetPortfolio([FromRoute] string portfolioName) {
      try {
       PortfolioDescription defaultPortfolio = PortfolioService.GetPortfolioDescription(portfolioName);
        return Ok(defaultPortfolio);
      } catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return null;
      }
    }

    [HttpGet()]
    [Route("Module/{moduleName}.json")]
    public ActionResult<ModuleDescription> GetModule([FromRoute] string moduleName) {
      try {
        return PortfolioService.GetModuleDescription(moduleName);
      } catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return null;
      }
    }

    [HttpGet()]
    [Route("Portfolio/PortfolioIndex.json")]
    public ActionResult<List<PortfolioEntry>> PortfolioIndex() {
      try {
        List<PortfolioEntry> list = new List<PortfolioEntry>();
        PortfolioEntry depotManager = new PortfolioEntry() {
          Label = "Depot Manager",
          PortfolioUrl = "DepotManager",
        };
        depotManager.Tags.Add("Category", "FUSE-FX");
        depotManager.Tags.Add("Product", "Depot Manager");
        list.Add(depotManager);
        return Ok(list);
      } catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return null;
      }
    }

  }
}