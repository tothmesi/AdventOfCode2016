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

        public Node lowTo;
        public Node highTo;

        public List<int> chips = new List<int>();

        public abstract void AddNewChip(int chip);

    }
}
