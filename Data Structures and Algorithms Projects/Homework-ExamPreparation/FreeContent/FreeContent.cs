using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Wintellect.PowerCollections;

public class ContentOfFreeContentDemo
{
    private const string EndCommand = "End";

    public static void Main()
    {
        StringBuilder output = new StringBuilder();
        Catalog catalog = new Catalog();

        CommandExecutor commandExecutor = new CommandExecutor();
        IList<Command> commands = ReadInputCommands();
        foreach (Command item in commands)
        {
            commandExecutor.ExecuteCommand(catalog, item, output);
        }

        Console.Write(output);
    }

    private static IList<Command> ReadInputCommands()
    {
        IList<Command> commands = new List<Command>();
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

public class Command
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

public class CommandExecutor
{
    public void ExecuteCommand(Catalog catalog, Command command, StringBuilder output)
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
        Catalog catalog,
        ContentType contentType,
        string[] parameters,
        StringBuilder output)
    {
        ContentItem contentItem = new ContentItem(contentType, parameters);
        catalog.Add(contentItem);
        output.AppendFormat("{0} added{1}", contentType, Environment.NewLine);
    }

    private static void ProcessFindCommand(Catalog catalog, Command command, StringBuilder output)
    {
        int numberOfElementsToList = int.Parse(command.Parameters[1]);
        IEnumerable<ContentItem> foundContent =
            catalog.GetListContent(command.Parameters[0], numberOfElementsToList);
        if (foundContent.Count() == 0)
        {
            output.AppendLine("No items found");
        }
        else
        {
            foreach (ContentItem content in foundContent)
            {
                output.AppendLine(content.ToString());
            }
        }
    }

    private static void ProcessUpdateCommand(Catalog catalog, Command command, StringBuilder output)
    {
        int itemsUpdated = catalog.UpdateContent(command.Parameters[0], command.Parameters[1]);
        output.AppendFormat("{0} items updated{1}", itemsUpdated, Environment.NewLine);
    }
}

public enum CommandType
{
    AddApplication,
    AddBook,
    AddMovie,
    AddSong,
    Find,
    Update
}

public enum ContentInfoType
{
    Title = 0,
    Author = 1,
    Size = 2,
    Url = 3
}

public class ContentItem : IComparable<ContentItem>
{
    public ContentItem(ContentType type, string[] contentItemParams)
    {
        this.Type = type;
        this.Title = contentItemParams[(int)ContentInfoType.Title];
        this.Author = contentItemParams[(int)ContentInfoType.Author];
        this.Size = long.Parse(contentItemParams[(int)ContentInfoType.Size]);
        this.Url = contentItemParams[(int)ContentInfoType.Url];
    }

    public ContentType Type { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public long Size { get; set; }

    public string Url { get; set; }

    public override string ToString()
    {
        string output = string.Format(
            "{0}: {1}; {2}; {3}; {4}",
            this.Type.ToString(),
            this.Title,
            this.Author,
            this.Size,
            this.Url);

        return output;
    }

    public int CompareTo(ContentItem other)
    {
        return this.ToString().CompareTo(other.ToString());
    }
}

public enum ContentType
{
    Application,
    Book,
    Movie,
    Song
}

public class Catalog
{
    private readonly MultiDictionary<string, ContentItem> urls;
    private readonly OrderedMultiDictionary<string, ContentItem> titles;

    public Catalog()
    {
        bool allowDuplicateValues = true;
        this.titles = new OrderedMultiDictionary<string, ContentItem>(allowDuplicateValues);
        this.urls = new MultiDictionary<string, ContentItem>(allowDuplicateValues);
    }

    public void Add(ContentItem content)
    {
        this.titles.Add(content.Title, content);
        this.urls.Add(content.Url, content);
    }

    public IEnumerable<ContentItem> GetListContent(string title, int numberOfElementsToList)
    {
        var contentToList = this.titles[title];
        return contentToList.Take(numberOfElementsToList);
    }

    public int UpdateContent(string oldUrl, string newUrl)
    {
        IList<ContentItem> matchedElements = this.urls[oldUrl].ToList();

        this.urls.Remove(oldUrl);
        foreach (var content in matchedElements)
        {
            this.titles.Remove(content.Title, content);
        }

        foreach (ContentItem content in matchedElements)
        {
            content.Url = newUrl;
            this.Add(content);
        }

        return matchedElements.Count;
    }
}