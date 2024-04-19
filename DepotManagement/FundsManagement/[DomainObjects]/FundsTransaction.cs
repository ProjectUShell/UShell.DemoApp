using System.ComponentModel.DataAnnotations;
using System.Data.Fuse;

namespace FundsManagement {

  [HasLookup(nameof(Fund), nameof(FundId), "", null, nameof(Fund))]
  [PrimaryIdentity("Id")]
  [UniquePropertyGroup("Id", nameof(Id))]
  [HasPrincipal(nameof(Depot), nameof(DepotId), nameof(FundsManagement.Depot.FundsTransactions), null, nameof(Depot))]
  public class FundsTransaction {
    public int Id { get; set; }
    public int DepotId { get; set; }
    public Depot Depot { get; set; } = null!;
    public int? FundId { get; set; } = null;
    public EntityRef? Fund { get; set; } = null;
    public decimal Cash { get; set; }
    public decimal Shares { get; set; }
    public int Kind { get; set; }
  }
}
