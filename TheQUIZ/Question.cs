using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TheQUIZ
{
    class Question
    {
       
       public string QuestionDescription { get; set; }
        public string CorrectAnswer { get; set; }
        string[] AnswerOptions { get; set; } = new string[4];
        private string options = "ABCD";
        public Question(string question, string correctA, string[] answerOpt)
        {
            QuestionDescription = question;
            CorrectAnswer = correctA;
            AnswerOptions = answerOpt;
        }
        public void PrintQnA()
        {
            Console.WriteLine(QuestionDescription);
            Thread.Sleep(1000);
            Console.WriteLine();
            for (int i = 0; i < AnswerOptions.Length; i++)
            {
                Console.WriteLine($"{options.Substring(i,1)}.{AnswerOptions[i]}");
            }
            Console.WriteLine();
        }

        public bool isAnsweredABCD(string playerInput)
        {
            bool isABCD = false;
            for (int i = 0; i < options.Length; i++)
            {
                if (playerInput == options.Substring(i, 1))
                {
                        isABCD = true; 
                }
            }
            return isABCD;
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
