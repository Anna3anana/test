using System;
using System.Collections.Generic;

namespace GridMoves
{
    /// <summary>
    /// 2020-04-20 by Anna Eliasson
    /// Test console app for Skymill.
    /// </summary>

    static class InputHandler
    {
        public static List<int> GetInputs()
        {
            Console.WriteLine("Skymill Test. Create grid (m,n) and add your starting position(x,y). Fill in as such: m,n,x,y");

            string value = Console.ReadLine();
            string[] array = value.Split(',');

            int n, m, x, y;
            // Quick validation of input being integers.
            var nSuccess = int.TryParse(array[0], out n);
            var mSuccess = int.TryParse(array[1], out m);
            var xSuccess = int.TryParse(array[2], out x);
            var ySuccess = int.TryParse(array[3], out y);

            if (x > n || y > m)
            {
                Console.WriteLine("x and y has to be inside the grid of m and n");
                return null;
            }
            if (!nSuccess || !mSuccess || !xSuccess || !ySuccess)
            {
                Console.WriteLine("You did not put in an integer, please put in an integer.");
                return null;
            }
            return new List<int>(new int[] { n, m, x, y });
        }
    }
}
