using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Wintellect.PowerCollections;

class Tasks
{
    static OrderedBag<Task> tasks = new OrderedBag<Task>();

    static void Main()
    {
        int commandsCount = int.Parse(Console.ReadLine());
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < commandsCount; i++)
        {
            output.Append(ExecuteCommand(Console.ReadLine()));
        }

        Console.Write(output);
    }

    static string ExecuteCommand(string command)
    {
        int indexOfSpace = command.IndexOf(' ');
        if (indexOfSpace == -1)
        {
            if (tasks.Count > 0)
            {
                Task toSolve = tasks.GetFirst();
                tasks.Remove(toSolve);
                return toSolve.Name + Environment.NewLine;
            }
            else
            {
                return "Rest" + Environment.NewLine;
            }
        }
        else // Adding a new task
        {
            int indexOfSecondSpace = command.IndexOf(' ', indexOfSpace + 1);
            int complexity = int.Parse(command.Substring(indexOfSpace + 1, indexOfSecondSpace - indexOfSpace));
            string name = command.Substring(indexOfSecondSpace + 1);
            tasks.Add(new Task(complexity, name));
            return "";
        }
    }
}

class Task : IComparable<Task>
{
    public int Complexity { get; private set; }

    public string Name { get; private set; }

    public Task(int complexity, string name)
    {
        this.Complexity = complexity;
        this.Name = name;
    }

    public int CompareTo(Task other)
    {
        int complexityComparison = this.Complexity.CompareTo(other.Complexity);
        if (complexityComparison != 0)
        {
            return complexityComparison;
        }
        else
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
