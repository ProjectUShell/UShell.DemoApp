using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Model {

  [PrimaryIdentity("Id")]
  [UniquePropertyGroup("Id", "Id")]
  public class Address {
    public int Id { get; set; }
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public int PersonId { get; set; }
    [Principal]
    public virtual Person Person { get; set; } = null!;

    public override string ToString() {
      return $"{Street} ({City})";
    }
  }
}
