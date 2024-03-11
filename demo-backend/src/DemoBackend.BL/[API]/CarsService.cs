using System;
using System.Collections.Generic;
using System.Data.Fuse;
using System.Linq;

namespace UShellDemo {

  public partial class CarsService : IRepository<CarEntity, string> {

    public CarEntity AddOrUpdateEntity(CarEntity entity) {
      throw new NotImplementedException();
    }

    public Dictionary<string, object> AddOrUpdateEntityFields(Dictionary<string, object> fields) {
      throw new NotImplementedException();
    }

    public bool ContainsKey(string key) {
      throw new NotImplementedException();
    }

    public int Count(ExpressionTree filter) {
      throw new NotImplementedException();
    }

    public int CountAll() {
      throw new NotImplementedException();
    }

    public int CountBySearchExpression(string searchExpression) {
      throw new NotImplementedException();
    }

    public RepositoryCapabilities GetCapabilities() {
      throw new NotImplementedException();
    }

    public CarEntity[] GetEntities(ExpressionTree filter, string[] sortedBy, int limit = 100, int skip = 0) {
      throw new NotImplementedException();
    }

    public CarEntity[] GetEntitiesByKey(string[] keysToLoad) {
      throw new NotImplementedException();
    }

    public CarEntity[] GetEntitiesBySearchExpression(string searchExpression, string[] sortedBy, int limit = 100, int skip = 0) {
      throw new NotImplementedException();
    }

    public Dictionary<string, object>[] GetEntityFields(ExpressionTree filter, string[] includedFieldNames, string[] sortedBy, int limit = 100, int skip = 0) {
      throw new NotImplementedException();
    }

    public Dictionary<string, object>[] GetEntityFieldsByKey(string[] keysToLoad, string[] includedFieldNames) {
      throw new NotImplementedException();
    }

    public Dictionary<string, object>[] GetEntityFieldsBySearchExpression(string searchExpression, string[] includedFieldNames, string[] sortedBy, int limit = 100, int skip = 0) {
      throw new NotImplementedException();
    }

    public EntityRef<string>[] GetEntityRefs(ExpressionTree filter, string[] sortedBy, int limit = 100, int skip = 0) {
      throw new NotImplementedException();
    }

    public EntityRef<string>[] GetEntityRefsByKey(string[] keysToLoad) {
      throw new NotImplementedException();
    }

    public EntityRef<string>[] GetEntityRefsBySearchExpression(string searchExpression, string[] sortedBy, int limit = 100, int skip = 0) {
      throw new NotImplementedException();
    }

    public string GetOriginIdentity() {
      throw new NotImplementedException();
    }

    public string[] Massupdate(string[] keysToUpdate, Dictionary<string, object> fields) {
      throw new NotImplementedException();
    }

    public string[] Massupdate(ExpressionTree filter, Dictionary<string, object> fields) {
      throw new NotImplementedException();
    }

    public string[] Massupdate(string searchExpression, Dictionary<string, object> fields) {
      throw new NotImplementedException();
    }

    public string TryAddEntity(CarEntity entity) {
      throw new NotImplementedException();
    }

    public string[] TryDeleteEntities(string[] keysToDelete) {
      throw new NotImplementedException();
    }

    public CarEntity TryUpdateEntity(CarEntity entity) {
      throw new NotImplementedException();
    }

    public Dictionary<string, object> TryUpdateEntityFields(Dictionary<string, object> fields) {
      throw new NotImplementedException();
    }

    public bool TryUpdateKey(string currentKey, string newKey) {
      throw new NotImplementedException();
    }
  }

}
