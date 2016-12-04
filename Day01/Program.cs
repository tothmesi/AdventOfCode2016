using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    /* DAY01
    Santa's sleigh uses a very high-precision clock to guide its movements, and the clock's oscillator is regulated by stars.Unfortunately, the stars have been stolen...by the Easter Bunny.To save Christmas, Santa needs you to retrieve all fifty stars by December 25th.
    Collect stars by solving puzzles.Two puzzles will be made available on each day in the advent calendar; the second puzzle is unlocked when you complete the first.Each puzzle grants one star. Good luck!
    You're airdropped near Easter Bunny Headquarters in a city somewhere. "Near", unfortunately, is as close as you can get - the instructions on the Easter Bunny Recruiting Document the Elves intercepted start here, and nobody had time to work them out further.
    The Document indicates that you should start at the given coordinates (where you just landed) and face North.Then, follow the provided sequence: either turn left(L) or right(R) 90 degrees, then walk forward the given number of blocks, ending at a new intersection.
    There's no time to follow such ridiculous instructions on foot, though, so you take a moment and work out the destination. Given that you can only walk on the street grid of the city, how far is the shortest path to the destination?*/

    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            int y = 0;

            List<int> movementX = new List<int>();
            List<int> movementY = new List<int>();
            string[] route;

            using (StreamReader stream = new StreamReader(@"..\..\Day01-input.txt"))
            {
                route = stream.ReadToEnd().Split(',');
            }

            int step = Convert.ToInt32(route[0].Substring(1));
            movementX.Add((route[0][0] == 'R') ? step : -step);

            for (int i = 0; i < route.Length; i++)
            {
                route[i] = route[i].Trim();
                step = Convert.ToInt32(route[i].Substring(1));

                if (i % 2 == 1)
                {
                    if (movementX.Last() >= 0)
                    {
                        movementY.Add((route[i][0] == 'R') ? -step : step);
                    }
                    else {
                        movementY.Add((route[i][0] == 'R') ? step : -step);
                    }
                }

                if (i % 2 == 0 && i != 0)
                {
                    if (movementY.Last() >= 0)
                    {
                        movementX.Add((route[i][0] == 'R') ? step : -step);
                    }
                    else {
                        movementX.Add((route[i][0] == 'R') ? -step : step);
                    }
                }
            }
            x = movementX.Sum();
            y = movementY.Sum();

            Console.WriteLine("X irányban: {0}, Y irányban: {1}", x, y);
            Console.WriteLine(Math.Abs(x) + Math.Abs(y));
            Console.ReadKey();
        }
    }
}
