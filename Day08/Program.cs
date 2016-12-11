using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Day08
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;

            char[,] display = new char[6, 50];
            for (int i = 0; i < display.GetLength(0); i++)
            {

                for (int j = 0; j < display.GetLength(1); j++)
                {
                    display[i, j] = '.';
                }
            }

            string[] input = File.ReadAllLines(@"..\..\Day08-input.txt");
            Regex rect = new Regex(@"rect (\d+)x(\d+)");
            Regex shiftRow = new Regex(@"rotate row y=(\d+) by (\d+)");
            Regex shiftColumn = new Regex(@"rotate column x=(\d+) by (\d+)");

            foreach (string x in input)
            {
                MatchCollection matches = rect.Matches(x);
                if (matches.Count > 0)
                {
                    int column = Convert.ToInt32(matches[0].Groups[1].Value);
                    int row = Convert.ToInt32(matches[0].Groups[2].Value);
                    Rectangle(display, row, column);
                    continue;
                }

                matches = shiftRow.Matches(x);
                if (matches.Count > 0)
                {
                    int row = Convert.ToInt32(matches[0].Groups[1].Value);
                    int offset = Convert.ToInt32(matches[0].Groups[2].Value);
                    ShiftRow(display, row, offset);
                    continue;
                }

                matches = shiftColumn.Matches(x);
                if (matches.Count > 0)
                {
                    int column = Convert.ToInt32(matches[0].Groups[1].Value);
                    int offset = Convert.ToInt32(matches[0].Groups[2].Value);
                    ShiftColumn(display, column, offset);
                    continue;
                }
            }


            for (int i = 0; i<display.GetLength(0); i++)
            {
                for (int j = 0; j < display.GetLength(1); j++)
                {
                    Console.Write(display[i, j]);
                    if (display[i, j] == '#')
                        counter++;
                }
                Console.Write("\n\r");
            }

            Console.WriteLine(counter);
            Console.ReadKey();

        }

        public static void ShiftRow(char[,] matrix, int row, int offset)
        {
            if (offset <= matrix.GetLength(1))
            {
                string actualRow = "";
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    actualRow += matrix[row, i];
                }
                actualRow = (actualRow.Substring(actualRow.Length - offset, offset) + actualRow.Substring(0, actualRow.Length - offset));
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    matrix[row, i] = actualRow[i];
                }

            }
            else
            {
                throw new Exception("Túl nagy offset!");
            }

        }

        public static void ShiftColumn(char[,] matrix, int column, int offset)
        {
            if (offset <= matrix.GetLength(0))
            {
                string actualColumn = "";
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    actualColumn += matrix[i, column];
                }

                actualColumn = (actualColumn.Substring(actualColumn.Length - offset, offset) + actualColumn.Substring(0, actualColumn.Length - offset));

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, column] = actualColumn[i];
                }

            }
            else
            {
                throw new Exception("Túl nagy offset!");
            }
        }

        public static void Rectangle(char[,] matrix, int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    matrix[i, j] = '#';
                }
            }
        }

    } //Program
} //namespace
