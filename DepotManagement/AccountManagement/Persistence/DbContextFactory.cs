using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using AccountManagement.Persistence;

public class DbContextFactory : IDesignTimeDbContextFactory<AccountManagementDbContext> {
  public AccountManagementDbContext CreateDbContext(string[] args) {
    var optionsBuilder = new DbContextOptionsBuilder<AccountManagementDbContext>();
    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AccountManagementDbContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    return new AccountManagementDbContext(optionsBuilder.Options);
  }
}