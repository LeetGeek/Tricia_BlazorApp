namespace BlazorApp_Tricia.Data
{
    public class QuestionProviderService
    {
        public Task<TestQuestion[]> GetTestQuestions()
        {
            var list = new List<string>();
            return Task.FromResult(new TestQuestion[2]
            {
                new TestQuestion()
                {
                    Question= "What is fermentation?",
                    Answer1= "A process where a sugar is broken down into ethanol and carbon dioxide.",
                    Answer2 = "A process where a sugar is broken down into yeast and carbon dioxide.",
                    Answer3 = "A process where yeast in broken down to ethanol and carbon dioxide.",
                    Answer4 = "A process where sugar is broken down to ethanol and yeast.",
                    CorrectAnswer = 1
                },
                new TestQuestion()
                {
                   Question= "In the fermentation process, what molecule is produced as yeast consume sugars?",
                   Answer1="Lactic Acid",
                   Answer2="Glucose",
                   Answer3="ATP",
                   Answer4="Carbon Dioxide",
                   CorrectAnswer=3                
                }

            });
        }
    }
}
