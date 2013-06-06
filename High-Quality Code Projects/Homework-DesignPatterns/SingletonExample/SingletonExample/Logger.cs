namespace SingletonExample
{
    using System;

    public sealed class Logger
    {
        private static readonly Logger logger = new Logger();

        private Logger()
        {
        }

        public static Logger Instance
        {
            get { return logger; }
        }

        public void LogOnConsole(string message)
        {
            Console.WriteLine("Logged at {0} message: {1}", DateTime.Now.ToShortTimeString(), message);
        }
    }
}
