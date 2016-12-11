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
    }
}
