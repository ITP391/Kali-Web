

namespace Kali_Web.Quiz
{
    /// <summary>
    /// Class for representing a specific quiz question
    /// </summary>
    public class QuizQuestion
    {
        public QuizQuestion(int id, string category, string description,string answer1, string answer2, string answer3, string answer4, int correctAnswer, string correctTextAnswer = null, string questionType = "CHOICE")
        {
            Id = id;
            Category = category;
            Answer1 = answer1;
            Answer2 = answer2;
            Answer3 = answer3;
            Answer4 = answer4;
            Description = description;
            CorrectAnswer = correctAnswer;
            CorrectTextAnswer = correctTextAnswer;
            QuestionType = questionType;
        }

        public int Id { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string Answer1 { get; set; }

        public string Answer2 { get; set; }

        public string Answer3 { get; set; }

        public string Answer4 { get; set; }

        public string CorrectTextAnswer { get; set; }

        public string QuestionType { get; set; }

        public int CorrectAnswer { get; set; }
    }
}