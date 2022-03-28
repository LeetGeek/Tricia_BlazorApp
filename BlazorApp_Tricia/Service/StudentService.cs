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

        public StudentService()
        {
            
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

            var student = new Student();
            student.StudentId = id.ToString();
            collection.InsertOne(student);
            
            targetStudent = student;
        }
    }
}
