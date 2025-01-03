namespace NumberGuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Number Guessing Game!");
            Console.WriteLine("I'm thinking of a number between 1 and 100.");

            Random random = new Random();
            int number = random.Next(1, 101);
            int chances;
            int attempts = 0;

            Console.WriteLine("Please select the difficulty level:");
            Console.WriteLine("1. Easy (10 chances)");
            Console.WriteLine("2. Medium (5 chances)");
            Console.WriteLine("3. Hard (3 chances)");
            Console.Write("Enter your choice: ");

            string? difficulty = Console.ReadLine();

            // switch case
            chances = difficulty switch
            {
                "1" => 10, 
                "2" => 5,
                "3" => 3,
                _ => 5 // default
            };

            Console.WriteLine($"You have {chances} chances to guess the correct number.");
            Console.WriteLine("Let's start the game!");

            while (chances > 0)
            {
                Console.Write("Enter your guess: ");
                if (!int.TryParse(Console.ReadLine(), out int guess))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                attempts++;

                if (guess == number)
                {
                    Console.WriteLine($"Congratulations! You guessed the correct number in {attempts} attempts.");
                    return;
                }
                else if (guess > number)
                {
                    chances--;
                    Console.WriteLine($"Too high! The number is less than {guess}.");
                }
                else
                {
                    chances--;
                    Console.WriteLine($"Too low! The number is greater than {guess}.");
                }

                if (chances > 0)
                {
                    Console.WriteLine($"You have {chances} chances remaining.");
                }
            }

            Console.WriteLine($"Game Over! The number was {number}.");
        }
    }
}