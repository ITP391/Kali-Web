using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kali_Web.Quiz
{
    public partial class AddTextQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This function adds the question to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddQuestion_Callback(object sender, EventArgs e)
        {
            // Open the connection to database
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager
                .ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {

                myConnection.Open();

                // Query for inserting the question
                string query =
                    "INSERT INTO [dbo].[Question]" +
                    "(Category, Description, Answer1, Answer2, Answer3, Answer4, CorrectOption, CorrectAnswer, QuestionType)";
                query += " VALUES (@Category, @Description, @Answer1, @Answer2, @Answer3, @Answer4, @CorrectOption, @CorrectAnswer, @QuestionType)";
                SqlCommand myCommand = new SqlCommand(query, myConnection);

                //To prevent sql injection
                myCommand.Parameters.AddWithValue("Category", QuestionCategory.SelectedValue);
                myCommand.Parameters.AddWithValue("Description", QuestionDescriptionTextBox.Text);
                myCommand.Parameters.AddWithValue("Answer1", DBNull.Value);
                myCommand.Parameters.AddWithValue("Answer2", DBNull.Value);
                myCommand.Parameters.AddWithValue("Answer3", DBNull.Value);
                myCommand.Parameters.AddWithValue("Answer4", DBNull.Value);
                myCommand.Parameters.AddWithValue("CorrectOption", DBNull.Value);
                myCommand.Parameters.AddWithValue("CorrectAnswer", QuestionsCorrectAnswerTextBox.Text);
                myCommand.Parameters.AddWithValue("QuestionType", "TEXT");

                myCommand.ExecuteNonQuery();

                // Clear input
                QuestionDescriptionTextBox.Text = string.Empty;
                QuestionsCorrectAnswerTextBox.Text = null;
            }

            // Redirect to the page where we show all questions
            Response.Redirect("ConfigureQuiz.aspx");
        }
    }
}