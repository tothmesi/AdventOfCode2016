using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            // utasítások feldolgozása
            string[] input = File.ReadAllLines(@"..\..\Day10-input.txt");
            Regex initial = new Regex(@"value (\d+) goes to (bot \d+)");
            Regex passChip = new Regex(@"(bot \d+) gives low to (output \d+|bot \d+) and high to (output \d+|bot \d+)");
            List<Node> nodes = new List<Node>();
            List<Match> initialCommands = new List<Match>();

            foreach (string x in input)
            {
                // gráfot felépítő parancsok
                Match pass = passChip.Match(x);
                // kezdő értékeket meghatározó parancsok - melyik chipet melyik bot kapja először
                Match initialize = initial.Match(x);

                if (pass.Success)
                {
                    // ha nincs még ilyen ID-jú bot, példányosít egyet és beleteszi a botok listájába
                    string botId = pass.Groups[1].Value;
                    Bot actualBot = (Bot)nodes.FirstOrDefault(y => botId == y.Id);

                    if (actualBot == null)
                    {
                        actualBot = new Bot(botId);
                        nodes.Add(actualBot);
                    }

                    // beállítja a szomszédait, ha már léteznek, értékül adja, egyébként létrehozza, típusfüggően
                    string lowToId = pass.Groups[2].Value;
                    Node lowTo = nodes.FirstOrDefault(y => lowToId == y.Id);

                    if (lowTo == null)
                    {
                        if (lowToId.StartsWith("bot"))
                        {
                            lowTo = new Bot(lowToId);
                        }
                        else
                        {
                            lowTo = new OutputBin(lowToId);
                        }
                        nodes.Add(lowTo);
                    }
                    actualBot.lowTo = lowTo;

                    string highToId = pass.Groups[3].Value;
                    Node highTo = nodes.FirstOrDefault(y => highToId == y.Id);

                    if (highTo == null)
                    {
                        if (highToId.StartsWith("bot"))
                        {
                            highTo = new Bot(highToId);
                        }
                        else
                        {
                            highTo = new OutputBin(highToId);
                        }
                        nodes.Add(highTo);
                    }
                    actualBot.highTo = highTo;
                }

                if (initialize.Success)
                {
                    initialCommands.Add(initialize);
                }
            } //foreach

            // miután felépült a gráf, odaadja a chipeket
            foreach (Match x in initialCommands)
            {
                //chip: x.Groups[1].Value
                //cél: x.Groups[2].Value

                nodes.First(y => x.Groups[2].Value == y.Id).AddNewChip(Convert.ToInt32(x.Groups[1].Value));
            }

            // eredmények felolvasása
            string result = nodes.Where(x => x.chips.Contains(61) && x.chips.Contains(17)).Select(x => x.Id).FirstOrDefault();
            List<Node> outputs = nodes.Where(x => x is OutputBin && (x.Id == "output 0" || x.Id == "output 1" || x.Id == "output 2")).ToList();
            int multiply = outputs[0].chips[0] * outputs[1].chips[0] * outputs[2].chips[0];
            Console.WriteLine("Az adott bot: {0}",result);
            Console.WriteLine("A szorzat: {0}",multiply);
            Console.ReadKey();
        }

    } //class
} //namespace
