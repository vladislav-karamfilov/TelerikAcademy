using System;
using System.Net;

class DownloadingFile
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Downloading a file from Internet and storing it in the current directory***");
        Console.Write(decorationLine);
        WebClient webClient = new WebClient();
        try
        {
            string remoteUri = "http://www.telerik.com/images/newsletters/academy/assets/";
            string fileName = "ninja-top.gif";
            string fullFilePathOnWeb = remoteUri + fileName;
            webClient.DownloadFile(fullFilePathOnWeb, fileName);
            Console.WriteLine("Downloading '{0}' from {1} is completed!", fileName, remoteUri);
            Console.WriteLine("You can find it in {0}.", Environment.CurrentDirectory);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("No file address is given!");
        }
        catch (WebException webException)
        {
            Console.WriteLine(webException.Message);
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Downloading a file is in process! Cannot download multiple \nfiles simultaneously!");
        }
        finally
        {
            webClient.Dispose();
        }
    }
}
