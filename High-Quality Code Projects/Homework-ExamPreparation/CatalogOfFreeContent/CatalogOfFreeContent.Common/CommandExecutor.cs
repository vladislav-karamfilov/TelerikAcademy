namespace CatalogOfFreeContent.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            switch (command.Type)
            {
                case CommandType.AddBook:
                    ProcessAddCommand(catalog, ContentType.Book, command.Parameters, output);
                    break;

                case CommandType.AddMovie:
                    ProcessAddCommand(catalog, ContentType.Movie, command.Parameters, output);
                    break;

                case CommandType.AddSong:
                    ProcessAddCommand(catalog, ContentType.Song, command.Parameters, output);
                    break;

                case CommandType.AddApplication:
                    ProcessAddCommand(catalog, ContentType.Application, command.Parameters, output);
                    break;

                case CommandType.Update:
                    ProcessUpdateCommand(catalog, command, output);
                    break;

                case CommandType.Find:
                    ProcessFindCommand(catalog, command, output);
                    break;

                default:
                    throw new InvalidOperationException("Unknown command!");
            }
        }

        private static void ProcessAddCommand(
            ICatalog catalog,
            ContentType contentType,
            string[] parameters,
            StringBuilder output)
        {
            IContent contentItem = new ContentItem(contentType, parameters);
            catalog.Add(contentItem);
            output.AppendFormat("{0} added{1}", contentType, Environment.NewLine);
        }

        private static void ProcessFindCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            if (command.Parameters.Length != 2)
            {
                throw new ArgumentException("Invalid number of parameters for 'Find' command!");
            }

            int numberOfElementsToList = int.Parse(command.Parameters[1]);
            IEnumerable<IContent> foundContent = 
                catalog.GetListContent(command.Parameters[0], numberOfElementsToList);
            if (foundContent.Count() == 0)
            {
                output.AppendLine("No items found");
            }
            else
            {
                foreach (IContent content in foundContent)
                {
                    output.AppendLine(content.TextRepresentation);
                }
            }
        }

        private static void ProcessUpdateCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            if (command.Parameters.Length == 2)
            {
                int itemsUpdated = catalog.UpdateContent(command.Parameters[0], command.Parameters[1]);
                output.AppendFormat("{0} items updated{1}", itemsUpdated, Environment.NewLine);
            }
            else
            {
                throw new ArgumentException("Invalid number of parameters for 'Update' command!");
            }
        }
    }
}
