namespace advent_2;
class Program
{
    static void Main(string[] args)
    {
        string[] game = System.IO.File.ReadAllLines("test.txt");

        // A / X = ROCK    (1)
        // B / Y = PAPER   (2)
        // C / Z = SCISSOR (3)

        int P1_score = 0;
        int P2_score = 0;

        foreach (string round in game)
        {
            string P1_choice = round.Split(" ")[0];
            string P2_choice = ConvertToABC(round.Split(" ")[1]);

            if (P1_choice == P2_choice) // DRAW 
            {

            }
        }
    }

    static string ConvertToABC(string input)
    {
        if (input == "X") { return "A"; }
        if (input == "Y") { return "B"; }
        if (input == "Z") { return "C"; }
        return input;
    }

    static int ConvertToScore(string input)
    {
        if (input == "X") { return 1; }
        if (input == "Y") { return 2; }
        if (input == "Z") { return 3; }
        return 0;
    }
}
