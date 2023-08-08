namespace advent_10;
class Program
{
    static void Main(string[] args)
    {
        string[] commands = File.ReadAllLines("input.txt");

        int cycle = 1;
        int x = 1;

        int[] interesting = new int[] { 20, 60, 100, 140, 180, 220 };
        int sum = 0;

        foreach (string command in commands)
        {
            cycle++; // noop and the addx both do one nothing cycle;

            if (interesting.Contains(cycle))
            {
                Console.WriteLine($"Cycle: {cycle} strength: {x * cycle}");
                sum += x * cycle;
            }

            if (command.StartsWith("addx"))
            {
                cycle++;
                x += int.Parse(command.Split(" ")[1]);

                if (interesting.Contains(cycle))
                {
                    Console.WriteLine($"Cycle: {cycle} strength: {x * cycle}");
                    sum += x * cycle;
                }
            }
        }

        Console.WriteLine(sum);
    }
}
