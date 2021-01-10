using System;
using System.Collections.Generic;
using System.Text;

namespace TheQUIZ
{
    class Question
    {
       
       public string QuestionDescription { get; set; }
        public string CorrectAnswer { get; set; }
        // List<string> CorrectAnswer { get; set; } = new List<string>(); // --- if we want Q with multiple correct A, should be a list too
        // List<string> AnswerOptions { get; set; } = new List<string>(); //--- list for all options
        string[] AnswerOptions { get; set; } = new string[4];
        private string options = "ABCD";
        public Question(string q, string ca, string[] a)
        {
            q = QuestionDescription;
            ca = CorrectAnswer;
            a = AnswerOptions;
        }
        public void PrintQnA()
        {

            
            Console.WriteLine(QuestionDescription);
            Console.WriteLine();
            for (int i = 0; i < AnswerOptions.Length; i++)
            {
                Console.WriteLine($"{options.Substring(i,1)}.{AnswerOptions[i]}");
            }
        }

        public bool isAnsweredCorrectly(string playerInput)
        {
            bool isCorrect = false;
            for (int i = 0; i < options.Length; i++)
            {
                if (playerInput == options.Substring(i,1) )
                {
                    if (AnswerOptions[i] == CorrectAnswer)
                    {
                        isCorrect = true; ;
                    }
                }
            }
            return isCorrect;
        }

    }
}
