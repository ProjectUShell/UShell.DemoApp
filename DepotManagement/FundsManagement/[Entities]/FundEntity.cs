namespace FundsManagement {
  public class FundEntity {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Isin { get; set; } = string.Empty;
    public override string ToString() {
      return this.Name;
    }
  }
}