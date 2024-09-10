/*Creating a simon says game where a color out of 4 flashes and the user has to choose the color(s) that flashed in the same order.
Failure to do so will result in the game ending.*/

Random myRand = new Random();

int[] colorSequence = new int[10];
string[] nums = new string[10];

for (int idx = 0; idx < 9; idx++)
{
    colorSequence[idx] = myRand.Next(1, 5);
};
for (int trial = 0; trial < 5; trial++)
{
    
    for (int idx = 0; idx < 9; idx++)
    { 
        ConsoleColor color;
        color = colorSequence[idx] switch
        {
            1 => ConsoleColor.Blue,
            2 => ConsoleColor.Yellow,
            3 => ConsoleColor.Red,
            4 => ConsoleColor.Green

        };

        Console.BackgroundColor = color;
        Console.WriteLine("            \n            \n            ");
        nums[idx] = Convert.ToString(color);
        Thread.Sleep(1000);
        Console.Clear();
    };
    
    Console.WriteLine("Show your smarts!");
    for (int guess = 0; guess < 9; guess++)
    {
        string[] guesses = new string[10];
        guesses[guess] = Console.ReadLine();
        if (nums[guess] != guesses[guess])
        {
            Console.WriteLine("Too bad!");
            break;
        }
    }
}

