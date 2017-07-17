
namespace Kali_Web.Quiz
{
    public class QuizAnswer
    {
        public QuizQuestion InitialQuestion { get; set; }

        public int ChosenAnswer { get; set; }

        public int CorrectAnswer => InitialQuestion.CorrectAnswer;

        public string QuestionDescription => InitialQuestion.Description;

        public string Answer1 => InitialQuestion.Answer1;

        public string Answer2 => InitialQuestion.Answer2;
                            
        public string Answer3 => InitialQuestion.Answer3;
                            
        public string Answer4 => InitialQuestion.Answer4;
    }
}