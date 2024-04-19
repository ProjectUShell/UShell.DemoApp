using DepotManagement.PortfolioHandling;
using FundsManagement.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Data.Fuse.Convenience;
using System.Data.ModelDescription;

namespace DepotManagement.WebApi.Controllers {
  public class FundsManagementController : ControllerBase {
    private readonly ILogger<FundsManagementController> _Logger;
    private readonly RepositoryCollection _RepositoryCollection;

    public FundsManagementController(ILogger<FundsManagementController> logger, RepositoryCollection repositoryCollection) {
      _Logger = logger;
      this._RepositoryCollection = repositoryCollection;
    }

    [HttpPost()]
    [Route("FundsManagement/GetSchemaRoot")]
    public ActionResult<SchemaRoot> GetSchemaRoot() {
      try {
        return Ok(new { @return = this._RepositoryCollection.GetSchemaRoot() });
      } catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return null;
      }
    }
  }
}
