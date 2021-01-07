using System;
using System.Collections.Generic;
using System.Text;

namespace TheQUIZ
{
    class Question
    {
       
        public string QuestionDescription;
       /* public string CorrectAnswer;  --- if we want Q with multiple correct A, should be a list too
        List<string> AnswerOptions = new List<string>();  --- list for incorrect options
       */

        public void PrintQnA()
        {
            Console.WriteLine(QuestionDescription);
            Console.WriteLine();
            
            // need to figure out how to output answer options from two lists randomly
        }

        public bool isAnsweredCorrectly(string a)
        {
            //handling player's answer to the method to compare if its correcct
            // how to handle q with multiple answers?
            return true;
        }

    }
}
