using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Day09
{
    class Program
    {
        static Regex markerReg = new Regex(@"\((\d+)x(\d+)\)");

        static void Main(string[] args)
        {

            using (StreamReader reader = new StreamReader(@"..\..\Day09-input.txt"))
            {
                string x = reader.ReadLine();
                string finalText = Decompress(x);

                Console.WriteLine(finalText.Length);
                Console.ReadKey();
            }
        }

        internal static string Decompress(string x)
        {
            string decompressed = "";

            for (int i = 0; i < x.Length; i++)
            {
                switch (x[i])
                {
                    case ' ':
                        continue;

                    case '(':
                        Match marker = markerReg.Match(x, i);
                        int nextIndex = i + marker.Length;

                        if (marker.Success)
                        {
                            int range = Convert.ToInt32(marker.Groups[1].Value);
                            int repeat = Convert.ToInt32(marker.Groups[2].Value);
                            string characters = "";

                            int counter = 0;
                            while (characters.Length < range)
                            {
                                if (x[nextIndex + counter] != ' ')
                                    characters += x[nextIndex + counter];
                                counter++;
                            }

                            for (int j = 0; j < repeat; j++)
                            {
                                decompressed += characters;
                            }
                            Console.WriteLine("index: {0}\n\rrange: {1}\n\rrepeat: {2}\n\rcharacters: {3}\n\rnextIndex: {4}\n\r", i, range, repeat, characters, nextIndex);

                            i = nextIndex + characters.Length-1;
                            Console.WriteLine("index ugrás után: {0}", i);

                            break;
                        }
                        else
                        {
                            continue;
                        }

                    default:
                        decompressed += x[i];
                        break;
                } //switch
            } //loop
            return decompressed;
        } 


    } // class
} //namespace
