using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace FundsManagement {

  [HasDependent(
    nameof(FundsTransactions), 
    nameof(FundsTransactionEntity.DepotId), 
    nameof(FundsTransactionEntity.Depot)
  )]
  [HasPrincipal(
    "",
    nameof(PersonId),
    "",null, 
    "Person"
  )]
  public class DepotEntity {
    public int Id { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public string DepotNumber { get; set; } = string.Empty;

    public int PersonId { get; set; }

    [Dependent]
    public ObservableCollection<FundsTransactionEntity> FundsTransactions {
      get; set;
    } = new ObservableCollection<FundsTransactionEntity>();
  }
}
