using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

class SupermarketQueueDemo
{
    const string EndCommand = "End";
    const string AppendCommand = "Append";
    const string InsertCommand = "Insert";
    const string FindCommnad = "Find";
    const string ServeCommand = "Serve";
    const string OKMessage = "OK";
    const string ErrorMessage = "Error";

    static void Main()
    {
        StringBuilder output = new StringBuilder();
        string commandLine = Console.ReadLine();
        SupermarketQueue supermarketQueue = new SupermarketQueue();
        while (commandLine != EndCommand)
        {
            string[] command = commandLine.Split(' ');
            switch (command[0])
            {
                case AppendCommand:
                    supermarketQueue.Append(command[1]);
                    output.AppendLine(OKMessage);
                    break;
                case InsertCommand:
                    if (supermarketQueue.Insert(int.Parse(command[1]), command[2]))
                    {
                        output.AppendLine(OKMessage);
                    }
                    else
                    {
                        output.AppendLine(ErrorMessage);
                    }

                    break;
                case FindCommnad:
                    output.AppendFormat("{0}{1}", supermarketQueue.Find(command[1]), Environment.NewLine);
                    break;
                case ServeCommand:
                    var served = supermarketQueue.Serve(int.Parse(command[1]));
                    if (served != null)
                    {
                        output.AppendLine(string.Join(" ", served));
                    }
                    else
                    {
                        output.AppendLine(ErrorMessage);
                    }

                    break;
            }

            commandLine = Console.ReadLine();
        }

        Console.Write(output);
    }
}

class SupermarketQueue
{
    private readonly Bag<string> peopleByName =
        new Bag<string>();
    private readonly BigList<string> peopleByPosition =
        new BigList<string>();

    public int Find(string name)
    {
        return this.peopleByName.NumberOfCopies(name);
    }

    public void Append(string name)
    {
        this.Insert(this.peopleByPosition.Count, name);
    }

    public IEnumerable<string> Serve(int count)
    {
        if (count > this.peopleByPosition.Count || count < 0)
        {
            return null;
        }

        IList<string> toServe = new List<string>(this.peopleByPosition.Range(0, count));

        this.peopleByName.RemoveMany(toServe);
        this.peopleByPosition.RemoveRange(0, count);

        return toServe;
    }

    public bool Insert(int position, string name)
    {
        if (position > this.peopleByPosition.Count || position < 0)
        {
            return false;
        }

        this.peopleByName.Add(name);
        this.peopleByPosition.Insert(position, name);

        return true;
    }
}