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
using Tricia.Data;

namespace TriciaLocalDataClient.Views
{
    /// <summary>
    /// Interaction logic for QuestionView.xaml
    /// </summary>
    public partial class QuestionView : UserControl
    {

        private QuestionService questionService;



        private Question targetQuestion;
        private List<Question> questionList;
        
        





        public QuestionView()
        {
            InitializeComponent();


            questionService = new QuestionService(AppConfigurator.MongoDbConnectionString);
            questionList = questionService.GetQuestions().ToList();
            ListBoxQuestions.DisplayMemberPath = nameof(Question.QuestionText);
            ListBoxQuestions.ItemsSource = questionList;
        }

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            targetQuestion = new Question();
            QuestionIdTextbox.Text = targetQuestion.QuestionId;
            QuestionTextTextbox.Text = targetQuestion.QuestionText;            
        }

        private void RemoveQuestionButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveQuestionButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void RemoveAnswerButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveAnswerButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
