namespace advent_2_2;
class Program
{
    static void Main(string[] args)
    {
        string[] game = System.IO.File.ReadAllLines("input.txt");

        // A X 1 ROCK
        // B Y 2 PAPER
        // C Z 3 SCISSOR

        int P1_score = 0;
        int P2_score = 0;

        foreach (string round in game)
        {
            int P1_choice = ConvertTo123(round.Split(" ")[0]);
            int P2_choice = 0;
            string Ending = round.Split(" ")[1];

            if (Ending == "X") // LOSE (P1 WINS)
            {
                Console.WriteLine("P1 WINS");
                P2_choice = P1_choice - 1;
                if (P1_choice == 1) { P2_choice = 3; }
                P1_score += 6;

                Console.WriteLine($"P1 PLAYED {P1_choice}; P2 PLAYS {P2_choice} ");
            }

            else if (Ending == "Y") // DRAW
            {
                Console.WriteLine("DRAW");
                P2_choice = P1_choice;
                P1_score += 3;
                P2_score += 3;

                Console.WriteLine($"P1 PLAYED {P1_choice}; P2 PLAYS {P2_choice} ");
            }

            else if (Ending == "Z") // WIN (P2 WINS)
            {
                Console.WriteLine("P2 WINS");
                P2_choice = P1_choice + 1;
                if (P1_choice == 3) { P2_choice = 1; }
                P2_score += 6;

                Console.WriteLine($"P1 PLAYED {P1_choice}; P2 PLAYS {P2_choice} ");
            }

            P1_score += P1_choice;
            P2_score += P2_choice;

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }

        Console.WriteLine($"P1 SCORE: {P1_score}");
        Console.WriteLine($"P2 SCORE: {P2_score}");
    }

    static int ConvertTo123(string input)
    {
        if (input == "X" || input == "A") { return 1; }
        if (input == "Y" || input == "B") { return 2; }
        if (input == "Z" || input == "C") { return 3; }
        return 0;
    }
}