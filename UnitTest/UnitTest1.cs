using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Day07Test()
        {
            foreach (var line in new[] {
                new KeyValuePair<string, bool> ("aba[bab]xyz", true),
                new KeyValuePair<string, bool> ("xyx[xyx]xyx", false),
                new KeyValuePair<string, bool> ("aaa[kek]eke", true),
                new KeyValuePair<string, bool> ("zazbz[bzb]cdb", true),
                new KeyValuePair<string, bool> ("sdeqalvkcrkrinxry[xezvqhybsiwnncuafq]wgmtvsnsbilzxdd[exabnsnnyiyrxkdd]wmtluopjkaunmyyogc[mcecujbnhewtxxny]fasqbsmncghkmvv", true ),
                new KeyValuePair<string, bool> ("wqkcjtsnsnrnoguze[qtkujvopoiwnsnyj]wjpnbkzsrkdmjwhk[myorbznqrnieutxbt]bivalvvdqsjssmgoin", true ),
                new KeyValuePair<string, bool> ("jcghfctceivcaiweue[eftngalnwvhjjsmznr]fawobojxajdxwqqzs[ooswxgrpxwyohdyruo]nmtyadyigbjerrgww[kawttctyrgxigajaicc]hmwgzbdzmeoyths", true ),
                new KeyValuePair<string, bool> ("cwvxqqouchaqwkhpcfz[elwmjtglbrbyxnyoyyd]nccylfdoyorjbdi", true )
            })
            {
                List<string> inside = new List<string>();
                List<string> outside = new List<string>();

                Day07.Program.Splitter(line.Key, inside, outside);
                bool actualResult = Day07.Program.IsValidSSL(inside, outside, line.Key);
                Assert.AreEqual(line.Value, actualResult);
            }
        }

        [TestMethod]
        public void Day09Test()
        {
            foreach (var line in new[] {
                new KeyValuePair<string, string> ("ADVENT", "ADVENT"),
                new KeyValuePair<string, string> ("A(1x5)BC", "ABBBBBC"),
                new KeyValuePair<string, string> ("(3x3)XYZ", "XYZXYZXYZ"),
                new KeyValuePair<string, string> ("A(2x2)BCD(2x2)EFG", "ABCBCDEFEFG"),
                new KeyValuePair<string, string> ("(6x1)(1x3)A", "(1x3)A"),
                new KeyValuePair<string, string> ("X(8x2)(3x3)ABCY", "X(3x3)ABC(3x3)ABCY"),
            })
            {
                string result = Day09.Program.Decompress(line.Key);
                Assert.AreEqual(line.Value, result);
            }
        }
    }
}
