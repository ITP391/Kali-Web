using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Kali_Web.Quiz
{
    public partial class QuizResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the category from the URL
            var questionsCateg = Request.QueryString["category"];

            // Get the user ID from the Session
            // This is added when the user logs in
            var userId = int.Parse(Session["userId"]?.ToString() ?? "1");

            // Take the list of answers from the session
            var answersList = (List<QuizAnswer>) Session["answers" + questionsCateg];

            // If time expired
            if (answersList == null)
            {
                totalAnswersLabel.Text = "0";
                correctAnswersLabel.Text = "0";
                RetakQuizButton.NavigateUrl = "TakeQuiz.aspx?category=" + questionsCateg;
                notCompletedInTimeLabel.Text = "Quiz was not finished in specified amount of time";
                return;
            }

            // Connect to database
            using (var myConnection = new SqlConnection(System.Configuration.ConfigurationManager
                .ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {

                myConnection.Open();

                // Remove previous entry of the score for this quiz
                string deleteQuery = "DELETE FROM [dbo].[QuizzResult] WHERE UserId = @UserId and Category = @Category";
                var deleteCommand = new SqlCommand(deleteQuery, myConnection);
                deleteCommand.Parameters.AddWithValue("UserId", userId);
                deleteCommand.Parameters.AddWithValue("Category", questionsCateg.ToUpper());

                deleteCommand.ExecuteNonQuery();

                // Insert new entry with the score for this quiz
                // !!! The functionality for showing the score is not implemented yet !!!
                string query = "INSERT INTO [dbo].[QuizzResult](UserId, Category, CorrectAnswers, TotalAnswers, Score) VALUES (@UserId, @Category, @CorrectAnswers, @TotalAnswers, @Score)";
                SqlCommand command = new SqlCommand(query, myConnection);

                //To prevent sql injection
                command.Parameters.AddWithValue("UserId", userId);
                command.Parameters.AddWithValue("Category", questionsCateg.ToUpper());
                command.Parameters.AddWithValue("CorrectAnswers", answersList.Count(x => x.AnswerIsCorrect).ToString());
                command.Parameters.AddWithValue("TotalAnswers", answersList.Count.ToString()); 
                command.Parameters.AddWithValue("Score",  answersList.Count(x => x.AnswerIsCorrect) / answersList.Count * 10);

                command.ExecuteNonQuery();
            }

            // Update data for the view
            QuizAnswers.DataSource = answersList;
            QuizAnswers.DataBind();
            RetakQuizButton.NavigateUrl = "TakeQuiz.aspx?category=" + questionsCateg;
            totalAnswersLabel.Text = answersList.Count.ToString();
            correctAnswersLabel.Text = answersList.Count(x => x.AnswerIsCorrect).ToString();
        }
    }
}