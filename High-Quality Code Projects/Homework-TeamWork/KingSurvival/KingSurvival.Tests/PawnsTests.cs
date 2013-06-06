namespace KingSurvival.Tests
{
    using System;
    using System.IO;
    using KingSurvival.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PawnsTests
    {
        [TestMethod]
        public void TestKingPawn()
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

                    string kingInitialRow = outputLines[9];
                    int delimiterFirstIndex = kingInitialRow.IndexOf('|');
                    int delimiterLastIndex = kingInitialRow.LastIndexOf('|');
                    string kingInitialRowInBoard = 
                        kingInitialRow.Substring(delimiterFirstIndex + 1, delimiterLastIndex - delimiterFirstIndex - 1);
                    string[] kingInitialRowInBoardSplitted = 
                        kingInitialRowInBoard.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    Assert.AreEqual<string>("K", kingInitialRowInBoardSplitted[3]);
                }
            }
        }

        [TestMethod]
        public void TestPawns()
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

                    string pawnsInitialRow = outputLines[2];
                    int delimiterFirstIndex = pawnsInitialRow.IndexOf('|');
                    int delimiterLastIndex = pawnsInitialRow.LastIndexOf('|');
                    string pawnsInitialRowInBoard =
                        pawnsInitialRow.Substring(delimiterFirstIndex + 1, delimiterLastIndex - delimiterFirstIndex - 1);
                    string[] pawnsInitialRowInBoardSplitted =
                        pawnsInitialRowInBoard.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    Assert.AreEqual<string>("A", pawnsInitialRowInBoardSplitted[0]);

                    Assert.AreEqual<string>("B", pawnsInitialRowInBoardSplitted[2]);

                    Assert.AreEqual<string>("C", pawnsInitialRowInBoardSplitted[4]);

                    Assert.AreEqual<string>("D", pawnsInitialRowInBoardSplitted[6]);
                }
            }
        }
    }
}
