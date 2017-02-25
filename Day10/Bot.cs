using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    // a botoknál legfeljebb 1 chip lehet, amint 2 van nála, továbbadja
    class Bot : Node
    {
        // chip továbbadása 
        // lowTo és highTo a szomszéd node-ok, base classból örökli
        public void PassChip( )
        {
            if (chips[0] > chips[1])
            {
                lowTo.AddNewChip(chips[1]);
                highTo.AddNewChip(chips[0]);
            }
            else
            {
                lowTo.AddNewChip(chips[0]);
                highTo.AddNewChip(chips[1]);
            }
        }

        public Bot(string id) : base(id)
        {
        }

        // akkor hívódik meg, amikor új chipet kap
        public override void AddNewChip(int newChip)
        {
            chips.Add(newChip);
            // amint 2 chip van nála, továbbadja őket
            if (chips.Count == 2)
                PassChip();
        }

    }
}
