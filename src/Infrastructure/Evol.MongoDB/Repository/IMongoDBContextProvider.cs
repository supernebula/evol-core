
namespace Evol.MongoDB.Repository
{
    public interface IMongoDbContextProvider
    {
        NamedMongoDbContext Get<TDbContext>() where TDbContext : NamedMongoDbContext, new();
    }
}
