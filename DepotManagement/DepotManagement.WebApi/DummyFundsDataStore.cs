using System.Data.Fuse;
using System.Data.Fuse.Convenience;
using System.Data.ModelDescription;

namespace DepotManagement.WebApi {
  public class DummyFundsDataStore {
    private readonly RepositoryCollection repoCollection;

    public DummyFundsDataStore(RepositoryCollection repoCollection) {
      this.repoCollection = repoCollection;
    }

    public SchemaRoot GetSchemaRoot() {
      return repoCollection.GetSchemaRoot();
    }
  }
}
