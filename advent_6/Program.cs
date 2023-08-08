namespace advent_6;
class Program
{
    static void Main(string[] args)
    {
        int LENGTH_OF_MARKER = 14; // set the length of marker you're looking for here
        string input = File.ReadAllText("input.txt");

        for (int i = 0; i < input.Length; i++)
        {
            string sub = input.Substring(i, LENGTH_OF_MARKER);
            string distinct = new(sub.Distinct().ToArray());
            // if the string has any duplicates, they will be removed and the length of string will change.
            if (distinct.Length == sub.Length) { Console.WriteLine(i + LENGTH_OF_MARKER); Environment.Exit(1); }
        }
    }
}
