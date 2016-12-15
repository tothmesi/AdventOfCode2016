using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    class OutputBin : Node
    {
        public OutputBin(string id) : base(id)
        {
        }

        public override void AddNewChip(int newChip)
        {
            chips.Add(newChip);
        }
    }
}
