using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace Kali_Web.Quiz
{
    public partial class ConfigureQuiz : System.Web.UI.Page
    {
        /// <summary>
        /// When page loads, we read questions from database 
        /// and add the to the repeater controls from the html file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Read all questions categories
            var informationGatheringQuestions = ReadQuestionsFromDatabase("IG");
            var vulnerabilityAnalysisQuestions = ReadQuestionsFromDatabase("VA");
            var passwordAttackQuestions = ReadQuestionsFromDatabase("PA");

            // Set data for the information gathering repeater
            InformationGatheringQuestionsRepeater.DataSource = informationGatheringQuestions;
            InformationGatheringQuestionsRepeater.DataBind();

            // Set data for the vulnerability analysis repeater
            VulnerabilityAnalysisQuestionsRepeater.DataSource = vulnerabilityAnalysisQuestions;
            VulnerabilityAnalysisQuestionsRepeater.DataBind();

            // Set data for the password attack repeater
            PasswordAttackQuestionsRepeater.DataSource = passwordAttackQuestions;
            PasswordAttackQuestionsRepeater.DataBind();
        }

        /// <summary>
        /// This functions deletes the question for the database
        /// </summary>
        /// <param name="id"></param>
        private void DeleteQuestionFromDatabase(int id)
        {
            // Open connection to database
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager
                .ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {

                myConnection.Open();

                // Create and execute query
                string query = "DELETE FROM [dbo].[Question] WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Function to read all questions of a certain category (IG, VA, PA) from the database
        /// </summary>
        /// <param name="questionCategory"></param>
        /// <returns></returns>
        private List<QuizQuestion> ReadQuestionsFromDatabase(string questionCategory)
        {
            var categoryQuestions = new List<QuizQuestion>();

            // opened connection to database
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {

                myConnection.Open();

                // executing query
                string query = "SELECT * FROM [dbo].[Question] WHERE Category = @Category";
                SqlCommand command = new SqlCommand(query, myConnection);

                //adding parameter for certain category
                command.Parameters.AddWithValue("@Category", questionCategory);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    // Create a list of 'QuizQuestion', in the 'categoryQuestions' variable.
                    while (reader.Read())
                    {
                        // Read data form database
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


                        // Add question to the list
                        categoryQuestions.Add(
                            new QuizQuestion(
                                id, 
                                category, 
                                description, 
                                answer1,
                                answer2, 
                                answer3, 
                                answer4,
                                correctOption, 
                                correctTextAnswer,
                                questionType));
                    }
                }

                return categoryQuestions;
            }
        }

        /// <summary>
        /// Function called from the html, that reads the id of the question and deletes it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DeleteQuestion(object sender, EventArgs e)
        {
            // get the id of the question the user clicked on
            var questionId = ((HtmlAnchor)sender).Attributes["question-id"];

            // delete question
            DeleteQuestionFromDatabase(int.Parse(questionId));

            // refresh view
            Page_Load(null, null);
        }

    }
}