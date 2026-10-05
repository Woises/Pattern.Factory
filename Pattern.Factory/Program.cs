using Pattern.Factory.Database;

namespace Pattern.Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Example usage of the Factory pattern to create a MongoDB connection
            var connectionString = Environment.GetEnvironmentVariable("MONGODB_CONN") ?? "mongodb://localhost:27017";
            var databaseName = "testdb";

            var connection = DatabaseConnectionFactory.Create(DatabaseType.MongoDb, connectionString);
            connection.Connect();
            var db = connection.GetDatabase(databaseName);

            Console.WriteLine($"Connected to database: {db.DatabaseNamespace.DatabaseName}");
        }
    }
}
