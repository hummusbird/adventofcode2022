namespace advent_8_2;
class Program
{
    static void Main()
    {
        string[] rows = File.ReadAllLines("input.txt");
        int highest_scenic_value = 0;

        for (int x = 1; x < rows.Length - 1; x++)
        {
            for (int y = 1; y < rows[x].Length - 1; y++)
            {
                int up = CountVisibleTrees(rows, x, y, -1, 0);
                int right = CountVisibleTrees(rows, x, y, 0, 1);
                int down = CountVisibleTrees(rows, x, y, 1, 0);
                int left = CountVisibleTrees(rows, x, y, 0, -1);

                int value = up * right * down * left;

                if (value > highest_scenic_value) { highest_scenic_value = value; }
            }
        }

        Console.WriteLine(highest_scenic_value);
    }

    static int CountVisibleTrees(string[] rows, int x, int y, int x_change, int y_change)
    {
        int height = (int)char.GetNumericValue(rows[x][y]);

        int visibletrees = 0;
        int nextheight = 0;

        int currentx = x;
        int currenty = y;

        while ((height > nextheight) && (rows.Length - 1 > currentx) && (currentx > 0) && (rows[0].Length - 1 > currenty) && (currenty > 0))
        {
            visibletrees++;
            nextheight = (int)char.GetNumericValue(rows[currentx + x_change][currenty + y_change]);
            currentx += x_change;
            currenty += y_change;
        }

        return visibletrees;
    }
}
