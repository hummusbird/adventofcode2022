namespace advent_4;
class Program
{
    static void Main(string[] args)
    {
        int containsum = 0;
        int overlapsum = 0;
        foreach (string pair in System.IO.File.ReadAllLines("input.txt"))
        {
            int p1a = Int32.Parse(pair.Split(",")[0].Split("-")[0]);
            int p1b = Int32.Parse(pair.Split(",")[0].Split("-")[1]);
            int p2a = Int32.Parse(pair.Split(",")[1].Split("-")[0]);
            int p2b = Int32.Parse(pair.Split(",")[1].Split("-")[1]);

            if (p1a <= p2a && p1b >= p2b) { containsum++; }
            else if (p1a >= p2a && p1b <= p2b) { containsum++; }

            if (p2a >= p1a && p2a <= p1b) { overlapsum++; }
            else if (p1a >= p2a && p1a <= p2b) { overlapsum++; }
        }

        Console.WriteLine(containsum + " sets completely contain the other");
        Console.WriteLine(overlapsum + " sets overlap with the other");
    }
}
