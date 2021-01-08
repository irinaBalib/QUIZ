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
        List<string> AnswerOptions { get; set; } = new List<string>(); //--- list for all options
       
        public Question(string q, string ca, List<string> l)
        {
            q = QuestionDescription;
            ca = CorrectAnswer;
            l = AnswerOptions;
        }
        public void PrintQnA()
        {
            Console.WriteLine(QuestionDescription);
            Console.WriteLine();
           
            
            // need to figure out how to output answer options from two lists randomly
        }

        public bool isAnsweredCorrectly(string a)
        {
            //handling player's answer to the method to compare if its correcct
        
            // Loop in a loop!!
            return true;
        }

    }
}
