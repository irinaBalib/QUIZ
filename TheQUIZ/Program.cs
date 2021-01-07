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

            Console.WriteLine("C# QUIZ");
            Console.WriteLine("Game rules:...");
            Console.WriteLine("Enter Player's name or print START to begin the game:");
           
            do
            {
                //creating Players 
                string playersName = Console.ReadLine();
                Console.WriteLine($"{playersName} added to the game.");
                ListOfPlayers.Add(new Player(playersName));
            } while (Console.ReadLine() != "START");


        }
    }
}
