using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day03
{
    /* DAY03
    Now that you can think clearly, you move deeper into the labyrinth of hallways and office furniture that makes up this part of Easter Bunny HQ.This must be a graphic design department; the walls are covered in specifications for triangles.
    Or are they?
    The design document gives the side lengths of each triangle it describes, but... 5 10 25? Some of these aren't triangles. You can't help but mark the impossible ones.
    In a valid triangle, the sum of any two sides must be larger than the remaining side.For example, the "triangle" given above is impossible, because 5 + 10 is not larger than 25.
    In your puzzle input, how many of the listed triangles are possible?*/

    class Program
    {
        static void Main(string[] args)
        {
            string[] designDocument = File.ReadAllLines(@"..\..\Day03-input.txt");
            int triangleCounter = 0;

            for (int i=0; i<designDocument.Length; i++)
            {
                designDocument[i]= designDocument[i].Trim();
                string regex = @"(\s)+";
                designDocument[i] = Regex.Replace(designDocument[i], regex, ",", RegexOptions.None);

                string[] actual = designDocument[i].Split(',');
                int[] sides = new int[3];
                for (int j = 0; j < actual.Length; j++)
                {
                    sides[j] = Convert.ToInt32(actual[j]);
                }

                if (!(sides[0] + sides[1] <= sides[2] || sides[0] + sides[2] <= sides[1] || sides[1] + sides[2] <= sides[0]))
                  triangleCounter++;
            }

            Console.WriteLine("Lehetséges háromszögek száma: {0}",triangleCounter);
            Console.ReadKey();
        }
    }
}
