using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Model {

  [PrimaryIdentity("Id")]
  [UniquePropertyGroup("Id", nameof(Id))]
  public class InsurancePolicy {
    public int Id { get; set; }
    public decimal Premium { get; set; }

    public Guid InsuranceContractId { get; set; }

    [Principal]
    public InsuranceContract InsuranceContract { get; set; } = null!;
  }
}