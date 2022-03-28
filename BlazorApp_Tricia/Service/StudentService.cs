using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp_Tricia.Service
{
    public class StudentService
    {
        private string connectionString;
        MongoClient _client;

        private Student targetStudent;
        private readonly WebsiteService websiteService;

        public StudentService(WebsiteService websiteService)
        {
            this.websiteService = websiteService;
        }



        public void Init(string connectionString)
        {
            this.connectionString = connectionString;
            var settings = MongoClientSettings.FromConnectionString(connectionString);
            _client = new MongoClient(settings);
        }

        public Student GetTargetStudent()
        {
            return targetStudent;
        }


        public void LoadTargetStudent(string id)
        {
            var db = _client.GetDatabase("TriciaMain");
            var collection = db.GetCollection<Student>("Students");

            var student = (from s in collection.AsQueryable()
                           where s.StudentId == id.ToString()
                           select s).FirstOrDefault();

            targetStudent = student;
        }

        public void CreateStudent(string id)
        {
            var db = _client.GetDatabase("TriciaMain");
            var collection = db.GetCollection<Student>("Students");

            var websiteData = websiteService.GetWebsiteData();
            websiteData.NextDirection++;
            if (websiteData.NextDirection > 2) websiteData.NextDirection = 0;

            switch (websiteData.NextDirection)
            {
                case 0: websiteData.Direction0++;break;
                case 1: websiteData.Direction1++;break;
                case 2: websiteData.Direction2++;break;
            }
            websiteService.UpdateWebsiteData(websiteData);

            var student = new Student();
            student.Directions = websiteData.NextDirection;
            student.StudentId = id.ToString();
            collection.InsertOne(student);

            student.Answers = new Dictionary<string, object>();

            targetStudent = student;
        }

        public void SaveStudent(Student student)
        {
            var db = _client.GetDatabase("TriciaMain");
            var collection = db.GetCollection<Student>("Students");

            collection.ReplaceOne(s => s.StudentId == student.StudentId, student);
        }
    }
}
