using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    class Bot : Node
    {
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

        public override void AddNewChip(int newChip)
        {
            chips.Add(newChip);
            if (chips.Count == 2)
                PassChip();
        }

    }
}
