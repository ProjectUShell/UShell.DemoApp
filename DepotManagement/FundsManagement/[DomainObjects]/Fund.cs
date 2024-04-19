using System.ComponentModel.DataAnnotations;

namespace FundsManagement {
  [PrimaryIdentity("Id")]
  [UniquePropertyGroup("Id", nameof(Id))]
  public class Fund {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Isin { get; set; } = string.Empty;
    public override string ToString() {
      return this.Name;
    }
  }
}