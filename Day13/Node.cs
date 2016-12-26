using System;

namespace Day13
{
    class Node
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int fScore = 0;

        public Node(int x, int y)
        {
            X = x;
            Y = y;
        }

        public char DrawCoordinates(int favourite)
        {
            int sum = X * X + 3 * X + 2 * X * Y + Y + Y * Y + favourite;
            string binary = Convert.ToString(sum, 2);
            int counter = 0;
            foreach (char c in binary)
                if (c == '1')
                    counter++;

            return (counter % 2 == 0) ? ' ' : '#';
        }

        public override bool Equals(object obj)
        {
            if (((Node)obj).X == this.X && ((Node)obj).Y == this.Y)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            string xy = X.ToString() + "." + Y.ToString();
            return xy.GetHashCode();
        }
    } //Node
} //namespace
