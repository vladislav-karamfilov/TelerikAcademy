using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

class MinimumSpanningTree
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the minimum spanning tree for a weighted graph***");
        Console.WriteLine("---Finds the minimal cost for cables that is needed to connect houses in");
        Console.WriteLine("several streets---");
        Console.Write(decorationLine);

        ICollection<Path> neighbourhood = GetNeighbourhood();

        ICollection<Path> minSpanningTree = GetMinimumSpanningTree(neighbourhood);

        long minCost = 0;
        Console.WriteLine("All paths that form the minimum spanning tree are:");
        foreach (Path path in minSpanningTree)
        {
            Console.WriteLine(path);
            minCost += path.Distance;
        }

        Console.WriteLine("The minimal cost is: {0}", minCost);
    }

    static ICollection<Path> GetMinimumSpanningTree(ICollection<Path> neighbourhood)
    {
        OrderedBag<Path> minimumSpanningTree = new OrderedBag<Path>();
        List<HashSet<House>> vertexSets = GetSetsWithOneVertex(neighbourhood);
        foreach (Path path in neighbourhood)
        {
            HashSet<House> startHouseGroup = GetVertexSet(path.StartHouse, vertexSets);
            HashSet<House> endHouseGroup = GetVertexSet(path.EndHouse, vertexSets);
            if (startHouseGroup == null)
            {
                minimumSpanningTree.Add(path);
                if (endHouseGroup == null)
                {
                    HashSet<House> newVertexSet = new HashSet<House>();
                    newVertexSet.Add(path.StartHouse);
                    newVertexSet.Add(path.EndHouse);
                    vertexSets.Add(newVertexSet);
                }
                else
                {
                    endHouseGroup.Add(path.StartHouse);
                }
            }
            else
            {
                if (endHouseGroup == null)
                {
                    startHouseGroup.Add(path.EndHouse);
                    minimumSpanningTree.Add(path);
                }
                else if (startHouseGroup != endHouseGroup)
                {
                    startHouseGroup.UnionWith(endHouseGroup);
                    vertexSets.Remove(endHouseGroup);
                    minimumSpanningTree.Add(path);
                }
            }
        }

        return minimumSpanningTree;
    }

    static List<HashSet<House>> GetSetsWithOneVertex(ICollection<Path> neighbourhood)
    {
        List<HashSet<House>> allSetsWithOneVertex = new List<HashSet<House>>();
        foreach (var path in neighbourhood)
        {
            bool startHouseToBeAdded = true;
            bool endHouseToBeAdded = true;
            foreach (var set in allSetsWithOneVertex)
            {
                if (startHouseToBeAdded && set.Contains(path.StartHouse))
                {
                    startHouseToBeAdded = false;        
                }

                if (endHouseToBeAdded && set.Contains(path.EndHouse))
                {
                    endHouseToBeAdded = false;        
                }

                if (!startHouseToBeAdded && !endHouseToBeAdded)
                {
                    break;
                }
            }

            if (startHouseToBeAdded)
            {
                HashSet<House> newSet = new HashSet<House>();
                newSet.Add(path.StartHouse);
                allSetsWithOneVertex.Add(newSet);
            }
            
            if (endHouseToBeAdded)
            {
                HashSet<House> newSet = new HashSet<House>();
                newSet.Add(path.EndHouse);
                allSetsWithOneVertex.Add(newSet);
            }
        }

        return allSetsWithOneVertex;
    }

    static ICollection<Path> GetNeighbourhood()
    {
        OrderedBag<Path> neighbourhood = new OrderedBag<Path>();

        neighbourhood.Add(new Path(new House("1"), new House("2"), 2));
        neighbourhood.Add(new Path(new House("1"), new House("3"), 22));
        neighbourhood.Add(new Path(new House("1"), new House("10"), 7));
        neighbourhood.Add(new Path(new House("2"), new House("10"), 12));
        neighbourhood.Add(new Path(new House("2"), new House("9"), 4));
        neighbourhood.Add(new Path(new House("2"), new House("3"), 1));
        neighbourhood.Add(new Path(new House("3"), new House("5"), 7));
        neighbourhood.Add(new Path(new House("4"), new House("3"), 9));
        neighbourhood.Add(new Path(new House("10"), new House("8"), 12));
        neighbourhood.Add(new Path(new House("8"), new House("6"), 17));
        neighbourhood.Add(new Path(new House("8"), new House("7"), 8));
        neighbourhood.Add(new Path(new House("5"), new House("7"), 9));
        neighbourhood.Add(new Path(new House("6"), new House("5"), 18));
        neighbourhood.Add(new Path(new House("4"), new House("5"), 7));
        neighbourhood.Add(new Path(new House("4"), new House("6"), 13));
        neighbourhood.Add(new Path(new House("4"), new House("9"), 4));
        neighbourhood.Add(new Path(new House("8"), new House("9"), 5));
        neighbourhood.Add(new Path(new House("4"), new House("8"), 6));
        
        //neighbourhood.Add(new Path(new House("1"), new House("2"), 1));
        //neighbourhood.Add(new Path(new House("4"), new House("1"), 2));
        //neighbourhood.Add(new Path(new House("2"), new House("3"), 3));
        //neighbourhood.Add(new Path(new House("2"), new House("5"), 13));
        //neighbourhood.Add(new Path(new House("4"), new House("3"), 4));
        //neighbourhood.Add(new Path(new House("3"), new House("6"), 3));
        //neighbourhood.Add(new Path(new House("4"), new House("6"), 16));
        //neighbourhood.Add(new Path(new House("4"), new House("7"), 14));
        //neighbourhood.Add(new Path(new House("5"), new House("6"), 12));
        //neighbourhood.Add(new Path(new House("5"), new House("8"), 1));
        //neighbourhood.Add(new Path(new House("5"), new House("9"), 13));
        //neighbourhood.Add(new Path(new House("6"), new House("7"), 1));
        //neighbourhood.Add(new Path(new House("6"), new House("9"), 1));

        return neighbourhood;
    }

    static HashSet<House> GetVertexSet(House vertex, List<HashSet<House>> vertexSets)
    {
        foreach (var vertexSet in vertexSets)
        {
            if (vertexSet.Contains(vertex))
            {
                return vertexSet;
            }
        }

        return null;
    }
}

/// <summary>
/// Represents a node in the graph
/// </summary>
struct House
{
    public House(string id)
        : this()
    {
        this.ID = id;
    }

    public string ID { get; private set; }

    public override string ToString()
    {
        return this.ID;
    }

    public override bool Equals(object obj)
    {
        return this.ID.Equals(((House)obj).ID);
    }

    public override int GetHashCode()
    {
        return this.ID.GetHashCode();
    }
}

/// <summary>
/// Represents an edge in the graph
/// </summary>
class Path : IComparable<Path>
{
    public Path(House startHouse, House endHouse, int distance)
    {
        this.StartHouse = startHouse;
        this.EndHouse = endHouse;
        this.Distance = distance;
    }

    public House StartHouse { get; private set; }

    public House EndHouse { get; private set; }

    public int Distance { get; private set; }

    public int CompareTo(Path other)
    {
        return this.Distance.CompareTo(other.Distance);
    }

    public override string ToString()
    {
        return string.Format("({0}, {1}) -> {2}", this.StartHouse, this.EndHouse, this.Distance);
    }
}
