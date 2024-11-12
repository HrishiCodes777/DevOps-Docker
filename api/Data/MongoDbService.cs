using MongoDB.Driver;

namespace API.Data{
    public class MongoDbService{
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase _database;

        public MongoDbService(IConfiguration configuration){
            _configuration = configuration;

            var connectionString = _configuration.GetConnectionString("DbConnection");
            Console.WriteLine($"Connecting to MongoDB: {connectionString}");
            var mongoUrl = MongoUrl.Create(connectionString);
            Console.WriteLine($"Database: {mongoUrl.DatabaseName}");
            var mongoClient = new MongoClient(mongoUrl);
            Console.WriteLine($"Connected successfully!");
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
            Console.WriteLine($"Database {mongoUrl.DatabaseName} created.");
        }

        public IMongoDatabase? Database => _database;
    }
}