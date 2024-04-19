using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Model {

  [PrimaryIdentity("Id")]
  [UniquePropertyGroup("Id", nameof(Id))]
  public class Account {
    public int Id { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public int PersonId { get; set; }

    [Principal]
    public Person Person { get; set; } = null!;
    [Dependent]
    public ObservableCollection<CashTransaction> CashTransactions {
      get; set;
    } = new ObservableCollection<CashTransaction>();

    public override string ToString() {
      return AccountNumber;
    }
  }
}
