namespace advent_8;
class Program
{
    static void Main(string[] args)
    {
        /*
        get each row into a list of keyvalue pairs of position vs height value
        take a substring from the left side to the tree in question
        sort, then if the tree ISNT the leftmost, it's not visible.

        instead of making a substring and sorting it, we can iterate through the entire sorted array and remove the trees that are before / after the intended tree.
        this resulting string's highest value should be a visible tree only.

        unfortunately, this does not exclude any trees of the same height.
        i can't figure how to fix that!
        */

        string[] filerows = System.IO.File.ReadAllLines("test.txt");

        List<List<KeyValuePair<string, int>>> rows = new(); // we want to store the position AND the value together, so we can sort by value later while still having accesible position

        for (int i = 0; i < filerows.Length; i++)
        {
            List<KeyValuePair<string, int>> trees = new();

            for (int j = 0; j < filerows[i].Length; j++)
            {
                KeyValuePair<string, int> tree = new(i + "," + j, (int)Char.GetNumericValue(filerows[i][j]));
                trees.Add(tree); // y,x as the key, and the height as the value in the trees dict
            }

            rows.Add(trees);
        }

        // the trees are now keypairs stored in in a list of dicts, so can be sorted and then checked for highest

        List<KeyValuePair<string, int>> visibletrees = new();

        foreach (List<KeyValuePair<string, int>> row in rows) // sorted horizontally
        {
            List<KeyValuePair<string, int>> sorted = row.OrderBy(x => x.Value).ToList();

            foreach (KeyValuePair<string, int> tree in row)
            {
                int x_var = Int32.Parse(tree.Key.Split(",")[1]);

                List<KeyValuePair<string, int>> r_sorted = sorted.ToList();
                List<KeyValuePair<string, int>> l_sorted = sorted.ToList();

                foreach (KeyValuePair<string, int> s_tree in sorted)
                {
                    if (Int32.Parse(s_tree.Key.Split(",")[1]) < x_var) { r_sorted.Remove(s_tree); } // remove anything lower (looking from the right) than the current tree
                    if (Int32.Parse(s_tree.Key.Split(",")[1]) > x_var) { l_sorted.Remove(s_tree); } // remove anything lower (looking from the left) than the current tree
                }

                r_sorted = r_sorted.DistinctBy(x => x.Value).ToList();
                l_sorted = l_sorted.DistinctBy(x => x.Value).ToList();

                // now we can use these two lists to check if our tree is visible, based on if it's the highest int the list

                if ((tree.Value == r_sorted[^1].Value && tree.Key == r_sorted[^1].Key) || (tree.Value == l_sorted[^1].Value && tree.Key == l_sorted[^1].Key)) // if is the last value in the list, is visible so should add to "visible trees" list
                {
                    visibletrees.Add(tree);
                }

                // // write tree heights visible from right
                // foreach (KeyValuePair<string, int> printtree in r_sorted) { Console.Write(printtree.Value); }
                // Console.WriteLine("");
            }

            // write all trees
            foreach (KeyValuePair<string, int> tree in row) { Console.Write(tree.Value); }
            Console.WriteLine("");

            // // write all positions
            // foreach (KeyValuePair<string, int> tree in row) { Console.Write($"({tree.Key})"); }
            // Console.WriteLine("");
        }

        foreach (KeyValuePair<string, int> row in rows[0]) // sorted vertically
        {
            int column = Int32.Parse(row.Key.Split(",")[1]); // get Y
            List<KeyValuePair<string, int>> sorted = rows.Select(x => x[column]).OrderBy(x => x.Value).ToList(); // sort by COLUMN instead of ROW

            foreach (KeyValuePair<string, int> tree in sorted)
            {
                int x_var = Int32.Parse(tree.Key.Split(",")[0]);

                List<KeyValuePair<string, int>> r_sorted = sorted.ToList();
                List<KeyValuePair<string, int>> l_sorted = sorted.ToList();

                foreach (KeyValuePair<string, int> s_tree in sorted) // CAN PROBABLY FIX THE BUG HERE:
                {
                    if (Int32.Parse(s_tree.Key.Split(",")[0]) < x_var) { r_sorted.Remove(s_tree); } // remove anything lower (looking from the bottom) than the current tree
                    if (Int32.Parse(s_tree.Key.Split(",")[0]) > x_var) { l_sorted.Remove(s_tree); } // remove anything lower (looking from the top) than the current tree
                }

                r_sorted = r_sorted.DistinctBy(x => x.Value).ToList();
                l_sorted = l_sorted.DistinctBy(x => x.Value).ToList();

                // now we can use these two lists to check if our tree is visible, based on if it's the highest int the list

                if ((tree.Value == r_sorted[^1].Value && tree.Key == r_sorted[^1].Key) || (tree.Value == l_sorted[^1].Value && tree.Key == l_sorted[^1].Key)) // if is the last value in the list, is visible so should add to "visible trees" list
                {
                    visibletrees.Add(tree);
                }

                // // write tree heights visible from bottom
                // foreach (KeyValuePair<string, int> printtree in r_sorted) { Console.Write(printtree.Value); }
                // Console.WriteLine("");
            }

            // // write all vertically sorted trees
            // foreach (KeyValuePair<string, int> tree in sorted) { Console.Write(tree.Value); }
            // Console.WriteLine("");
        }


        visibletrees = visibletrees.Distinct().ToList(); // remove any duplicates

        foreach (List<KeyValuePair<string, int>> row in rows)
        {
            foreach (KeyValuePair<string, int> tree in row)
            {
                Console.Write(visibletrees.Contains(tree) ? "#" : '.'); // show visible trees as # 
            }
            Console.WriteLine("");
        }

        Console.WriteLine("Visible Trees: " + visibletrees.Count);
    }
}
