using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using FundsManagement.Persistence;

public class DbContextFactory : IDesignTimeDbContextFactory<FundsManagementDbContext> {
  public FundsManagementDbContext CreateDbContext(string[] args) {
    var optionsBuilder = new DbContextOptionsBuilder<FundsManagementDbContext>();
    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FundsManagementDbContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    return new FundsManagementDbContext(optionsBuilder.Options);
  }
}