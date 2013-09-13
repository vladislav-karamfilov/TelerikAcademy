namespace DayOfWeekInBulgarianConsoleClient
{
    using System;
    using DayOfWeekInBulgarianConsoleClient.DayOfWeekInBulgarianService;

    class ClientUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Consuming the service for getting day of the week in Bulgarian***");
            Console.Write(decorationLine);

            DayOfWeekInBulgarianServiceClient client = new DayOfWeekInBulgarianServiceClient();
            
            DateTime currentDate = DateTime.Now;
            string currentDayOfWeekInBulgarian = client.GetDayOfWeekInBulgarianAsync(currentDate).Result;
            Console.WriteLine("Current day of week in Bulgarian is '{0}'", currentDayOfWeekInBulgarian);
            
            client.Close();
        }
    }
}
