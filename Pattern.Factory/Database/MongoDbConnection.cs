using MongoDB.Driver;

namespace Pattern.Factory.Database;

public class MongoDbConnection : IDatabaseConnection
{
    private readonly string _connectionString;
    private IMongoClient? _client;

    public MongoDbConnection(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IMongoClient Client => _client ?? throw new InvalidOperationException("Client not initialized. Call Connect() first.");

    public void Connect()
    {
        // Lazy initialize the Mongo client. The MongoClient is safe to reuse.
        _client ??= new MongoClient(_connectionString);
    }

    public IMongoDatabase GetDatabase(string databaseName)
    {
        if (_client == null)
        {
            Connect();
        }

        return _client!.GetDatabase(databaseName);
    }
}
