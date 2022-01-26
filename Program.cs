using System;

namespace csp_first
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // PlayWithStrings();
            PlayWithNumbers();
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
        
        private static void PlayWithStrings()
        {
            var firstName = "Festus";
            var lastName = "Agboma";
            Console.WriteLine(firstName);
            
            // concat
            var fullName = firstName + " " + lastName;
            Console.WriteLine(fullName);
            
            // count
            Console.WriteLine(fullName.Length);
            Console.WriteLine(firstName.Length);
            Console.WriteLine(lastName.Length);
            
            // toUpper
            Console.WriteLine(firstName.ToUpper());
            
            // find
            Console.WriteLine(fullName.ToLower().Contains("festus"));
            
            // find with index
            Console.WriteLine(firstName[5]);
            
            // find index
            Console.WriteLine(firstName.ToLower().IndexOf('f'));

            var startIndex = fullName.ToLower().IndexOf("ag", StringComparison.Ordinal);
            Console.WriteLine(fullName.Substring(startIndex));
            Console.WriteLine(fullName.Substring(0, startIndex - 1));
        }

        private static void PlayWithNumbers()
        {
            var numOne = 30;
            var numTwo = 11.2;
            var numThree = 4;
            
            Console.WriteLine(numOne);
            Console.WriteLine(numTwo);
            
            Console.WriteLine(numOne + numTwo);
            Console.WriteLine(numOne * numTwo);
            
            Console.WriteLine(numOne / numTwo);
            Console.WriteLine(numOne / numThree);
            
            Console.WriteLine(--numThree);
            
            Console.WriteLine(Math.Pow(numThree, 2));
            Console.WriteLine(Math.Sqrt(numThree));
            
            Console.WriteLine(Math.Max(3, 10));
            Console.WriteLine(Math.Min(3, 10));
            
            Console.WriteLine(Math.Round(3.4));
        }
    }
}