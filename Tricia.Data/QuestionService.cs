using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tricia.Data
{
    public class QuestionService
    {
        private readonly string connectionString;
        MongoClient _client;
        public QuestionService(string connectionString)
        {
            this.connectionString = connectionString;
            var settings = MongoClientSettings.FromConnectionString(connectionString);
            _client = new MongoClient(settings);
        }

        public IEnumerable<Question> GetQuestions()
        {
            var db = _client.GetDatabase("TriciaMain");
            var collection = db.GetCollection<Question>("Questions");

            var questions = (from q in collection.AsQueryable()
                         select q).ToList();

            return questions;
        }
    }
}
