namespace KingSurvival.Tests
{
    using System;
    using System.IO;
    using KingSurvival.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConsoleEngineTests
    {
        private const char Enter = (char)13;

        [TestMethod]
        public void TestKingWinsWithoutInvalidMoves()
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

                    string expected = "King wins in 7 turns!";
                    int lastLineIndex = outputLines.Length - 1;
                    string actual = outputLines[lastLineIndex];
                    Assert.AreEqual<string>(expected, actual);
                }
            }
        }

        [TestMethod]
        public void TestKingWinsWithInvalidMoves()
        {
            string inputCommands = string.Format(
                "kur{0}bdr{0}kur{0}bdr{0}kul{0}bdr{0}kur{0}{1}kul{0}bdr{0}" +
                "kdr{0}bdr{0}kul{0}bdr{0}{1}bdl{0}kur{0}bdr{0}kul{0}cdr{0}kur",
                Environment.NewLine, 
                Enter);

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

                    string expected = "King wins in 9 turns!";
                    int lastLineIndex = outputLines.Length - 1;
                    string actual = outputLines[lastLineIndex];
                    Assert.AreEqual<string>(expected, actual);
                }
            }
        }

        [TestMethod]
        public void TestKingIsTrappedInRightDownCorner()
        {
            string inputCommands = string.Format(
                "kur{0}bdl{0}kur{0}bdr{0}kul{0}bdr{0}kdr{0}bdr{0}kdr{0}bdr{0}kdr{0}bdr",
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

                    string expected = "King loses in 6 turns...";
                    int lastLineIndex = outputLines.Length - 1;
                    string actual = outputLines[lastLineIndex];
                    Assert.AreEqual<string>(expected, actual);
                }
            }
        }

        [TestMethod]
        public void TestKingIsTrappedInRightWall()
        {
            string inputCommands = string.Format(
                "kur{0}ddl{0}kur{0}ddr{0}kul{0}cdl{0}kdr{0}cdr{0}kur{0}cdr{0}kur{0}cdr{0}kur{0}cdr",
                Environment.NewLine, 
                Enter);

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

                    string expected = "King loses in 6 turns...";
                    int lastLineIndex = outputLines.Length - 1;
                    string actual = outputLines[lastLineIndex];
                    Assert.AreEqual<string>(expected, actual);
                }
            }
        }

        [TestMethod]
        public void TestAllInvalidPositions()
        {
            string inputCommands = string.Format(
                "kdl{0}{1}kdr{0}{1}kur{0}adl{0}{1}adr{0}kur{0}bdl{0}{1}bdr{0}" +
                "kul{0}cdl{0}{1}cdr{0}kul{0}ddl{0}{1}ddr{0}kul{0}adr{0}{1}bdl{0}{1}" +
                "ddr{0}{1}cdr{0}kur{0}{1}kul{0}{1}kdr{0}cdr{0}kur{0}cdr{0}{1}cdl{0}" +
                "kur{0}ddl{0}kdr{0}{1}kur",
                Environment.NewLine, 
                Enter);

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

                    string expected = "King wins in 9 turns!";
                    int lastLineIndex = outputLines.Length - 1;
                    string actual = outputLines[lastLineIndex];
                    Assert.AreEqual<string>(expected, actual);
                }
            }
        }

        [TestMethod]
        public void TestAllPawnsOnTheLastLine()
        {
            string inputCommands = string.Format(
                "kur{0}adr{0}kur{0}adr{0}kur{0}adr{0}kur{0}adr{0}kul{0}adr{0}kdr{0}" +
                "adr{0}kul{0}adr{0}kdr{0}ddl{0}kul{0}ddl{0}kdr{0}ddl{0}kul{0}ddl{0}kdr{0}" +
                "ddl{0}kul{0}ddl{0}kdr{0}ddr{0}kul{0}cdl{0}kul{0}cdl{0}kdr{0}cdl{0}kdl{0}" +
                "cdl{0}kur{0}cdr{0}kur{0}cdr{0}kdl{0}cdr{0}kdl{0}bdl{0}kul{0}bdl{0}kdr{0}" +
                "bdr{0}kur{0}bdr{0}kdl{0}bdr{0}kul{0}bdr{0}kdl{0}bdr",
                Environment.NewLine, 
                Enter);

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

                    string expected = "King wins in 28 turns!";
                    int lastLineIndex = outputLines.Length - 1;
                    string actual = outputLines[lastLineIndex];
                    Assert.AreEqual<string>(expected, actual);
                }
            }
        }

        [TestMethod]
        public void TestInvalidCommands()
        {
            string inputCommands = string.Format(
                "kul{0}bdr{0}kul{0}bdl{0}asd{0}{1}kur{0}asd{0}{1}adr{0}kur{0}bdl{0}kur{0}bdl{0}kul{0}ddl{0}kul",
                Environment.NewLine, 
                Enter);

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

                    string expected = "King wins in 7 turns!";
                    int lastLineIndex = outputLines.Length - 1;
                    string actual = outputLines[lastLineIndex];
                    Assert.AreEqual<string>(expected, actual);
                }
            }
        }
    }
}
