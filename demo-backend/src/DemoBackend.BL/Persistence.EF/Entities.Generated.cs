using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace UShellDemo {

public class CarEntity {

  [Required]
  public String LicPlateId { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Int64> ParkingLocationUid { get; set; }

  [Required]
  public String Model { get; set; }

  [Required]
  public String Color { get; set; }

  [Required]
  public Int64 TenantUid { get; set; }

  [Dependent]
  public virtual ObservableCollection<DriverEntity> Drivers { get; set; } = new ObservableCollection<DriverEntity>();

  [Lookup]
  public virtual ParkingLocationEntity ParkingLocation { get; set; }

  [Lookup]
  public virtual TenantEntity Tenant { get; set; }

}

public class DriverEntity {

  [Required]
  public String CarLicPlateId { get; set; }

  [Required]
  public Int64 PersonUid { get; set; }

  [Required]
  public Boolean OwnsCarKeys { get; set; }

  [Principal]
  public virtual CarEntity Car { get; set; }

  [Lookup]
  public virtual PersonEntity Person { get; set; }

}

public class ParkingLocationEntity {

  [Required]
  public Int64 Uid { get; set; }

  [Required]
  public String Address { get; set; }

  [Required]
  public Int64 TenantUid { get; set; }

  [Lookup]
  public virtual TenantEntity Tenant { get; set; }

}

public class TenantEntity {

  [Required]
  public Int64 Uid { get; set; }

}

public class PersonEntity {

  [Required]
  public Int64 Uid { get; set; }

  [Required]
  public String FirstName { get; set; }

  [Required]
  public String LastName { get; set; }

  [Required]
  public Int64 TenantUid { get; set; }

  [Lookup]
  public virtual TenantEntity Tenant { get; set; }

}

}
