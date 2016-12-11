using System;
using System.Collections.Generic;
using System.IO;


namespace Day07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PART 01
            string[] input = File.ReadAllLines(@"..\..\Day07-input.txt");
            int validCounter = 0;
            int validSSLCounter = 0;

            foreach (string x in input)
            {
                List<string> outside = new List<string>();
                List<string> inside = new List<string>();

                Splitter(x, inside, outside);

                if (IsValidTLS(inside, outside))
                    validCounter++;

                if (IsValidSSL(inside, outside, x))
                    validSSLCounter++;
            }

            Console.WriteLine("Valid - PART 1: {0}", validCounter);
            Console.WriteLine("Valid - PART 2: {0}", validSSLCounter);
            Console.ReadKey();
        }


        public static bool IsABBA(string text)
        {
            for (int i = 0; i < text.Length - 3; i++)
            {
                string actual = text.Substring(i, 4);
                if (actual[0] == actual[3] && actual[1] == actual[2] && actual[0] != actual[1])
                    return true;
            }
            return false;
        }

        public static bool IsValidTLS(List<string> inside, List<string> outside)
        {
            bool isABBAInside = false;
            bool isABBAOutside = false;
            foreach (string y in inside)
            {
                if (IsABBA(y))
                    isABBAInside = true;
            }

            foreach (string y in outside)
            {
                if (IsABBA(y))
                    isABBAOutside = true;
            }
            return (isABBAOutside && !isABBAInside);
        }

        //PART 02 

        public static bool IsValidSSL(List<string> inside, List<string> outside, string input)
        {
            List<string> aba = new List<string>();
            foreach (string x in outside)
            {
                for (int i = 0; i < x.Length - 2; i++)
                {
                    string actual = x.Substring(i, 3);
                    if (actual[0] == actual[2] && actual[0] != actual[1])
                        aba.Add(actual);
                }
            }

            foreach (string z in aba)
            {
                string bab = z[1].ToString() + z[0].ToString() + z[1].ToString();

                foreach (string y in inside)
                    if (y.Contains(bab))
                        return true;
            }
            return false;
        }

        public static void Splitter(string x, List<string> inside, List<string> outside)
        {
            string actual = "";

            for (int i = 0; i < x.Length; i++)
            {
                switch (x[i])
                {
                    case '[':
                        outside.Add(actual);
                        actual = "";
                        break;
                    case ']':
                        inside.Add(actual);
                        actual = "";
                        break;
                    default:
                        actual += x[i];
                        if (i == x.Length - 1)
                            outside.Add(actual);
                        break;
                }
            }
        }

    } //class Program
} //namespace

