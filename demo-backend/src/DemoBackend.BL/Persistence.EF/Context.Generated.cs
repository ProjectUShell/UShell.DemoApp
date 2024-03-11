using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UShellDemo {

  /// <summary> EntityFramework DbContext (based on schema version '1.0.0') </summary>
  public partial class UShellDemoDbContext : DbContext{

    public const String SchemaVersion = "1.0.0";

    public DbSet<CarEntity> Cars { get; set; }

    public DbSet<DriverEntity> Drivers { get; set; }

    public DbSet<ParkingLocationEntity> ParkingLocations { get; set; }

    public DbSet<TenantEntity> Tenants { get; set; }

    public DbSet<PersonEntity> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);

#region Mapping

      modelBuilder.HasDefaultSchema("UD");

      //////////////////////////////////////////////////////////////////////////////////////
      // Car
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgCar = modelBuilder.Entity<CarEntity>();
      cfgCar.ToTable("Cars");
      cfgCar.HasKey((e) => e.LicPlateId);
      cfgCar.Property((e) => e.LicPlateId).ValueGeneratedNever().HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);

      // LOOKUP: >>> ParkingLocation
      cfgCar
        .HasOne((lcl) => lcl.ParkingLocation )
        .WithMany()
        .HasForeignKey(nameof(CarEntity.ParkingLocationUid))
        .OnDelete(DeleteBehavior.Restrict);

      // LOOKUP: >>> Tenant
      cfgCar
        .HasOne((lcl) => lcl.Tenant )
        .WithMany()
        .HasForeignKey(nameof(CarEntity.TenantUid))
        .OnDelete(DeleteBehavior.Restrict);

      //////////////////////////////////////////////////////////////////////////////////////
      // Driver
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgDriver = modelBuilder.Entity<DriverEntity>();
      cfgDriver.ToTable("Drivers");
      cfgDriver.HasKey((e) => new {e.CarLicPlateId, e.PersonUid});
      cfgDriver.Property((e) => e.CarLicPlateId).ValueGeneratedNever().HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);
      cfgDriver.Property((e) => e.PersonUid).ValueGeneratedNever().HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);

      // PRINCIPAL: >>> Car
      cfgDriver
        .HasOne((lcl) => lcl.Car )
        .WithMany((rem) => rem.Drivers )
        .HasForeignKey(nameof(DriverEntity.CarLicPlateId))
        .OnDelete(DeleteBehavior.Cascade);

      // LOOKUP: >>> Person
      cfgDriver
        .HasOne((lcl) => lcl.Person )
        .WithMany()
        .HasForeignKey(nameof(DriverEntity.PersonUid))
        .OnDelete(DeleteBehavior.Restrict);

      //////////////////////////////////////////////////////////////////////////////////////
      // ParkingLocation
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgParkingLocation = modelBuilder.Entity<ParkingLocationEntity>();
      cfgParkingLocation.ToTable("ParkingLocations");
      cfgParkingLocation.HasKey((e) => e.Uid);
      cfgParkingLocation.Property((e) => e.Uid).ValueGeneratedNever().HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);

      // LOOKUP: >>> Tenant
      cfgParkingLocation
        .HasOne((lcl) => lcl.Tenant )
        .WithMany()
        .HasForeignKey(nameof(ParkingLocationEntity.TenantUid))
        .OnDelete(DeleteBehavior.Restrict);

      //////////////////////////////////////////////////////////////////////////////////////
      // Tenant
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgTenant = modelBuilder.Entity<TenantEntity>();
      cfgTenant.ToTable("Tenants");
      cfgTenant.HasKey((e) => e.Uid);
      cfgTenant.Property((e) => e.Uid).ValueGeneratedNever().HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);

      //////////////////////////////////////////////////////////////////////////////////////
      // Person
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgPerson = modelBuilder.Entity<PersonEntity>();
      cfgPerson.ToTable("Persons");
      cfgPerson.HasKey((e) => e.Uid);
      cfgPerson.Property((e) => e.Uid).ValueGeneratedNever().HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);

      // LOOKUP: >>> Tenant
      cfgPerson
        .HasOne((lcl) => lcl.Tenant )
        .WithMany()
        .HasForeignKey(nameof(PersonEntity.TenantUid))
        .OnDelete(DeleteBehavior.Restrict);

#endregion

      this.OnModelCreatingCustom(modelBuilder);
    }

    partial void OnModelCreatingCustom(ModelBuilder modelBuilder);

    protected override void OnConfiguring(DbContextOptionsBuilder options) {

      //reqires separate nuget-package Microsoft.EntityFrameworkCore.SqlServer
      options.UseSqlServer(_ConnectionString);

      //reqires separate nuget-package Microsoft.EntityFrameworkCore.Proxies
      options.UseLazyLoadingProxies();

      this.OnConfiguringCustom(options);
    }

    partial void OnConfiguringCustom(DbContextOptionsBuilder options);

    public static void Migrate() {
      if (!_Migrated) {
        UShellDemoDbContext c = new UShellDemoDbContext();
        c.Database.Migrate();
        _Migrated = true;
        c.Dispose();
      }
    }

   private static bool _Migrated = false;

    private static String _ConnectionString = "Server=(localdb)\\MsSqlLocalDb;Database=UShellDemoDbContext;Integrated Security=True;Persist Security Info=True;MultipleActiveResultSets=True;";
    public static String ConnectionString {
      set{ _ConnectionString = value;  }
    }

  }

}
