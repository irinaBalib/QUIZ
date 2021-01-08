using System;
using System.Collections.Generic;

namespace TheQUIZ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Question> ListOfQuestions = new List<Question>();
            //create Question objects with all the properties

            List<Player> ListOfPlayers = new List<Player>();

            ListOfQuestions.Add(new Question("Which of these data types is NOT exclusive to storing numbers?", "var", new List<string>(){ "int", "double", "float"}));
            ListOfQuestions.Add(new Question("What is the equivalent for SQL data type bit?", "bool", new List<string>() { "var", "get", "set" }));
            //creating questions....
            
            Console.WriteLine("C# QUIZ");
            Console.WriteLine("Game rules:...");
            Console.WriteLine("Add Players to the game.");
            int n = 1;
            do     //creating Players 
            {
                Console.Write($"Player's {n} name: ");
                string playersName = Console.ReadLine();
                ListOfPlayers.Add(new Player(playersName));
                Console.WriteLine($"{playersName} added to the game.");
                Console.WriteLine("Type '+' to add more players or 'GO' to start the game.");
                n++;
            } while (Console.ReadLine() != "GO");

           
            for (int i = 0; i < (ListOfQuestions.Count-1); i++)
            {
                ListOfQuestions[i].PrintQnA(); // whyyy not printing?!
            }

            // how to assign answers to ABCD
        }
    }
}
