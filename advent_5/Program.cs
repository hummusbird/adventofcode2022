using System.Text.RegularExpressions;

namespace advent_5;
class Program
{
    static void Main(string[] args)
    {
        List<Char>[] stacks = new List<Char>[9];

        stacks[0] = new List<Char> { 'S', 'C', 'V', 'N' };
        stacks[1] = new List<Char> { 'Z', 'M', 'J', 'H', 'N', 'S' };
        stacks[2] = new List<Char> { 'M', 'C', 'T', 'G', 'J', 'N', 'D' };
        stacks[3] = new List<Char> { 'T', 'D', 'F', 'J', 'W', 'R', 'M' };
        stacks[4] = new List<Char> { 'P', 'F', 'H' };
        stacks[5] = new List<Char> { 'C', 'T', 'Z', 'H', 'J' };
        stacks[6] = new List<Char> { 'D', 'P', 'R', 'Q', 'F', 'S', 'L', 'Z' };
        stacks[7] = new List<Char> { 'C', 'S', 'L', 'H', 'D', 'F', 'P', 'W' };
        stacks[8] = new List<Char> { 'D', 'S', 'M', 'P', 'F', 'N', 'G', 'Z' };

        foreach (string instruction in System.IO.File.ReadAllLines("instructions.txt"))
        {
            string instr = Regex.Replace(instruction, "[^0-9 ]", "").Trim(); // turn instructions into three ints

            int amount = Int32.Parse(instr.Split("  ")[0]);
            int startstack = Int32.Parse(instr.Split("  ")[1]);
            int endstack = Int32.Parse(instr.Split("  ")[2]);

            List<char> temp = new();

            /* FOR CRATEMOVER 9000
            for (int i = 0; i < amount; i++)
            {
                Char pop = stacks[startstack - 1][^1]; // find last value in stack
                stacks[startstack - 1].RemoveAt(stacks[startstack - 1].Count - 1); // remove from stack
                stacks[endstack - 1].Add(pop); // add to endstack
            }
            */

            /* FOR CRATEMOVER 9001 */
            for (int i = 0; i < amount; i++)
            {
                Char pop = stacks[startstack - 1][^1]; // find last value in stack
                stacks[startstack - 1].RemoveAt(stacks[startstack - 1].Count - 1); // remove from stack
                temp.Add(pop); // add to tempstack
            }

            for (int i = temp.Count() - 1; i >= 0; i--) // add to stack from tempstack backwards
            {
                stacks[endstack - 1].Add(temp[i]);
            }
        }

        foreach (List<char> cratestack in stacks)
        {
            Console.Write(cratestack[^1]);
        }
    }
}
