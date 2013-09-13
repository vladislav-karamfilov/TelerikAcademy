namespace StringInAnotherApperancesService.Client
{
    using System;

    class ClientUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Consuming the service for getting the appearances count of a");
            Console.WriteLine("string in another string***");
            Console.Write(decorationLine);

            StringInAnotherApperancesServiceClient client = new StringInAnotherApperancesServiceClient();

            string originString = "aaa";
            string testString = "a";
            int appearancesCount = client.GetStringAppearancesInAnotherString(originString, testString);
            Console.WriteLine("The appearances of '{0}' in '{1}' are: {2}", testString, originString, appearancesCount);

            originString = "Pesho pesha hodi";
            testString = "gosho";
            appearancesCount = client.GetStringAppearancesInAnotherString(originString, testString);
            Console.WriteLine("The appearances of '{0}' in '{1}' are: {2}", testString, originString, appearancesCount);
        }
    }
}
