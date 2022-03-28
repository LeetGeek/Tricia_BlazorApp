using MongoDB.Driver;

namespace BlazorApp_Tricia.Data
{
    public class MongoDbService
    {
        public int id { get; set; }

        MongoClient _client;
        public MongoDbService(IConfiguration config)
        {
            var item = config.GetSection("Info")["ConnectionString"];
            Console.WriteLine(item);//logger.LogInformation(item);
            var settings = MongoClientSettings.FromConnectionString(item);
            _client = new MongoClient(settings);
        }

        public async Task<IEnumerable<string>> GetDatabaseList()
        {
            var names = _client.ListDatabases().ToList().Select(o=>o.ToString()).ToList();
            return names;
        }
    }
}
