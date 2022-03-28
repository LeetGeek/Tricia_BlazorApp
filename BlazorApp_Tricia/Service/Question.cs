using System.Text.Json;

namespace BlazorApp_Tricia.Service
{
    public class Question
    {
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int Order { get; set; }
        public IEnumerable<string> Answers { get; set; }
        public int CorrectAnswerId { get; set; }
    }

    public class QuestionService
    {
        public IEnumerable<Question> Questions { get; private set; }

        public void Load(string pathToData)
        {
            var jsonText = File.ReadAllText(System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot"), pathToData));
            var questions = JsonSerializer.Deserialize<List<Question>>(jsonText);
            Questions = questions?.ToList();
        }


    }
}
