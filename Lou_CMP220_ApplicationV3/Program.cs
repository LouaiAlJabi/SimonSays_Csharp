//Creating a "Simon Says" style game. Blocks in different colors will appear and the player has to report the colors
//in the correct order.

using System.Net.NetworkInformation;

static int[] GeneratePattern(int x)
{
    //This method generates the pattern of colors that will be shown. It is random with every iteration.
    //Takes in the number of iterations and returns an array of integers to be presented as colors.
    int[] Color = { 1, 2, 4, 14 };
    Random rng = new Random();
    int[] trials = new int[x];
    for (int trial = 0; trial < trials.Length; trial++)
    {
        trials[trial] = Color[rng.Next(0, 4)];
    }
    return trials;
}

static void ShowPattern(int[] patterns, int trial)
{
    // The function converts an array of integers corresponding to colors and returns a block in that color.
    foreach (int pattern in patterns)
    {
        Console.ForegroundColor = (ConsoleColor)pattern;
        Console.WriteLine("########\n########\n########\n########");
        Thread.Sleep(1600 - trial * 80);
        Console.Clear();
        Thread.Sleep(500);
    };
}

static int[] PlayerInput()
{
    Console.WriteLine("Tell me what you saw mortal");
    string playerinput = Console.ReadLine();
    int[] inputnums = new int[playerinput.Length];

    for (int letter = 0; letter < playerinput.Length; letter++)
    {
        inputnums[letter] = playerinput[letter] switch
        {
            'r' => 4,
            'g' => 2,
            'y' => 14,
            'b' => 1,
             _ => 666
        };
    }
    return inputnums;
}

static bool Compare(int[] player, int[] pattern)
{
    if (player.Length != pattern.Length) return false;
    for (int i = 0; i < player.Length; i++)
    {
        if (player[i] != pattern[i]) return false;
    }
    return true;
}

static int Game(string playername)
{
    bool status = true;
    int score = 1;
    int trial = 4;
    Console.WriteLine($"Are you ready to face your fate, {playername}?");
    Console.ReadKey(true);
    Console.Clear();
    Thread.Sleep(200);

    while(status)
    {
        Console.Clear();
        Thread.Sleep(300);
        int[] pattern = GeneratePattern(trial);
        ShowPattern(pattern, trial);
        Console.ForegroundColor = ConsoleColor.White;
        Thread.Sleep(500);
        int[] playeranswer = PlayerInput();
        status = Compare(playeranswer, pattern);
        if (status)
        {
            score++;
            trial++;
        }
    }

    return (score - 1);
}

static string Greeting()
{
    Console.WriteLine("Hahaha! I am freed!! You have entered my layer and you shall be challenged. " +
        "I am going to challenge your brain with this memory game. you will be presented with fire balls " +
        "of different colors and you must tell me the colors of each fire ball in order. You shall present " +
        "Red by the letter r, Blue by the letter b, Green by the letter g, and Yellow by the letter y.");
    Console.WriteLine("Enter your name, condemned one");
    string playername = Console.ReadLine();
    return playername;
}

static void Score(int score, string playername)
{
    
    if (score >= 5)
    {

        Console.WriteLine("You've done admirably, " + playername + ", with a score of " + score +
            " You shall attempt an escape from my hell, I think you will be back here in no time.");
       
    }
    else
    {
        
        Console.WriteLine("What a pittyful attempt " + playername + ". A score as low as a "+ score + " shall condemn you in hell for " +
            "eternity. Enjoy burning HAHAHA!");
    }
}

string playername = Greeting();
Console.WriteLine($"Very well, {playername}. My gauntlet shall begin now.");
int score = Game(playername);
Score(score, playername);


