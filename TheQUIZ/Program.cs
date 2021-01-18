using System;
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

            #region AddingQuestions(3q commented out)
            ListOfQuestions.Add(new Question("Which of these data types is NOT exclusive to storing numbers?", "var", new string[4]{ "int", "var","double", "float"}));
            ListOfQuestions.Add(new Question("What is the equivalent for SQL data type bit?", "bool", new string[4] { "var", "get", "set", "bool" }));
            
            ListOfQuestions.Add(new Question("In SQL, what does the number in brackets after varchar(32) stand for?", "32 is the maximum length of varchar", new string[4] { "32 is the int used by the varchar method", "32 is the value of varchar", "32 is the length of varchar", "32 is the maximum length of varchar" }));
            ListOfQuestions.Add(new Question("Methods help developers reduce the __ of their code.", "size", new string[4] { "size", "speed", "errors", "all of the above" }));
            ListOfQuestions.Add(new Question("Which keyboard shortcut lets you start debugging your code?", "F5", new string[4] { "F5", "F9", "F10", "F11" }));
            
            #endregion


            Console.WriteLine("Welcome to C# QUIZ!");
            Console.Write("How many players will be playing?  ");
            int playerCount;
            bool isInputANumber= int.TryParse(Console.ReadLine(), out playerCount);
            while (!isInputANumber || playerCount == 0)
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
                "Each correct answer gives +10 points. \n" +
                "** Try to give your answer as quick as possible - saved time will be added to your score as a bonus!");
            Thread.Sleep(5000);
            Console.WriteLine();
            Console.WriteLine("The game will begin in ... ");
            
            

            #region Countdown

            int countdown = 5;
            Console.SetCursorPosition(30, Console.CursorTop-1);
            Console.Write(countdown);
            do
            {
                Thread.Sleep(1000);
                countdown--;
                Console.SetCursorPosition(30, Console.CursorTop);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(countdown);
            } while (countdown > 0);
            #endregion

            Console.ReadLine();

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
                Console.Write($"{(ListOfQuestions.IndexOf(q))+1}. ");
                q.PrintQnA();
                ConsoleKeyInfo cki;
              
                Console.WriteLine("*Press ENTER to take your turn\n" +
                    "");

                for (int y = 0; y < ListOfPlayers.Count; y++)
                {
                    
                    #region switchingTurns by ENTER
                    do
                    { 
                        cki = Console.ReadKey(true);
                    } while (cki.Key != ConsoleKey.Enter);
                    #endregion

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
                         p.AddScore(time);
                    }
                   /*else
                    {
                        Console.Write("False! ");
                        Console.WriteLine($"Your current score: {p.ViewScore()}");
                    }*/
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Correct answer : {q.CorrectAnswer}");
                Console.ResetColor();
                Console.WriteLine();
                PrintScoreBoard(ListOfPlayers);
                Console.ReadLine();

                Console.Clear();
            }

            #region WhoWon
            Console.WriteLine();

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
                Console.ResetColor();
                Console.WriteLine();
                PrintScoreBoard(ListOfPlayers);
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
            PrintScoreBoard(ListOfPlayers);
            
        }
        public static void PrintScoreBoard(List<Player> playersList) 
        { 
            Console.WriteLine("ScoreBoard");
            Console.WriteLine();
            
            Console.Write("Player# |   Name");
            Console.SetCursorPosition(20, Console.CursorTop);
            Console.WriteLine("| Score");
            Console.WriteLine("---------------------------|");

            foreach (Player p in playersList)
            {
                Console.Write($"Player {playersList.IndexOf(p) + 1}|  ");
                Console.Write($"{p.Name} ");
                Console.SetCursorPosition(20, Console.CursorTop);
                Console.WriteLine($"| {p.Score}");
                Console.WriteLine("---------------------------|");
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
