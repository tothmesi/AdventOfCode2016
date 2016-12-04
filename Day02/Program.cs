using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    class Program
    {
        /* DAY02
        You arrive at Easter Bunny Headquarters under cover of darkness.However, you left in such a rush that you forgot to use the bathroom! Fancy office buildings like this one usually have keypad locks on their bathrooms, so you search the front desk for the code.
        "In order to improve security," the document you find says, "bathroom codes will no longer be written down. Instead, please memorize and follow the procedure below to access the bathrooms."
        The document goes on to explain that each button to be pressed can be found by starting on the previous button and moving to adjacent buttons on the keypad: U moves up, D moves down, L moves left, and R moves right. Each line of instructions corresponds to one button, starting at the previous button (or, for the first line, the "5" button); press whatever button you're on at the end of each line. If a move doesn't lead to a button, ignore it.
        You can't hold it much longer, so you decide to figure out the code as you walk to the bathroom.*/

        static void Main(string[] args)
        {
            char[][] numPad = new char[3][];
            numPad[0] = new[] { '1', '2', '3' };
            numPad[1] = new[] { '4', '5', '6' };
            numPad[2] = new[] { '7', '8', '9' };

            string[] codes = File.ReadAllLines(@"..\..\Day02-input.txt");
            string entryCode = "";

            int row = 1;
            int column = 1;

            foreach (string x in codes)
            {
                SetNextIndex(x, numPad.Length, ref row, ref column);
                entryCode += (numPad[row][column]);
            }

            Console.WriteLine("A belépési jelszó: {0}", entryCode);
            Console.ReadKey();
        }

        public static void SetNextIndex(string code, int maxSize, ref int row, ref int column)
        {
            for (int i = 0; i < code.Length; i++)
            {
                switch (code[i])
                {
                    case 'U':
                        if (row > 0)
                            row--;
                        break;

                    case 'D':
                        if (row < maxSize - 1)
                            row++;
                        break;

                    case 'L':
                        if (column > 0)
                            column--;
                        break;
                    case 'R':
                        if (column < maxSize - 1)
                            column++;
                        break;

                    default:
                        Console.WriteLine("Nem megfelelő bemeneti adat!\n\r{0}", code);
                        break;
                }
            }
        }
    }
}
