using System;
using System.Data.AccessControl;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace UShellDemo {

  partial class UShellDemoDbContext {

    static UShellDemoDbContext() {
      //EntityAccessControl.RegisterPropertyAsAccessControlClassification(
      //  (TenantEntity e) => e.Uid, "Tenant"
      //);
    }

    partial void OnModelCreatingCustom(ModelBuilder modelBuilder) {
    }

  }

  public static class AccessControlContextExtensions {

    //public static bool ValidateEntityScope<TEntity>(this AccessControlContext context, TEntity entity) {
    //  var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<TEntity>(context);
    //  if (!filterExpression.Compile().Invoke(entity)) {
    //    return false;
    //  }
    //  return true;
    //}

  }

}
