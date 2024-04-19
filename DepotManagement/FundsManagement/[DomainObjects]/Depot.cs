using System.ComponentModel.DataAnnotations;

namespace FundsManagement {

  [HasDependent(nameof(FundsTransactions), nameof(FundsTransaction.DepotId), nameof(FundsTransaction.Depot), null, nameof(FundsTransaction))]
  [HasPrincipal("", nameof(PersonId), "", null, "Person")]
  [PrimaryIdentity("Id")]
  [UniquePropertyGroup("Id", nameof(Id))]
  public class Depot {
    public int Id { get; set; }
    public int PersonId { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public string DepotNumber { get; set; } = string.Empty;
    public List<FundsTransaction> FundsTransactions { get; set; } = new List<FundsTransaction>();
  }
}
