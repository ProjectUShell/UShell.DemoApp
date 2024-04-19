using Microsoft.EntityFrameworkCore;

namespace FundsManagement.Persistence {
  public class FundsManagementDbContext : DbContext {

    public DbSet<DepotEntity> Depots { get; set; }
    public DbSet<FundEntity> Funds { get; set; }
    public DbSet<FundsTransactionEntity> FundsTransactions { get; set; }

    public FundsManagementDbContext(DbContextOptions<FundsManagementDbContext> options) : base(options) {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      base.OnConfiguring(optionsBuilder);      
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);
      modelBuilder.HasDefaultSchema("fds");

      modelBuilder.Entity<FundsTransactionEntity>()
        .HasOne((p) => p.Fund)
        .WithMany().OnDelete(DeleteBehavior.Restrict);

    }
  }
}
