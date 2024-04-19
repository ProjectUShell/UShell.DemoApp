using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Model {

  [PrimaryIdentity("Id")]
  [UniquePropertyGroup("Id", "Id")]
  public class CashTransaction {
        
    public int Id { get; set; }
    public int AccountId { get; set; }
    [Principal]
    public virtual Account Account { get; set; } = null!;
    public decimal Amount { get; set; }
    public TransactionKind Kind { get; set; }
    public string ReferrerIban { get; set; } = string.Empty;
    public string ReferrerBic { get; set; } = string.Empty;
    public string ReferrerName { get; set; } = string.Empty;

  }
}
