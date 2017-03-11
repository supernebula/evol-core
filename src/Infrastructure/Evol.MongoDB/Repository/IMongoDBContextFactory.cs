
namespace Evol.MongoDB.Repository
{
    public interface IMongoDbContextFactory
    {
        NamedMongoDbContext Get<TDbContext>() where TDbContext : NamedMongoDbContext, new();
    }
}
