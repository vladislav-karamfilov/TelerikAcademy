using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

class Energo
{
    static OrderedBag<Cable> cables = new OrderedBag<Cable>();
    static HashSet<HashSet<string>> townsSets = new HashSet<HashSet<string>>();

    static void Main()
    {
        int edgesCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < edgesCount; i++)
        {
            string[] edgeInfo = Console.ReadLine().Split(' ');
            Cable cable = new Cable(edgeInfo[0], edgeInfo[1], int.Parse(edgeInfo[2]));
            cables.Add(cable);
            AddToTownsSets(cable);
        }

        Console.WriteLine(GetMinimalCablesLength());
    }

    static long GetMinimalCablesLength()
    {
        long minCablesLength = 0;
        HashSet<string> startTownGroup = null;
        HashSet<string> endTownGroup = null;
        HashSet<string> newTownsSet = null;
        foreach (var cable in cables)
        {
            startTownGroup = GetTownsSet(cable.StartTown);
            endTownGroup = GetTownsSet(cable.EndTown);
            if (startTownGroup == null)
            {
                minCablesLength += cable.Length;
                if (endTownGroup == null)
                {
                    newTownsSet = new HashSet<string>();
                    newTownsSet.Add(cable.StartTown);
                    newTownsSet.Add(cable.EndTown);
                    townsSets.Add(newTownsSet);
                }
                else
                {
                    endTownGroup.Add(cable.StartTown);
                }
            }
            else
            {
                if (endTownGroup == null)
                {
                    startTownGroup.Add(cable.EndTown);
                    minCablesLength += cable.Length;
                }
                else if (startTownGroup != endTownGroup)
                {
                    startTownGroup.UnionWith(endTownGroup);
                    townsSets.Remove(endTownGroup);
                    minCablesLength += cable.Length;
                }
            }
        }

        return minCablesLength;
    }

    static HashSet<string> GetTownsSet(string town)
    {
        foreach (var set in townsSets)
        {
            if (set.Contains(town))
            {
                return set;
            }
        }

        return null;
    }

    static void AddToTownsSets(Cable cable)
    {
        bool startTownToBeAdded = true;
        bool endTownToBeAdded = true;
        foreach (var set in townsSets)
        {
            if (startTownToBeAdded && set.Contains(cable.StartTown))
            {
                startTownToBeAdded = false;
            }

            if (endTownToBeAdded && set.Contains(cable.EndTown))
            {
                endTownToBeAdded = false;
            }

            if (!startTownToBeAdded && !endTownToBeAdded)
            {
                break;
            }
        }

        if (startTownToBeAdded)
        {
            HashSet<string> newSet = new HashSet<string>();
            newSet.Add(cable.StartTown);
            townsSets.Add(newSet);
        }

        if (endTownToBeAdded)
        {
            HashSet<string> newSet = new HashSet<string>();
            newSet.Add(cable.EndTown);
            townsSets.Add(newSet);
        }
    }
}

/// <summary>
/// Represents an edge in the graph
/// </summary>
class Cable : IComparable<Cable>
{
    public Cable(string startHouse, string endHouse, int length)
    {
        this.StartTown = startHouse;
        this.EndTown = endHouse;
        this.Length = length;
    }

    public string StartTown { get; private set; }

    public string EndTown { get; private set; }

    public int Length { get; private set; }

    public int CompareTo(Cable other)
    {
        return this.Length.CompareTo(other.Length);
    }
}