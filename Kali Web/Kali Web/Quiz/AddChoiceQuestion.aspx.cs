using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kali_Web.Quiz
{
    public partial class AddChoiceQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddChoiceQuestion_Callback(object sender, EventArgs e)
        {
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager
                .ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {

                myConnection.Open();
                string query =
                    "INSERT INTO [dbo].[Question]" +
                    "(Category, Description, Answer1, Answer2, Answer3, Answer4, CorrectOption, CorrectAnswer, QuestionType)";
                query += " VALUES (@Category, @Description, @Answer1, @Answer2, @Answer3, @Answer4, @CorrectOption, NULL, @QuestionType)";
                SqlCommand myCommand = new SqlCommand(query, myConnection);

                //To prevent sql injection
                myCommand.Parameters.AddWithValue("Category", QuestionCategory.SelectedValue);
                myCommand.Parameters.AddWithValue("Description", QuestionDescriptionTextBox.Text);
                myCommand.Parameters.AddWithValue("Answer1", Answer1TextBox.Text);
                myCommand.Parameters.AddWithValue("Answer2", Answer2TextBox.Text);
                myCommand.Parameters.AddWithValue("Answer3", Answer3TextBox.Text);
                myCommand.Parameters.AddWithValue("Answer4", Answer4TextBox.Text);
                myCommand.Parameters.AddWithValue("CorrectOption", int.Parse(CorrectAnswerTextBox.Text));
                myCommand.Parameters.AddWithValue("QuestionType", "CHOICE");

                myCommand.ExecuteNonQuery();

                QuestionDescriptionTextBox.Text = string.Empty;
                Answer1TextBox.Text = string.Empty;
                Answer2TextBox.Text = string.Empty;
                Answer3TextBox.Text = string.Empty;
                Answer4TextBox.Text = string.Empty;
                CorrectAnswerTextBox.Text = "1";
            }

            Response.Redirect("ConfigureQuiz.aspx");
        }
    }
}