using AccountManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Persistence {

  public class AccountManagementDbContext : DbContext {
    public DbSet<Person> Persons { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<CashTransaction> CashTransactions { get; set; }
    public DbSet<Nation> Nations { get; set; }
    public DbSet<Address> Addresses { get; set; }

    public AccountManagementDbContext(DbContextOptions<AccountManagementDbContext> options) : base(options) {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Person>()
        .HasOne((p) => p.Nationality)
        .WithMany().OnDelete(DeleteBehavior.Restrict);      
      
    }
  }

}
