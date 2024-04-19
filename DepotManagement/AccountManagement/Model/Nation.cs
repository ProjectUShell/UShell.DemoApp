using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Model {

  [PrimaryIdentity("Id")]
  [UniquePropertyGroup("Id", "Id")]
  public class Nation {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public override string ToString() {
      return this.Name;
    }
  }
}