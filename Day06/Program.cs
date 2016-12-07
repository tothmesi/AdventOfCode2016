using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    class Program
    {
        static void Main(string[] args)
        {
            //PART 01
            string[] input = File.ReadAllLines(@"..\..\Day06-input.txt");
            char[][] positions = new char[input[0].Length][];
            string message = "";
            string realMessage = "";

            for (int j = 0; j < positions.Length; j++)
            {
                positions[j] = new char[input.Length];
            }

            for (int i = 0; i < input.Length; i++)
            {
                for (int k = 0; k < input[i].Length; k++)
                {
                    positions[k][i] = input[i][k];
                }
            }

            foreach (char[] x in positions)
            {
                message += x.GroupBy(item => item)
                    .OrderByDescending(g => g.Count())
                    .Select(g => g.Key)
                    .First();
            }

            //PART 02
            foreach (char[] x in positions)
            {
                realMessage += x.GroupBy(item => item)
                    .OrderBy(g => g.Count())
                    .Select(g => g.Key)
                    .First();
            }

            Console.WriteLine("PART 01 - Az üzenet: {0}",message);
            Console.WriteLine("PART 02 - A tényleges üzenet: {0}", realMessage);
            Console.ReadKey();
        }
    }
}
