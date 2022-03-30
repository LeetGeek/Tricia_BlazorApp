// See https://aka.ms/new-console-template for more information
//using Newtonsoft.Json;
//using Tricia.Data;

//Console.WriteLine("Hello, World!");

//var qs = new List<Question>();
//var q = new Question();
//q.QuestionId = "question1";
//q.QuestionText = "What is fermentation?";
//q.Order = 1;
//q.CorrectAnswerId = 1;

//var answers = new List<string>()
//{
//    "A process where a sugar is broken down into ethanol and carbon dioxide.",
//    "A process where a sugar is broken down into yeast and carbon dioxide.",
//    "A process where yeast in broken down to ethanol and carbon dioxide.",
//    "A process where sugar is broken down to ethanol and yeast.",
//};

//q.Answers = answers;
//qs.Add(q);


//q = new Question();
//q.QuestionId = "question2";
//q.QuestionText = "In the fermentation process, what molecule is produced as yeast consume sugars?";
//q.Order = 2;
//q.CorrectAnswerId = 4;

//answers = new List<string>()
//{
//    "Lactic Acid",
//    "Glucose",
//    "ATP",
//    "Carbon Dioxide"

//};

//q.Answers = answers;
//qs.Add(q);


//JsonSerializer serializer = new JsonSerializer();
//serializer.Formatting = Formatting.Indented;
//using (StreamWriter sw = new StreamWriter(@".\json.txt"))
//using (JsonWriter writer = new JsonTextWriter(sw))
//{
//    serializer.Serialize(writer, qs);
//    // {"ExpiryDate":new Date(1230375600000),"Price":0}
//}

using System.Web;

Console.WriteLine(HttpUtility.HtmlEncode("Immediately prior to Pasteur’s discovery, what ingredients were brewers likely to put in their beer?")); 