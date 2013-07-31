using System;
using System.Collections.Generic;
using System.Text;

class RiskWinsRiskLoses
{
    static void Main()
    {
        string initialConfiguration = Console.ReadLine();
        string targetConfiguration = Console.ReadLine();

        int forbiddenConfigurationsCount = int.Parse(Console.ReadLine());
        HashSet<string> forbiddenConfigurations = new HashSet<string>();
        for (int i = 0; i < forbiddenConfigurationsCount; i++)
        {
            forbiddenConfigurations.Add(Console.ReadLine());    
        }

        Console.WriteLine(GetMiminumPressesCount(initialConfiguration, targetConfiguration, forbiddenConfigurations));
    }

    static int GetMiminumPressesCount(string initialConfiguration, string targetConfiguration, HashSet<string> forbiddenConfigurations)
    {
        Queue<Tuple<string, int>> configurations = new Queue<Tuple<string, int>>();
        configurations.Enqueue(new Tuple<string, int>(initialConfiguration, 0));
        while (configurations.Count > 0)
        {
            Tuple<string, int> currentConfiguration = configurations.Dequeue();
            StringBuilder newConfiguration = new StringBuilder(currentConfiguration.Item1);
            for (int i = 0; i < 5; i++)
            {
                newConfiguration[i] = (char)(currentConfiguration.Item1[i] + 1);
                if (newConfiguration[i] > '9')
                {
                    newConfiguration[i] = '0';
                }

                string newConfigurationString = newConfiguration.ToString();
                if (!forbiddenConfigurations.Contains(newConfigurationString))
                {
                    if (newConfigurationString == targetConfiguration)
                    {
                        return currentConfiguration.Item2 + 1;
                    }

                    forbiddenConfigurations.Add(newConfigurationString);
                    configurations.Enqueue(new Tuple<string, int>(
                        newConfigurationString, currentConfiguration.Item2 + 1));
                }

                newConfiguration[i] = currentConfiguration.Item1[i];
            }

            for (int i = 0; i < 5; i++)
            {
                newConfiguration[i] = (char)(currentConfiguration.Item1[i] - 1);
                if (newConfiguration[i] < '0')
                {
                    newConfiguration[i] = '9';
                }

                string newConfigurationString = newConfiguration.ToString();
                if (!forbiddenConfigurations.Contains(newConfigurationString))
                {
                    if (newConfigurationString == targetConfiguration)
                    {
                        return currentConfiguration.Item2 + 1;
                    }

                    forbiddenConfigurations.Add(newConfigurationString);
                    configurations.Enqueue(new Tuple<string, int>(
                        newConfigurationString, currentConfiguration.Item2 + 1));
                }

                newConfiguration[i] = currentConfiguration.Item1[i];
            }
        }

        return -1;
    }
}
