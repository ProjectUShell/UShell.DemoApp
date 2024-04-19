using System.ComponentModel.DataAnnotations;

namespace FundsManagement {

  [HasLookup(nameof(Fund),nameof(FundId))]
  public class FundsTransactionEntity {
    public int Id { get; set; }
    public int DepotId { get; set; }
    [Principal]
    public DepotEntity Depot { get; set; } = null!;
    public int FundId { get; set; }
    [Lookup]
    public FundEntity Fund { get; set; } = null!;
    public decimal Cash { get; set; }
    public decimal Shares { get; set; }
    public FundsTransactionKind Kind { get; set; }
  }
}
