using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace Guess_the_number_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("========== GUESS THE NUMBER ==========");

            Console.Write("Enter starting number: ");
            int rangeStart = ValidateInput();

            int rangeEnd;
            do
            {
                Console.Write("Enter ending number: ");
                rangeEnd = ValidateInput();

                if (rangeEnd <= rangeStart)
                    Console.WriteLine("Ending number must be GREATER than starting number!");
            }
            while (rangeEnd <= rangeStart);

            Console.Write("Enter number of lives: ");
            int lives = ValidateInput();

            Console.Clear();
            PlayGame(rangeStart, rangeEnd, lives);

            Console.WriteLine("\nPress ENTER to play again or ESC to quit...");
            var key = Console.ReadKey(true).Key;
            if (key != ConsoleKey.Escape)
                Start();
        }

        public static void PlayGame(int from, int to, int lives)
        {
            Random random = new Random();
            int answer = random.Next(from, to + 1);
            int remainingLives = lives;

            while (remainingLives > 0)
            {
                Console.WriteLine("========== GUESS THE NUMBER ==========");
                Console.WriteLine($"Range: {from} - {to}");
                Console.WriteLine($"Lives: {remainingLives}/{lives}");
                Console.Write("Enter your guess: ");

                int guess = ValidateInput();

                Console.Clear();

                if (guess == answer)
                {
                    Console.WriteLine(" Congratulations! You guessed it right!");
                    Console.WriteLine($"You had {remainingLives}/{lives} lives left.");
                    return;
                }

                remainingLives--;

                if (remainingLives == 0)
                {
                    Console.WriteLine("You lost! No lives left.");
                    Console.WriteLine($"The correct number was: {answer}");
                    return;
                }

                if (guess < answer)
                {
                    Console.WriteLine("Too low! Try a higher number.");
                }
                else
                {
                    Console.WriteLine("Too high! Try a lower number.");
                }

                Console.WriteLine($"Lives left: {remainingLives}/{lives}");
                Console.WriteLine("-------------------------------------\n");
            }
        }
        public static int ValidateInput()
        {
            while (true)
            {
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                    return number;

                Console.WriteLine("Invalid number! Please enter a valid integer:");
            }
        }
    }
}
