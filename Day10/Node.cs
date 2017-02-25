using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    abstract class Node
    {
        public string Id { get; private set; }

        public Node(string id)
        {
            Id = id;
        }

        // kinek kell adnia a nála lévő kisebb és nagyobb chipet - gráf szomszédos node-jai
        public Node lowTo;
        public Node highTo;

        // nála lévő chipek listája
        public List<int> chips = new List<int>();

        public abstract void AddNewChip(int chip);

    }
}
