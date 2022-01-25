using System;

namespace csp_first
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ShowAppInfo();
            
            // Get player name
            Console.Write("Enter your username: ");
            var username = Console.ReadLine();
            Console.WriteLine("************************");

            Console.WriteLine("Welcome {0}, let's play a game...", username);

            while (true)
            {
                var randomNumber = GenerateRandomNumber();
                int? guess = 0;
                
                do
                {
                    guess = GetUserGuess();
                    if (guess == null) continue;

                    // Check if guess correct
                    if (guess == randomNumber)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Correct guess, you must be really smart");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong!!!!, please try again");
                    }
                
                    // Reset color
                    Console.ResetColor();
                
                } while (guess != randomNumber);
                
                Console.WriteLine("Do you want to play again (enter y to continue)?");
                var answer = Console.ReadLine()?.ToLower();

                if (answer != "y")
                {
                    Console.WriteLine("Goodbye, thank you for playing");
                    break;
                }
                
                Console.WriteLine("");
            }
        }

        private static void ShowAppInfo()
        {
            const string appName = "Number Guesser";
            const string appVersion = "1.0.0";
            const string appAuthor = "Festus";
            
            // Print title with cyan color
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appAuthor);
            
            // Reset text color
            Console.ResetColor();
        }

        static int? GetUserGuess()
        {
            try
            {
                Console.WriteLine("Guess a number between 1 and 10");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter a valid number");
                Console.ResetColor();
            }

            return null;
        }

        static int GenerateRandomNumber()
        {
            var random = new Random();
            return random.Next(1, 10);
        }
    }
}