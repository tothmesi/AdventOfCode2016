using System;
using System.Collections.Generic;

namespace Day13
{
    class Program
    {
        static void Main(string[] args)
        {
            // PART 01 - Shortest path to (31,39)
            int favourite = 1364;
            List<Node> path = AStar(new Tuple<int, int>(1, 1), new Tuple<int, int>(31, 39), favourite);
            Console.WriteLine("A (31,39) pont {0} lépésből érhető el.",path.Count - 1);

            // PART 02 - Nodes within 50 steps
            List<Node> nodesWithin50 = new List<Node>();
            for (int i = 0; i < 51; i++)
            {
                for (int j = 0; j <=50-i; j++)
                {
                    Node current = new Node(i, j);
                    List<Node> currentPath = new List<Node>();
                    if (current.DrawCoordinates(favourite) == ' ')
                    {
                        currentPath = AStar(new Tuple<int, int>(1, 1), new Tuple<int, int>(i, j), favourite);

                        if (currentPath != null && currentPath.Count <= 51 && !nodesWithin50.Contains(current))
                            nodesWithin50.Add(current);
                    }
                }
            }

            Console.WriteLine("50 lépésből {0} csomópont érhető el.",nodesWithin50.Count);
            Console.WriteLine("A legrövidebb út az alábbi:\n\r");
            //Mátrix kirajzolása
            for (int i = 0; i < 35; i++)
            {
                string matrixLine = "";
                for (int j = 0; j < 51; j++)
                {
                    Node current = new Node(i, j);
                    if (path.Contains(current))
                        matrixLine += 'O';
                    else
                        matrixLine += current.DrawCoordinates(favourite);
                }
                Console.WriteLine(matrixLine);
            }
            Console.ReadKey();

        }

        public static List<Node> AStar(Tuple<int, int> start, Tuple<int, int> goal, int favourite)
        {
            Queue<Node> openSet = new Queue<Node>();
            HashSet<Node> closedSet = new HashSet<Node>();
            //Dictionary szerű adatszerkezet, a beletett elemeket hasheli és az alapján keres (O log(n))

            Dictionary<Node, int> gScore = new Dictionary<Node, int>();
            Node startingPoint = new Node(start.Item1, start.Item2);
            gScore.Add(startingPoint, 0);
            Dictionary<Node, int> fScore = new Dictionary<Node, int>();
            fScore.Add(startingPoint, CalculateHeuristic(start, goal));
            Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
            openSet.Enqueue(startingPoint);

            while (openSet.Count != 0)
            {
                Node current = openSet.Dequeue();
                if (current.X == goal.Item1 && current.Y == goal.Item2)
                    return ReconstructPath(cameFrom, current);

                closedSet.Add(current);

                //létrehozom a szomszédait
                List<Node> neighbors = new List<Node>();
                if (current.X != 0)
                    neighbors.Add(new Node(current.X - 1, current.Y));

                if (current.Y != 0)
                    neighbors.Add(new Node(current.X, current.Y - 1));

                neighbors.Add(new Node(current.X + 1, current.Y));
                neighbors.Add(new Node(current.X, current.Y + 1));


                //megkeresem a szomszédai közül a legjobb utat
                foreach (Node neighbor in neighbors)
                {
                    if (neighbor.DrawCoordinates(favourite) == '#')
                        continue;

                    if (closedSet.Contains(neighbor))
                        continue;

                    int tentativeGScore = gScore[current] + 1;

                    if (!openSet.Contains(neighbor))
                        openSet.Enqueue(neighbor);

                    //ez nem egy jobb út
                    else if (tentativeGScore >= gScore[neighbor])
                        continue;

                    //beállítom, hogy ezt a csomópontot honnan értem el
                    cameFrom[neighbor] = current;
                    gScore[neighbor] = tentativeGScore;
                    fScore[neighbor] = gScore[neighbor] + CalculateHeuristic(new Tuple<int, int>(neighbor.X, neighbor.Y), goal);
                }

            }
            return null;
        }

        private static List<Node> ReconstructPath(Dictionary<Node, Node> cameFrom, Node goal)
        {
            List<Node> path = new List<Node>();
            path.Add(goal);
            while (cameFrom.ContainsKey(goal))
            {
                goal = cameFrom[goal];
                path.Add(goal);
            }
            path.Reverse();
            return path;
        }

        public static int CalculateHeuristic(Tuple<int, int> current, Tuple<int, int> goal)
        {
            return Math.Abs(goal.Item1 - current.Item1) + Math.Abs(goal.Item2 - current.Item2);
        }
    }
}
