using System;
using System.Collections.Generic;
using System.Linq;

namespace TheQUIZ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Question> ListOfQuestions = new List<Question>();
            //create Question objects with all the properties

            List<Player> ListOfPlayers = new List<Player>();

            ListOfQuestions.Add(new Question("Which of these data types is NOT exclusive to storing numbers?", "var", new string[4]{ "int", "var","double", "float"}));
            ListOfQuestions.Add(new Question("What is the equivalent for SQL data type bit?", "bool", new string[4] { "var", "get", "set", "bool" }));
            //creating questions....
            
            Console.WriteLine("C# QUIZ");
            Console.WriteLine("Game rules:...");
            Console.WriteLine("Add Players to the game.");
            int playersCounter = 1;
            do     //creating Players    ----- WORKS OK
            {
                Console.Write($"Player's {playersCounter} name: ");
                string playersName = Console.ReadLine();
                ListOfPlayers.Add(new Player(playersName));
                Console.WriteLine($"{playersName} added to the game.");
                Console.WriteLine("Type '+' to add more players or 'GO' to start the game.");
                playersCounter++;
            } while (Console.ReadLine() != "GO");

             Console.Clear();

            foreach (Question q in ListOfQuestions)
            {
                q.PrintQnA(); 

                for (int y = 0; y < ListOfPlayers.Count; y++)
                {
                    Player p = ListOfPlayers[y];
                    Console.Write($"Player {y+1} {p.Name} answer: ");
                    string playerInput = Console.ReadLine();
                    bool isCorrect = q.isAnsweredCorrectly(playerInput);
                    if (isCorrect)
                    {
                        Console.Write("Correct! ");
                        Console.WriteLine($"Your current score: {p.AddScore()}");
                    }
                    else
                    {
                        Console.Write("False! ");
                        Console.WriteLine($"Your current score: {p.ViewScore()}");
                    }
                }
                Console.Clear();
            }

            //who won -  getting max Score and comparing each Player's score to it  ---   WORKS OK
            
            
            List<int> listOfScores = new List<int> {};
            foreach (Player p in ListOfPlayers)
            {
                listOfScores.Add(p.Score);
            }

            int winnersScore = listOfScores.Max();
            //checking if all have score 0
            if (winnersScore == 0)                       
            {
                Console.WriteLine("No winner today. Keep learning!");
                Console.ReadLine();
                Environment.Exit(0);
            }

            List<Player> listOfWinners = new List<Player> { };   // checking who has top score and putting them into a list 

            foreach (Player p in ListOfPlayers)
            {
                if (p.Score == winnersScore)
                {
                    listOfWinners.Add(p);
                }
            }

            // checking if we have a)1 winner  b)few winners  c) its a tie 
            if (listOfWinners.Count == 1)
            {
                Console.WriteLine($"{listOfWinners[0].Name} is the winner!");
            }
            else if (listOfScores.Count == listOfWinners.Count)
            {
                Console.WriteLine($"It's a tie! You all got {winnersScore} points.");
            }
            else
            {
                Console.WriteLine("The winners are:");
                foreach (Player p in listOfWinners)
                {
                    Console.WriteLine(p.Name);
                }
                Console.WriteLine($"They all got {winnersScore} points.");
            }

            // score bord: make a static(?) method that receives int score and draws a pic
        }
    }
}
