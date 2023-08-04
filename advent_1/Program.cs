namespace advent_1;
class Program
{
    static void Main(string[] args)
    {
        string[] stringelves = System.IO.File.ReadAllText("input.txt").Split("\n\n");
        Dictionary<int, int> elves = new();

        for (int i = 0; i < stringelves.Count(); i++)
        {
            int calories = 0;
            foreach (string line in stringelves[i].Split("\n"))
            {
                calories += Int32.Parse(line);
            }

            elves.Add(i, calories);
        }

        foreach (KeyValuePair<int, int> elf in elves.OrderBy(key => key.Value))
        {
            Console.WriteLine(elf.Key + " - " + elf.Value);
        }

        Console.WriteLine(elves[188] + elves[84] + elves[185]);
    }
}
