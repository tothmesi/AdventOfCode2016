using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Day14
{
    class KeyManager
    {
        private MD5 md5 = MD5.Create();
        private Regex threeOfAKind = new Regex(@"(.)\1\1", RegexOptions.Compiled);
        private SortedDictionary<int, string> hashes = new SortedDictionary<int, string>();


        #region Tibi
        private string CalculateHashTibi(string input)

        {
            // step 1, calculate MD5 hash from input
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            return hash.ToHex();
        }

        #endregion

        private string CalculateHash(string input)

        {
            // step 1, calculate MD5 hash from input
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }

            return sb.ToString();
        }

        private string CalculateHash2017(string input)

        {
            StringBuilder sb = new StringBuilder();

            for (int c = 0; c < 2017; c++)
            {
                input = CalculateHash(input);
            }
            return input;
        }

        public void FindKey(int index, string input, List<int> keyIndexes)
        {
            string textThree = input + index;
            Match threeMatch = threeOfAKind.Match(CalculateHash(textThree));

            if (threeMatch.Success)
            {
                string fivePattern = "";
                for (int i = 0; i < 5; i++)
                {
                    fivePattern += threeMatch.Groups[1];
                }

                for (int i = index + 1; i < index + 1001; i++)
                {
                    string textFive = input + i;
                    int fiveMatch = CalculateHash(textFive).IndexOf(fivePattern);
                    if (fiveMatch > -1)
                    {
                        keyIndexes.Add(index);
                        return;
                    }
                }
            }
        }

        public void FindKey2017(int index, string input, List<int> keyIndexes)
        {
            string textThree = input + index;
            if (!hashes.ContainsKey(index))
                hashes[index] = CalculateHash2017(textThree);
            Match threeMatch = threeOfAKind.Match(hashes[index]);

            if (threeMatch.Success)
            {
                // build regex for five of a kind
                string fivePattern = "";
                for (int i = 0; i < 5; i++)
                {
                    fivePattern += threeMatch.Groups[1];
                }

                for (int i = index + 1; i < index + 1001; i++)
                {
                    if (!hashes.ContainsKey(i))
                    {
                        string textFive = input + i;
                        hashes[i] = CalculateHash2017(textFive);
                    }

                    int fiveMatch = hashes[i].IndexOf(fivePattern);
                    if (fiveMatch > -1)
                    {
                        keyIndexes.Add(index);
                        Console.WriteLine("{0}. index: {1}", keyIndexes.Count, index);
                        return;
                    }

                }

            }
        }

    }
}
