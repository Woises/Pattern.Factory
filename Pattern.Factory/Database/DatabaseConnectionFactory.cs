namespace Pattern.Factory.Database
{
    public enum DatabaseType
    {
        MongoDb
    }

    public static class DatabaseConnectionFactory
    {
        public static IDatabaseConnection Create(DatabaseType type, string connectionString)
        {
            return type switch
            {
                DatabaseType.MongoDb => new MongoDbConnection(connectionString),
                _ => throw new System.NotSupportedException($"Database type '{type}' is not supported."),
            };
        }
    }
}
