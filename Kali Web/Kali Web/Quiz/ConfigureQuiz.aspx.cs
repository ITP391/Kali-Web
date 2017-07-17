using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace Kali_Web.Quiz
{
    public partial class ConfigureQuiz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var informationGatheringQuestions = ReadQuestionsFromDatabase("IG");
            var vulnerabilityAnalysisQuestions = ReadQuestionsFromDatabase("VA");
            var passwordAttackQuestions = ReadQuestionsFromDatabase("PA");

            InformationGatheringQuestionsRepeater.DataSource = informationGatheringQuestions;
            InformationGatheringQuestionsRepeater.DataBind();

            VulnerabilityAnalysisQuestionsRepeater.DataSource = vulnerabilityAnalysisQuestions;
            VulnerabilityAnalysisQuestionsRepeater.DataBind();

            PasswordAttackQuestionsRepeater.DataSource = passwordAttackQuestions;
            PasswordAttackQuestionsRepeater.DataBind();
        }

        private void DeleteQuestionFromDatabase(int id)
        {
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager
                .ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {

                myConnection.Open();

                string query = "DELETE FROM [dbo].[Question] WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        private List<QuizQuestion> ReadQuestionsFromDatabase(string questionCategory)
        {
            var categoryQuestions = new List<QuizQuestion>();

            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {

                myConnection.Open();

                string query = "SELECT * FROM [dbo].[Question] WHERE Category = @Category";
                SqlCommand command = new SqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@Category", questionCategory);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = int.Parse(reader["Id"].ToString());
                        string category = reader["Category"].ToString();
                        string description = reader["Description"].ToString();
                        string answer1 = reader["Answer1"].ToString();
                        string answer2 = reader["Answer2"].ToString();
                        string answer3 = reader["Answer3"].ToString();
                        string answer4 = reader["Answer4"].ToString();
                        int correctOption;
                        int.TryParse(reader["CorrectOption"].ToString(), out correctOption);
                        string questionType = reader["QuestionType"].ToString();
                        string correctTextAnswer = reader["CorrectAnswer"].ToString();

                        categoryQuestions.Add(new QuizQuestion(id, category, description, answer1, answer2, answer3, answer4, correctOption, correctTextAnswer, questionType));
                    }
                }

                return categoryQuestions;
            }
        }

        protected void DeleteQuestion(object sender, EventArgs e)
        {
            var questionId = ((HtmlAnchor)sender).Attributes["question-id"];

            DeleteQuestionFromDatabase(int.Parse(questionId));

            Page_Load(null, null);
        }

    }
}