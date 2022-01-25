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
            Console.WriteLine($"Welcome {username}, let's play a game...");

            while (true)
            {
                var randomNumber = GenerateRandomNumber();
                int? guess;
                
                do
                {
                    guess = GetUserGuess();
                    if (guess == null) continue;

                    // Check if guess correct
                    if (guess == randomNumber) PrintColoredMessage("Correct guess, you must be really smart", ConsoleColor.Green);
                    else PrintColoredMessage("Wrong!!!!, please try again", ConsoleColor.Red);

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
            PrintColoredMessage($"{appName}: Version {appVersion} by {appAuthor}", ConsoleColor.DarkCyan);
        }

        private static int? GetUserGuess()
        {
            try
            {
                Console.WriteLine("Guess a number between 1 and 10");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                PrintColoredMessage("Enter a valid number", ConsoleColor.Red);
            }

            return null;
        }

        private static int GenerateRandomNumber()
        {
            var random = new Random();
            return random.Next(1, 10);
        }

        private static void PrintColoredMessage(string message, ConsoleColor? color)
        {
            if (color != null) Console.ForegroundColor = (ConsoleColor) color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}