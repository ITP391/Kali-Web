
using System.Linq;

namespace Kali_Web.Quiz
{
    /// <summary>
    /// Class for representing a answer given by the user
    /// </summary>
    public class QuizAnswer
    {
        public QuizQuestion InitialQuestion { get; set; }

        public string QuestionType => InitialQuestion.QuestionType;

        public int ChosenChoiceAnswer { get; set; }
        
        public string ChosenTextAnswer { get; set; }

        public int CorrectAnswer => InitialQuestion.CorrectAnswer;

        public string CorrectTextAnswer => InitialQuestion.CorrectTextAnswer;

        public string QuestionDescription => InitialQuestion.Description;

        public string Answer1 => InitialQuestion.Answer1;

        public string Answer2 => InitialQuestion.Answer2;
                            
        public string Answer3 => InitialQuestion.Answer3;
                            
        public string Answer4 => InitialQuestion.Answer4;

        /// <summary>
        /// Checks if answer is correct, depeding on the type of the question
        /// </summary>
        public bool AnswerIsCorrect
        {
            get
            {
                // if CHOICE, only check the numbers are equals
                if (QuestionType == "CHOICE")
                {
                    return CorrectAnswer == ChosenChoiceAnswer;
                }

                // if TEXT, each word in the correctWords should exist in the words that the user entered
                if (QuestionType == "TEXT")
                {
                    var correctWords = CorrectTextAnswer.ToLower().Split(' ').ToList();
                    var chosenWords = ChosenTextAnswer.ToLower().Split(' ').ToList();

                    foreach (var correctWord in correctWords)
                    {
                        if (!chosenWords.Contains(correctWord)) return false;
                    }

                    return true;
                }

                return false;
            }
        }
    }
}