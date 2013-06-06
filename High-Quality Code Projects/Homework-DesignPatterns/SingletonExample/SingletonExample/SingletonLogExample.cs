namespace SingletonExample
{
    using System;

    class SingletonLogExample
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Example for 'Singleton' design pattern***");
            Console.Write(decorationLine);

            Logger.Instance.LogOnConsole("Hello, Singleton!");
        }
    }
}
