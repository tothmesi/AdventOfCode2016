using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    class Program
    {
        /*DAY 04
        Finally, you come across an information kiosk with a list of rooms.Of course, the list is encrypted and full of decoy data, but the instructions to decode the list are barely hidden nearby.Better remove the decoy data first.
        Each room consists of an encrypted name (lowercase letters separated by dashes) followed by a dash, a sector ID, and a checksum in square brackets.
        A room is real (not a decoy) if the checksum is the five most common letters in the encrypted name, in order, with ties broken by alphabetization.For example:
        aaaaa-bbb-z-y-x-123[abxyz] is a real room because the most common letters are a(5), b(3), and then a tie between x, y, and z, which are listed alphabetically.
        a-b-c-d-e-f-g-h-987[abcde] is a real room because although the letters are all tied (1 of each), the first five are listed alphabetically.
        not-a-real-room-404[oarel] is a real room.
        totally-real-room-200[decoy] is not.
        Of the real rooms from the list above, the sum of their sector IDs is 1514.
        What is the sum of the sector IDs of the real rooms?*/

        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"..\..\Day04-input.txt");
            int checkSum = 0;

            foreach (string x in input)
            {
                string code = x.Substring(x.Length - 6, 5);
                int id = Convert.ToInt32(x.Substring(x.Length - 10, 3));
                string descriptionRaw = x.Substring(0, x.Length - 11);
                string description = descriptionRaw.Replace("-", "");
                SortedDictionary<char, int> characters = new SortedDictionary<char, int>();
                string codeBuilt = "";

                //Part 1 - Get the character counts
                int max = 1;
                for (int i = 0; i < description.Length; i++)
                {
                    int counter = 0;
                    for (int j = i + 1; j < description.Length; j++)
                    {
                        if (description[i] == description[j])
                            counter++;
                    }
                    if (!characters.ContainsKey(description[i]))
                        characters.Add(description[i], counter + 1);
                    if (counter + 1 > max)
                        max = counter + 1;
                }

                //Part 1 - Build code string
                for (int i = 0; i < characters.Count; i++)
                {
                    foreach (KeyValuePair<char, int> entry in characters)
                    {
                        if (entry.Value == max)
                            codeBuilt += entry.Key;
                        if (codeBuilt.Length == 5)
                            break;
                    }
                    max--;
                    if (code == codeBuilt)
                        checkSum += id;
                    if (codeBuilt.Length == 5)
                        break;
                }

                //Part 2 - Get room name
                string name = "";
                string alphabet = "abcdefghijklmnopqrstuvwxyz";
                

                foreach (char c in descriptionRaw)
                {
                    int index = 0;
                    if (c == '-')
                    {
                        name += " ";
                        continue;
                    }

                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        if (c == alphabet[j])
                        {
                            index = j;
                            break;
                        }
                    }
                    name += alphabet[(index + id) % alphabet.Length];
                    //id%alphabet.length az eltolás
                    //hányadikra pörgetődik ki


                    
                }
                if (name.Contains("north"))
                    Console.WriteLine("A North Pole szoba id-ja: {0}", id);
            }

            Console.WriteLine("A valódi szobák id összege: {0}", checkSum);
            Console.ReadKey();
        }
    }
}
