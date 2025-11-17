using System.Drawing;
using System.Formats.Asn1;
using System.IO.Pipelines;
using System.Text;
using Microsoft.Identity.Client.Extensibility;

namespace CS
{
    class Program
    {
        static void Main(string[] args)
        {
            bool game_on = true;
            Random generator = new Random();
            while (game_on)
            {
                System.Console.WriteLine("Welcome to the Number Guessing Game!");
                System.Console.WriteLine("Please select the difficulty:");

                // Entering the choice & Initialize attempt
                int choice = 0, attempt = 0;
                string difficulty = "NONE";
                while (difficulty == "NONE")
                {
                    try
                    {
                        System.Console.WriteLine("1. Easy (10 Chances)");
                        System.Console.WriteLine("2. Medium (5 Chances)");
                        System.Console.WriteLine("3. Hard (3 Chances)");
                        System.Console.Write("\nEnter your choice: ");
                        choice = Convert.ToInt32(Console.ReadLine());
                        difficulty = choice switch
                        {
                            1 => "Easy",
                            2 => "Medium",
                            3 => "Hard",
                            _ => "NONE"
                        };

                        // Message of Selected Difficulty
                        System.Console.WriteLine($"\nGreat! You have selected the {difficulty} difficulty Level ");
                        System.Console.WriteLine("Let's start the game!\n");
                    }
                    catch (FormatException f)
                    {
                        System.Console.WriteLine(f.Message + "\n\n");
                        Thread.Sleep(1000);
                    }
                }

                // generates the Random Number
                int random_number = generator.Next(1, 101);

                // Setting the Number of life
                int life = choice switch
                {
                    1 => 10,
                    2 => 5,
                    3 => 3,
                    _ => 0
                };

                while (life != 0)
                {
                    System.Console.Write("Enter your guess: ");
                    int guess = Convert.ToInt32(Console.ReadLine());
                    attempt++;
                    StringBuilder result = new StringBuilder();
                    if (guess == random_number)
                    {
                        result.Clear();
                        result.Append($"Congratulations! You guessed the correct number in {attempt} attempts.\n");
                        System.Console.WriteLine(result);
                        break;
                    }
                    else if (guess > random_number)
                    {
                        result.Clear();
                        result.Append($"Incorrect! The number is less than {guess}.\n");
                    }
                    else
                    {
                        result.Clear();
                        result.Append($"Incorrect! The number is greater than {guess}.\n");
                    }
                    System.Console.WriteLine(result);
                    life--;
                }
                if(life == 0) System.Console.WriteLine("Sorry, you are out of attempt !\n");
                System.Console.WriteLine("Do you want to play again (y/n): ");
                char yn = Convert.ToChar(Console.ReadLine());
                game_on = yn == 'y';
            }

        }
    }
}