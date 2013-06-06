namespace KingSurvival.Tests
{
    using System;
    using System.IO;
    using KingSurvival.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MovementsTests
    {
        [TestMethod]
        public void TestPawnsMovements()
        {
            string inputCommands = string.Format(
                "kur{0}adr{0}kur{0}adl{0}kur{0}ddl{0}kur{0}bdr{0}kul{0}bdl{0}kdr{0}bdl{0}kul{0}bdr{0}kur{0}adr{0}kul",
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

                    string pawnARowActual = outputLines[outputLines.Length - 7];
                    string pawnARowExpected = "3 | - A - + - + - + |";

                    string pawnBRowActual = outputLines[outputLines.Length - 6];
                    string pawnBRowExpected = "4 | + - B - + - + - |";

                    string pawnCRowActual = outputLines[outputLines.Length - 10];
                    string pawnCRowExpected = "0 | + - + - C - K - |";

                    string pawnDRowActual = outputLines[outputLines.Length - 9];
                    string pawnDRowExpected = "1 | - + - + - D - + |";

                    Assert.AreEqual<string>(
                        pawnARowExpected, pawnARowActual, "Pawn A not moved correctly!");

                    Assert.AreEqual<string>(
                        pawnBRowExpected, pawnBRowActual, "Pawn B not moved correctly!");

                    Assert.AreEqual<string>(
                        pawnCRowExpected, pawnCRowActual, "Pawn C not moved correctly!");

                    Assert.AreEqual<string>(
                        pawnDRowExpected, pawnDRowActual, "Pawn D not moved correctly!");
                }
            }
        }

        [TestMethod]
        public void TestKingMovements()
        {
            string inputCommands = string.Format(
                "kur{0}adr{0}kur{0}bdr{0}kur{0}ddl{0}kur{0}adl{0}kul{0}bdl{0}kur{0}cdl{0}kul",
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

                    string kingRowActual = outputLines[outputLines.Length - 10];
                    string kingRowExpected = "0 | + - + - + - K - |";

                    Assert.AreEqual<string>(
                        kingRowExpected, kingRowActual, "King not moved correctly!");
                }
            }
        }
    }
}
