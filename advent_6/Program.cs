namespace advent_6;
class Program
{
    static void Main(string[] args)
    {
        string input = System.IO.File.ReadAllText("input.txt");
        Console.WriteLine(FindStart(input));
    }

    static int FindStart(string input)
    {
        int LENGTH_OF_MARKER = 14; // set the length of marker you're looking for here

        for (int i = 0; i < input.Length; i++)
        {
            string sub = input.Substring(i, LENGTH_OF_MARKER);

            bool not_unique = false;

            foreach (char x in sub)
            {
                string temp = sub.Replace(char.ToString(x), string.Empty); // remove character once

                if (temp.Length <= LENGTH_OF_MARKER - 2) // if two characters removed, the string is not unique
                {
                    not_unique = true;
                }
            }

            if (not_unique == false) { return i + LENGTH_OF_MARKER; } // if the string has not had two characters removed ever, it IS unique
        }
        return -1;
    }
}
