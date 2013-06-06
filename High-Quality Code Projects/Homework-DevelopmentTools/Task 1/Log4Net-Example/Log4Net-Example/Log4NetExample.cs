using log4net;
using log4net.Config;
using System;

class Log4NetExample
{
    private static readonly ILog logger =
           LogManager.GetLogger(typeof(Log4NetExample));

    static void Main()
    {
        BasicConfigurator.Configure();

        logger.Debug("Here is a debug log.");
        logger.Info("... and an Info log.");
        logger.Warn("... and a warning.");
        logger.Error("... and an error.");
        logger.Fatal("... and a fatal error.");
    }
}
