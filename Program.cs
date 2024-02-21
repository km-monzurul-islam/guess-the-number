Console.WriteLine("Guess the random number between 1-100");
Console.WriteLine("======================================");

bool shallExit = false;
while (!shallExit)
{
    Console.ResetColor();
    ShowOption();
    Console.Write("-> ");
    string? userChoice = Console.ReadLine();
    switch(userChoice)
    {
        case "1":
            Play(10);
            break;
        case "2":
            Play(5);
            break;
        case "3":
            shallExit = true;
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect selection");
            break;
    }

}

void ShowOption()
{
    Console.WriteLine("Select difficulty setting:");
    Console.WriteLine("1. Easy: 10 attempts");
    Console.WriteLine("2. Hard: 5 attempts");
    Console.WriteLine("3. Exit Game");
}

void Play(int tryAmount)
{
    int numberOfPreviousAttempts = 0;
    List<int> previousGuesses = new List<int>();
    int randomNumber = new Random(DateTime.Now.Millisecond).Next(1, 101);
    bool gameOver = false;

    while (!gameOver)
    {
        Console.ResetColor();
        Console.Write("Your Guess: ");
        try
        {
            int guessedNumber = int.Parse(Console.ReadLine() ?? "");
            numberOfPreviousAttempts += 1;
            if(guessedNumber == randomNumber)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You Guessed the correct number {randomNumber} with {numberOfPreviousAttempts} attempts!!!");
                gameOver = true;
            }
            else if(numberOfPreviousAttempts == tryAmount)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"YOU LOSE!,The number was {randomNumber}");
                gameOver = true;
            }
            else
            {              
                if(guessedNumber > randomNumber)
                {
                    Console.WriteLine("Your guess is too high");
                }
                else
                {
                    Console.WriteLine("Your guess is too low");
                }
            }
            previousGuesses.Add(guessedNumber);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Number of previous attempts: {numberOfPreviousAttempts}");
            Console.Write("Your previous guesses: ");
            foreach(int i in previousGuesses)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("\n");
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}