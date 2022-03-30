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
        public IEnumerable<Question> BatQuestions { get; private set; }
        public IEnumerable<Question> Questions { get; private set; }

        public void LoadQuestions(string pathToData)
        {
            var jsonText = File.ReadAllText(System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot"), pathToData));
            var questions = JsonSerializer.Deserialize<List<Question>>(jsonText);
            Questions = questions?.ToList() ?? new List<Question>();

            for (int i = 0; i < questions.Count; i++)
            {
                if(questions[i].QuestionText.StartsWith("Immediately prior to"))
                {
                    questions[i].QuestionText = "Immediately prior to Pasteur’s discovery, what ingredients were brewers likely to put in their beer?";
                }
            }

        }

        public void LoadBatQuestions(string pathToData)
        {
            var jsonText = File.ReadAllText(System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot"), pathToData));
            var questions = JsonSerializer.Deserialize<List<Question>>(jsonText);
            BatQuestions = questions?.ToList() ?? new List<Question>();

            for (int i = 0; i < questions.Count; i++)
            {
                var answers = questions[i].Answers.ToList();

                for (int j = 0; j < answers.Count; j++)
                {
                    if (answers[j].StartsWith("Gravity will pull on the"))
                    {
                        answers[j] = "Gravity will pull on the bat’s body, keeping the talons closed, and it will remain upside down.";
                    }
                }
                questions[i].Answers = answers;
                
            }
        }


    }
}
