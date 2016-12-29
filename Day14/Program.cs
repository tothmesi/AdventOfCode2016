using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Day14
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyManager hasher = new KeyManager();
            Stopwatch run = new Stopwatch();

            //run.Start();
            string input = "jlmsuwbz";

            // PART 01
            int index = 0;
            List<int> keyIndexes = new List<int>();

            while (keyIndexes.Count < 64)
            {
                hasher.FindKey(index, input, keyIndexes);
                index++;
            }
            run.Stop();
            Console.WriteLine(run.ElapsedMilliseconds);
            Console.WriteLine(string.Join(",", keyIndexes));

            // PART 02
            int index2017 = 0;
            List<int> keyIndexes2017 = new List<int>();


            run.Start();
            while (keyIndexes2017.Count < 64)
            {
                hasher.FindKey2017(index2017, input, keyIndexes2017);
                index2017++;
            }

            run.Stop();
            Console.WriteLine(run.ElapsedMilliseconds);
            Console.ReadKey();
        }
    } //Program
} //namespace
