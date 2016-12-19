using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"..\..\Day12-input.txt");

            //Registers
            Dictionary<string, int> registers = new Dictionary<string, int>();
            registers["a"] = 0;
            registers["b"] = 0;
            registers["c"] = 1;
            registers["d"] = 0;


            for (int i = 0; i < input.Length; i++)
            {
                string[] values = new string[2];
                string value;
                int number;
                int condition;
                switch (input[i].Substring(0, 3))
                {
                    case "cpy":
                        values = input[i].Substring(4).Split(' ');
                        if (!Int32.TryParse(values[0], out number))
                            number = registers[values[0]];

                        registers[values[1]] = number;
                        break;

                    case "inc":
                        value = input[i].Substring(4);
                        registers[value]++;
                        break;

                    case "dec":
                        value = input[i].Substring(4);
                        registers[value]--;
                        break;

                    case "jnz":
                        values = input[i].Substring(4).Split(' ');
                        if (!Int32.TryParse(values[0], out condition))
                            condition = registers[values[0]];

                        if (!Int32.TryParse(values[1], out number))
                            number = registers[values[1]];

                        if (condition != 0 && i + number >= 0)
                            i += number-1;
                        break;

                }
            }


            Console.WriteLine("A regiszterek értéke: a:{0}, b{1}, c{2}, d{3}",registers["a"], registers["b"], registers["c"], registers["d"]);
            Console.ReadKey();
        } //main
    } // class
} //namespace
