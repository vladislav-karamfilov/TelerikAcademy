namespace CatalogOfFreeContent.UI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CatalogOfFreeContent.Common;

    public class ContentOfFreeContentDemo
    {
        private const string EndCommand = "End";

        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalog = new Catalog();

            ICommandExecutor commandExecutor = new CommandExecutor();
            IList<ICommand> commands = ReadInputCommands();
            foreach (ICommand item in commands)
            {
                commandExecutor.ExecuteCommand(catalog, item, output);
            }

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(output);
        }

        private static IList<ICommand> ReadInputCommands()
        {
            IList<ICommand> commands = new List<ICommand>();
            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine.Trim() == EndCommand)
                {
                    break;
                }

                commands.Add(new Command(inputLine));
            }

            return commands;
        }
    }
}
