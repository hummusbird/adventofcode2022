namespace advent_3_2;
class Program
{
    static void Main()
    {
        string[] bags = System.IO.File.ReadAllLines("input.txt");

        int sum = 0;

        for (int i = 0; i < bags.Count(); i += 3)
        {
            sum += GetPriority(MatchChars(bags[i], bags[i + 1], bags[i + 2]));
        }

        Console.WriteLine(sum);
    }

    static char MatchChars(string comp1, string comp2, string comp3) // find matching character in three strings
    {
        foreach (char ch1 in comp1)
        {
            foreach (char ch2 in comp2)
            {
                if (ch1 == ch2)
                {
                    foreach (char ch3 in comp3)
                    {
                        if (ch1 == ch3) { return ch3; }
                    }
                }
            }
        }

        return '0';
    }

    static int GetPriority(char ch) // convert character to priority
    {

        if ((int)ch < 91)
        {
            return (int)ch - 38; // return ASCII value - 38, offsets A to 27
        }
        else
        {
            return (int)ch - 96; // return ASCII value - 96, offsets a to 1
        }
    }
}
