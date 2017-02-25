using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            string doorId = "uqwqemis";
            char[] password = { '_', '_', '_', '_', '_', '_', '_', '_' };

            for (int i = 0; password.Contains('_'); i++)
            {
                int position;
                string hashInput = doorId + i;
                string hash = CalculateMD5Hash(hashInput);
                if (hash.Substring(0, 5) == "00000" && Char.IsDigit(hash[5]) && Convert.ToInt32(hash[5].ToString()) < 8)
                {
                    position = Convert.ToInt32(hash[5].ToString());
                    if (password[position] == '_')
                        password[position] = hash[6];

                    Console.WriteLine("OK, {0}, {1}, {2}", hash, hashInput, string.Join(",", password));
                }
            }

            Console.WriteLine(password);
            Console.ReadKey();
        }

        public static string CalculateMD5Hash(string input)

        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
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
    }
}
