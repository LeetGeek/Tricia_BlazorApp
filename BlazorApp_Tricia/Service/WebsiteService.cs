using MongoDB.Bson;
using MongoDB.Driver;

namespace BlazorApp_Tricia.Service
{
   
    public class WebsiteService
    {
        private string connectionString;
        MongoClient _client;


        public void Init(string connectionString)
        {
            this.connectionString = connectionString;
            var settings = MongoClientSettings.FromConnectionString(connectionString);
            _client = new MongoClient(settings);
        }


        public WebsiteData GetWebsiteData()
        {
            var db = _client.GetDatabase("TriciaMain");
            var collection = db.GetCollection<WebsiteData>("Main");

            var websiteData = (from s in collection.AsQueryable()
                           where s.DataId == "1"
                           select s).FirstOrDefault();

            if (websiteData != null)
                return websiteData;

            websiteData = new WebsiteData();
            websiteData.DataId = "1";
            websiteData.Direction0 = 0;
            websiteData.Direction1 = 0;
            websiteData.Direction2 = 0;

            collection.InsertOne(websiteData);
            return websiteData;
        }

        public void UpdateWebsiteData(WebsiteData data)
        {
            var db = _client.GetDatabase("TriciaMain");
            var collection = db.GetCollection<WebsiteData>("Main");
            
            collection.ReplaceOne(doc => doc.DataId == "1", data);
        }
    }

    public class WebsiteData : BaseElement
    {
        public string DataId { get; set; }
        public int Direction0 { get; set; }
        public int Direction1 { get; set; }
        public int Direction2 { get; set; }
        public int NextDirection { get; set; }

        public string ReadingPaneTotalTime { get; set; }
        public string ParagraphTotalTime { get; set; }
    }
}
