using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Model {
  [PrimaryIdentity("Id")]
  [UniquePropertyGroup("Id", nameof(Id))]
  public class InsuranceContract {

    public InsuranceContract() {
      Id = Guid.NewGuid();
    }

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }
    public string ContractName { get; set; } = string.Empty;
    public int PersonId { get; set; }

    [Principal]
    public Person Person { get; set; } = null!;

    [Dependent]
    public ObservableCollection<InsurancePolicy> InsurancePolicies {
      get; set;
    } = new ObservableCollection<InsurancePolicy>();

  }
}
