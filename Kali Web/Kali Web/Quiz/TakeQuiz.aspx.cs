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
        // Property for the counter (counts the seconds)
        static int? counter;

        // Propery for how many seconds should each user be allowed on page 
        // multiplied by number of questions
        private static int secondPerQuestion = 20;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the questions for a specific category and add them to the repeater
            var questionsCateg = Request.QueryString["category"];
            MyRepeater.DataSource = GetQuestions(questionsCateg);
            MyRepeater.DataBind();

            // Initialize the counter with number of questions multiplied by time allowed for each question
            if(counter == null) counter = secondPerQuestion * GetQuestions(questionsCateg).Count;
        }

        /// <summary>
        /// Function for verifying the answers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void VerifyAnswers(object sender, EventArgs e)
        {
            // Get the category from the URL
            var questionsCateg = Request.QueryString["category"];

            // If counter expired, redirect to the result page
            if (sender == null && e == null)
            {
                counter = null;
                Response.Redirect("QuizResult.aspx?category=" + questionsCateg);
            }

            // Get the list of questions for a specific category
            var questionsList = GetQuestions(questionsCateg);
            var answersList = new List<QuizAnswer>();
            NameValueCollection formValues = Request.Form;

            foreach (var formParamKey in formValues.AllKeys)
            {
                // if it is a CHOICE question, read the answers and add the answer to the list
                if (formParamKey.StartsWith("question-choice"))
                {
                    var questionChoiceAnswer = int.Parse(formValues[formParamKey]);
                    var questionId = int.Parse(formParamKey.Split('-')[2]);

                    answersList.Add(new QuizAnswer
                    {
                        ChosenChoiceAnswer = questionChoiceAnswer,
                        InitialQuestion = questionsList.First(x => x.Id == questionId)
                    });
                }

                // if it is a TEXT question, read the answers and add the answer to the list
                else if (formParamKey.StartsWith("question-text"))
                {
                    var questionTextAnswer =formValues[formParamKey];
                    var questionId = int.Parse(formParamKey.Split('-')[2]);

                    answersList.Add(new QuizAnswer
                    {
                        ChosenTextAnswer = questionTextAnswer,
                        InitialQuestion = questionsList.First(x => x.Id == questionId),
                    });
                }
            }

            // Add the answers list to the session variable (used in QuizResult.aspx.cs)
            Session["answers" + questionsCateg] = answersList;
            counter = null;

            // Redirect to result page
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