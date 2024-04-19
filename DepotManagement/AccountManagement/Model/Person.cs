using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Model {
  
  [PrimaryIdentity("Id")]
  [UniquePropertyGroup("Id", "Id")]  
  public class Person {

    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; } = DateTime.Now;
    public int NationalityId { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    [Dependent]
    public ObservableCollection<Address> Addresses { get; set; } = new ObservableCollection<Address>();

    [Lookup]
    public virtual Nation Nationality { get; set; } = null!;

    [Dependent]
    public ObservableCollection<Account> Accounts { get; set; } = new ObservableCollection<Account>();

    [Dependent]
    public ObservableCollection<InsuranceContract> InsuranceContracts { get; set; } = new ObservableCollection<InsuranceContract>();

    public override string ToString() {
      return $"{FirstName} {LastName}";
    }
  }
}
