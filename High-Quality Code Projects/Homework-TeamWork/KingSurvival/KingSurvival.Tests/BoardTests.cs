namespace KingSurvival.Tests
{
    using System;
    using System.IO;
    using System.Text;
    using KingSurvival.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void TestBoard()
        {
            string inputCommands = string.Format(
                "kul{0}bdr{0}kul{0}bdl{0}kur{0}adr{0}kur{0}bdl{0}kur{0}bdl{0}kul{0}ddl{0}kul",
                Environment.NewLine);

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                using (StringReader stringReader = new StringReader(inputCommands))
                {
                    Console.SetIn(stringReader);

                    IEngine engine = new ConsoleEngine();
                    engine.Run();

                    char[] separators = Environment.NewLine.ToCharArray();
                    string consoleOutput = stringWriter.ToString();
                    string[] outputLines = consoleOutput.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    string expected = 
                        "    0 1 2 3 4 5 6 7" +
                        "    -----------------" +
                        "0 | A - B - C - D - |" +
                        "1 | - + - + - + - + |" +
                        "2 | + - + - + - + - |" +
                        "3 | - + - + - + - + |" +
                        "4 | + - + - + - + - |" +
                        "5 | - + - + - + - + |" +
                        "6 | + - + - + - + - |" +
                        "7 | - + - K - + - + |" +
                        "   -----------------";
                    int boardInitializationIndex = 11;
                    StringBuilder board = new StringBuilder();
                    for (int i = 0; i < boardInitializationIndex; i++)
                    {
                        board.Append(outputLines[i]);
                    }

                    string actual = board.ToString();
                    Assert.AreEqual<string>(expected, actual, "Board is not create correctly!");
                }
            }
        }
    }
}
