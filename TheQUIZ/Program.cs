﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace TheQUIZ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Question> ListOfQuestions = new List<Question>();
            List<Player> ListOfPlayers = new List<Player>();

            ListOfQuestions.Add(new Question("Which of these data types is NOT exclusive to storing numbers?", "var", new string[4]{ "int", "var","double", "float"}));
            ListOfQuestions.Add(new Question("What is the equivalent for SQL data type bit?", "bool", new string[4] { "var", "get", "set", "bool" }));
            //creating questions....

            #region oldWayToAddPlayers
            /*
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
            */
            #endregion

            Console.WriteLine("Welcome to C# QUIZ!");
            Console.Write("How many players will play?  ");
            int playerCount;
            bool isInputANumber= int.TryParse(Console.ReadLine(), out playerCount);
            while (!isInputANumber)
            {
                ClearPreviousLine();
                Console.Write("Invalid input! Please enter the number of players:  ");
                isInputANumber = int.TryParse(Console.ReadLine(), out playerCount);
            }

            for (int i = 0; i < playerCount; i++)
            {
                Console.Write($"Please, enter the name for Player {i + 1}: ");
                string playerName = Console.ReadLine();
                    while (playerName == "")
                    {
                         ClearPreviousLine();
                         Console.Write($"Player {i + 1} not saved. Please enter a name for Player {i + 1}: ");
                        playerName = Console.ReadLine();
                    }
                ListOfPlayers.Add(new Player(playerName));
            }
            Console.WriteLine();

            Console.WriteLine($"Here are the {playerCount} players added to the game: ");
            for (int i = 0; i < playerCount; i++)
            {
                Console.WriteLine($"Player {i + 1} : {ListOfPlayers[i].Name}");
            }
            Console.WriteLine();

            Console.WriteLine("RULES: You will have time to read the question, then each player will have 30sec to answer. \n" +
                "Each correct answer gives 10 points. \n" +
                "** Try to give your answer as quick as possible - saved time will be added to your score as a bonus!\n" +
                "The game will begin in ... ");
            Console.WriteLine();

            #region Countdown

            int centerCursor = Console.WindowWidth / 2;
            int countdown = 5;
            Console.SetCursorPosition(centerCursor, Console.CursorTop);
            Console.Write(countdown);
            do
            {
                Thread.Sleep(1000);
                countdown--;
                Console.SetCursorPosition(centerCursor, Console.CursorTop);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(countdown);
            } while (countdown > 0);
            #endregion

            Console.Clear();
            Console.WriteLine();

            #region ReadySteadyGO

            Console.SetCursorPosition((Console.WindowWidth - 5) / 2, Console.CursorTop);
            Console.WriteLine("READY");
            Thread.Sleep(800);
            Console.SetCursorPosition((Console.WindowWidth - 6) / 2, Console.CursorTop - 1);
            Console.WriteLine("STEADY");
            Thread.Sleep(800);
            Console.SetCursorPosition((Console.WindowWidth - 17) / 2, Console.CursorTop - 1);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("***    GO!    ***");
            Thread.Sleep(800);
            Console.ResetColor();
            Console.Clear();
            #endregion

            foreach (Question q in ListOfQuestions)
            {
                q.PrintQnA();
                Thread.Sleep(4000);     // pause for Players to read the question and options

                for (int y = 0; y < ListOfPlayers.Count; y++)
                {
                    Player p = ListOfPlayers[y];
                    Console.Write($"Player {y+1} {p.Name} answer: ");

                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    string playerInput = Console.ReadLine().ToUpper();
                    while (!q.isAnsweredABCD(playerInput))
                    {
                        ClearPreviousLine();
                        Console.Write($"Invalid input - please enter option A/B/C/D. Player {y + 1} {p.Name} answer: ");
                        playerInput = Console.ReadLine().ToUpper();
                    }
                    stopWatch.Stop();

                    TimeSpan ts = stopWatch.Elapsed;
                    int time = int.Parse(ts.Seconds.ToString());

                    ClearPreviousLine();
                    Console.WriteLine($"Player {y + 1} {p.Name} answered in {time} seconds");   // This hides Player's answer so that next Player wouldn't see it
                    
                    bool isCorrect = q.isAnsweredCorrectly(playerInput);
                    if (isCorrect)
                    {
                        Console.Write("Correct! ");
                        Console.WriteLine($"Your current score: {p.AddScore(time)}");
                    }
                    else
                    {
                        Console.Write("False! ");
                        Console.WriteLine($"Your current score: {p.ViewScore()}");
                    }
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Correct answer is {q.CorrectAnswer}.");
                Console.ResetColor();
                Console.WriteLine();
                PrintScoreBoard(ListOfPlayers);
                Console.ReadLine();

                Console.Clear();
            }

            #region WhoWon
            //  getting max Score and comparing each Player's score to it  ---   WORKS OK


            List<int> listOfScores = new List<int> {};
            foreach (Player p in ListOfPlayers)
            {
                listOfScores.Add(p.Score);
            }

            
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;

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
                Console.WriteLine($"The winner is {listOfWinners[0].Name} !");
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
            #endregion

            Console.ResetColor();
            Console.WriteLine();
            Console.Write("Player");
            Console.SetCursorPosition(10, Console.CursorTop);
            Console.WriteLine("| Score");
            Console.WriteLine("----------------------");

            foreach (Player p in ListOfPlayers)
            {
                Console.Write($"{p.Name} ");
                Console.SetCursorPosition(10, Console.CursorTop);
                Console.WriteLine($"| {p.Score}");
                Console.WriteLine("----------------------");
            }

        }
        public static void PrintScoreBoard(List<Player> playersList)
        {
            Console.WriteLine("ScoreBoard");
            Console.WriteLine();
            
            foreach (Player p in playersList)
            {
                int scoreView = p.Score / 2;
                
                Console.Write($"Player {playersList.IndexOf(p)+1}  ");
                if (scoreView == 0)
                {
                    Console.WriteLine();
                }
                else
                {
                    for (int i = 0; i <= scoreView-1; i++)
                    {
                        Console.Write("|");
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }
        public static void ClearPreviousLine()
        {
            
            Console.SetCursorPosition(0, Console.CursorTop-1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
        }
    }
    
}
