namespace CatalogOfFreeContent.Common
{
    using System;
    using System.Text;
    
    public class Command : ICommand
    {
        private static readonly char[] ParamsSeparators = { ';' };
        private static readonly char CommandEndSeparator = ':';

        private int commandNameEndIndex;

        public Command(string input)
        {
            this.OriginalForm = input.Trim();
            this.Parse();
        }

        public CommandType Type { get; set; }

        public string OriginalForm { get; set; }

        public string Name { get; set; }

        public string[] Parameters { get; set; }

        public CommandType ParseCommandType(string commandName)
        {
            if (commandName.Contains(CommandEndSeparator.ToString()) ||
                commandName.Contains(ParamsSeparators[0].ToString()))
            {
                throw new ArgumentException("Provided command name contains invalid symbols!");
            }

            string trimmedCommandName = commandName.Trim();
            switch (trimmedCommandName)
            {
                case "Add application":
                    return CommandType.AddApplication;
                    
                case "Add book":
                    return CommandType.AddBook;
                    
                case "Add movie":
                    return CommandType.AddMovie;
                    
                case "Add song":
                    return CommandType.AddSong;
                    
                case "Find":
                    return CommandType.Find;
                    
                case "Update":
                    return CommandType.Update;
         
                default:
                    throw new ArgumentException("Invalid command name provided: " + commandName);
            }
        }
        
        public string ParseName()
        {
            string name = this.OriginalForm.Substring(0, this.commandNameEndIndex + 1);
            return name;
        }

        public string[] ParseParameters()
        {
            int paramsLength = 
                this.OriginalForm.Length - (this.commandNameEndIndex + 3);

            string paramsOriginalForm = 
                this.OriginalForm.Substring(this.commandNameEndIndex + 3, paramsLength);

            string[] parameters = 
                paramsOriginalForm.Split(ParamsSeparators, StringSplitOptions.RemoveEmptyEntries);

            return parameters;
        }

        public int GetCommandNameEndIndex()
        {
            int endIndex = this.OriginalForm.IndexOf(CommandEndSeparator) - 1;
            return endIndex;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0} ", this.Name);

            foreach (string parameter in this.Parameters)
            {
                output.AppendFormat("{0} ", parameter);
            }

            return output.ToString();
        }

        private void TrimParams()
        {
            for (int i = 0; i < this.Parameters.Length; i++)
            {
                this.Parameters[i] = this.Parameters[i].Trim();
            }
        }

        private void Parse()
        {
            this.commandNameEndIndex = this.GetCommandNameEndIndex();

            this.Name = this.ParseName();

            this.Parameters = this.ParseParameters();
            this.TrimParams();

            this.Type = this.ParseCommandType(this.Name);
        }
    }
}
