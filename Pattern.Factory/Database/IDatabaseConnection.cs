using MongoDB.Driver;

namespace Pattern.Factory.Database
{
    public interface IDatabaseConnection
    {
        IMongoClient Client { get; }
        void Connect();
        IMongoDatabase GetDatabase(string databaseName);
    }
}
