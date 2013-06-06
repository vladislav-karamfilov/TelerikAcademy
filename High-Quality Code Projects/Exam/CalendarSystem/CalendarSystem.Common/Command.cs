namespace CalendarSystem.Common
{
    using System;

    public struct Command
    {
        private const char CommandNameSeparator = ' ';
        private static readonly string[] CommandArgumentsSeparators = { "|" };

        public string Name { get; set; }

        public string[] Arguments { get; set; }

        public static Command Parse(string inputCommand)
        {
            int nameEndIndex = inputCommand.IndexOf(CommandNameSeparator);
            if (nameEndIndex == -1)
            {
                throw new FormatException(
                    string.Format("Invalid input command: {0}! Command cannot be 1 word!", inputCommand));
            }

            string commandName = inputCommand.Substring(0, nameEndIndex);
            string argumentsSubstring = inputCommand.Substring(nameEndIndex + 1);

            string[] commandArguments = argumentsSubstring.Split(
                CommandArgumentsSeparators, 
                StringSplitOptions.RemoveEmptyEntries);
            TrimArguments(commandArguments);

            Command command = new Command();
            command.Name = commandName;
            command.Arguments = commandArguments;
            return command;
        }

        private static void TrimArguments(string[] arguments)
        {
            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = arguments[i].Trim();
            }
        }
    }
}
