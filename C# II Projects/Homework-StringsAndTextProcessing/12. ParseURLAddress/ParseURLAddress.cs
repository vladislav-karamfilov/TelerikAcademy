using System;

class ParseURLAddress
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Parsing an URL address given in format [protocol]://[server]/[resource]***");
        Console.Write(decorationLine);
        Console.Write("Enter a valid URL address in the format described: ");
        string urlAddress = Console.ReadLine();
        try
        {
            // Extracting the protocol
            int serverSeparatorIndex = urlAddress.IndexOf(':');
            string protocol = urlAddress.Substring(0, serverSeparatorIndex);
            // Extracting the server
            int resourceSeparatorIndex = urlAddress.IndexOf('/', serverSeparatorIndex + 3); // "+3" for skipping "://"
            string server = urlAddress.Substring(serverSeparatorIndex + 3, resourceSeparatorIndex - serverSeparatorIndex - 3);
            // Extracting the resource -> the rest of the URL address
            string resource = urlAddress.Substring(resourceSeparatorIndex + 1);
            Console.WriteLine("Protocol: " + protocol);
            Console.WriteLine("Server: " + server);
            Console.WriteLine("Resource: " + resource);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("The input URL address is not in the format described!");
        }
    }
}
