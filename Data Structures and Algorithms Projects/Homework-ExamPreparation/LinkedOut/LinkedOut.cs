using System;
using System.Collections.Generic;
using System.Text;

class LinkedOut
{
    static void Main()
    {
        Dictionary<string, List<string>> socialNetwork = new Dictionary<string, List<string>>();
        string userName = Console.ReadLine();
        socialNetwork.Add(userName, new List<string>());

        int numberOfConnections = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfConnections; i++)
        {
            string[] connection = Console.ReadLine().Split(' ');
            if (!socialNetwork.ContainsKey(connection[0]))
            {
                socialNetwork.Add(connection[0], new List<string>());
            }

            socialNetwork[connection[0]].Add(connection[1]);

            if (!socialNetwork.ContainsKey(connection[1]))
            {
                socialNetwork.Add(connection[1], new List<string>());
            }

            socialNetwork[connection[1]].Add(connection[0]);
        }

        Dictionary<string, int> calculatedDegrees = new Dictionary<string, int>();
        foreach (var user in socialNetwork)
        {
            calculatedDegrees.Add(user.Key, -1);
        }

        calculatedDegrees[userName] = 0;

        StringBuilder output = new StringBuilder();
        int numberOfContactsToCheck = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfContactsToCheck; i++)
        {
            output.AppendLine(GetConnectionDegree(socialNetwork, calculatedDegrees, userName, Console.ReadLine()));
        }

        Console.Write(output);
    }

    static string GetConnectionDegree(
        Dictionary<string, List<string>> socialNetwork,
        Dictionary<string, int> calculatedDegrees,
        string userName,
        string contactToCheck)
    {
        Queue<string> connectionDegrees = new Queue<string>();
        connectionDegrees.Enqueue(userName);
        if (!calculatedDegrees.ContainsKey(contactToCheck))
        {
            return "-1";
        }

        if (calculatedDegrees[contactToCheck] != -1)
        {
            return calculatedDegrees[contactToCheck].ToString();
        }

        while (connectionDegrees.Count > 0)
        {
            string currentUser = connectionDegrees.Dequeue();

            foreach (string contact in socialNetwork[currentUser])
            {
                if (calculatedDegrees[contact] == -1)
                {
                    calculatedDegrees[contact] = calculatedDegrees[currentUser] + 1;
                    if (contact == contactToCheck)
                    {
                        return calculatedDegrees[contact].ToString();
                    }
                }

                connectionDegrees.Enqueue(contact);
            }
        }

        return "-1";
    }
}