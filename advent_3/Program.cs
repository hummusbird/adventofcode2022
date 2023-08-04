namespace advent_3;
class Program
{
    static void Main(string[] args)
    {
        string[] bags = System.IO.File.ReadAllLines("input.txt");

        List<int> matchingitems = new();

        foreach (string bag in bags)
        {
            string comp1 = bag[..(bag.Length / 2)];
            string comp2 = bag[(bag.Length / 2)..];

            char match = MatchChars(comp1, comp2);
            matchingitems.Add(GetPriority(match));
        }

        int sum = 0;

        foreach (int item in matchingitems)
        {
            sum += item;
        }

        Console.WriteLine(sum);
    }

    static char MatchChars(string comp1, string comp2) // find matching character in two strings
    {
        foreach (char ch1 in comp1)
        {
            foreach (char ch2 in comp2)
            {
                if (ch1 == ch2)
                {
                    return ch1;
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
