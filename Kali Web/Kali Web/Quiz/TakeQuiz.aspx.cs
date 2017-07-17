using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace Kali_Web.Quiz
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static int? counter;

        private static int secondPerQuestion = 20;

        protected void Page_Load(object sender, EventArgs e)
        {
            var questionsCateg = Request.QueryString["category"];
            MyRepeater.DataSource = GetQuestions(questionsCateg);
            MyRepeater.DataBind();

            if(counter == null) counter = secondPerQuestion * GetQuestions(questionsCateg).Count;
        }

        protected void VerifyAnswers(object sender, EventArgs e)
        {
            var questionsCateg = Request.QueryString["category"];

            if (sender == null && e == null)
            {
                counter = null;
                Response.Redirect("QuizResult.aspx?category=" + questionsCateg);
            }

            var questionsList = GetQuestions(questionsCateg);
            var answersList = new List<QuizAnswer>();
            NameValueCollection formValues = Request.Form;

            foreach (var formParamKey in formValues.AllKeys)
            {
                if (formParamKey.StartsWith("question"))
                {
                    var questionAnswer = int.Parse(formValues[formParamKey]);
                    var questionId = int.Parse(formParamKey.Split('-')[1]);

                    answersList.Add(new QuizAnswer{ ChosenAnswer = questionAnswer, InitialQuestion = questionsList.First(x => x.Id == questionId)});
                }
            }

            Session["answers" + questionsCateg] = answersList;
            counter = null;

            Response.Redirect("QuizResult.aspx?category=" + questionsCateg);
        }

        private List<QuizQuestion> GetQuestions(string questionCategory)
        {
            var questionsList = new List<QuizQuestion>();

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

                        questionsList.Add(new QuizQuestion(id, category, description, answer1, answer2, answer3, answer4, correctOption, correctTextAnswer, questionType));
                    }
                }


            }
            return questionsList;
        }

        protected void AnswerQuestions(object sender, EventArgs e)
        {
            var a = (RadioButton) sender;
            throw new NotImplementedException();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            counter = counter - 1;
            CounterLabel.Text = counter.ToString();

            if (counter < 0)
            {
                var questionsCateg = Request.QueryString["category"];
                VerifyAnswers(null, null);
                Response.Redirect("QuizResult.aspx?category=" + questionsCateg);
            }
        }
    }
}