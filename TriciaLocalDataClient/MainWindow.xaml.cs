using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TriciaLocalDataClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MongoClient _client;


        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            byte[] bytes = Encoding.Default.GetBytes("mongodb+srv://user-tricia:Tricia234@triciacluster.latjd.mongodb.net");
            var connectionString = Encoding.UTF8.GetString(bytes);
           
            var settings = MongoClientSettings.FromConnectionString(connectionString);
            _client = new MongoClient(settings);




            
            // var database = client.GetDatabase("test");
            Console.WriteLine();
            

            //await database.CreateCollectionAsync("EmployeeRecord");
            //await database.GetCollection<BsonDocument>("EmployeeRecord").InsertOneAsync(doc);

           
           
            var dict = new Dictionary<string, object>();
            dict["employeeId"] = 10;
            //var doc = new BsonDocument(dict);
            //collection.InsertOne(doc);
            //var query = Query
            //collection.Find(Query)
            //var results = collection.FindAs
            //foreach (var item in results)
            //{
            //    Console.WriteLine(item.ToString());
            //}


            await ListDatabases();

            Console.WriteLine("done");
        }

        private async void ViewStudentsButton_Click(object sender, RoutedEventArgs e)
        {
            await PrintAllInCollection();
        }

        private async void DeleteStudentButton_Click(object sender, RoutedEventArgs e)
        {
            await DeleteItem();
        }

        private async void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            await AddStudent();
        }





























        public async Task ListDatabases()
        {
            var names = _client.ListDatabases().ToList();

            foreach (var dbname in names)
            {
                TextboxMain.AppendText($"database: {dbname}\r\n");
            }

            TextboxMain.AppendText($"\r\n");
        }

        

        public async Task PrintAllInCollection(string collectionName = "TriciaMainCollection")
        {
            var db = _client.GetDatabase("TriciaMain");
            var collection = db.GetCollection<Student>(collectionName);

            var items = (from s in collection.AsQueryable()
                        select s).ToList();

            if (!items.Any())
                TextboxMain.AppendText("No items found\r\n");
            else
                foreach (var item in items)
                {
                    TextboxMain.AppendText($"{item}\r\n");
                }
        }


        public async Task AddStudent(string collectionName = "TriciaMainCollection")
        {
            //BsonSerializer

            var student = new Student();
            student.StudentId = "1245";
            student.Stage = 0;

            var db = _client.GetDatabase("TriciaMain");
            var collection = db.GetCollection<BsonDocument>(collectionName);
            collection.InsertOne(student.ToBsonDocument());
        }

        public async Task DeleteItem(string collectionName = "TriciaMainCollection", string id = "1245")
        {
            var db = _client.GetDatabase("TriciaMain");
            var collection = db.GetCollection<BsonDocument>(collectionName);
            var filter = Builders<BsonDocument>.Filter.Eq("StudentId", id);
            collection.DeleteOne(filter);

        }

        
    }


    class BaseElement
    {
        [BsonId]
        public ObjectId _id { get; set; }

        public BaseElement()
        {
            _id = ObjectId.GenerateNewId();
        }
    }

    class Student : BaseElement
    {
        [BsonElement("StudentId")]
        public string StudentId { get; set; }

        [BsonElement("Stage")]
        public int Stage { get; set; }


       
    }
}
