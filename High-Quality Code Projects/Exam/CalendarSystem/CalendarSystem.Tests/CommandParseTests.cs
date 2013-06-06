namespace CalendarSystem.Tests
{
    using System;
    using CalendarSystem.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommandParseTests
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InvalidCommandParseTest()
        {
            string inputCommand = "AddEvent";
            Command.Parse(inputCommand);
        }

        [TestMethod]
        public void AddEventWithLocationCommandParse()
        {
            string inputCommand = "AddEvent 2001-01-01T20:00:00 | C# course - 977731 |  - 688803";
            
            Command parsedCommand = Command.Parse(inputCommand);

            string[] expectedCommandArgs = { "2001-01-01T20:00:00", "C# course - 977731", "- 688803" };
            Assert.AreEqual("AddEvent", 
                parsedCommand.Name, 
                "Command name not parsed correctly!");

            CollectionAssert.AreEqual(expectedCommandArgs, 
                parsedCommand.Arguments, 
                "Command arguments not parsed correctly!");
        }

        [TestMethod]
        public void AddEventWithoutLocationCommandParse()
        {
            string inputCommand = "AddEvent 2001-01-01T20:00:00 | C# course - 977731";

            Command parsedCommand = Command.Parse(inputCommand);

            string[] expectedCommandArgs = { "2001-01-01T20:00:00", "C# course - 977731" };
            Assert.AreEqual("AddEvent",
                parsedCommand.Name,
                "Command name not parsed correctly!");

            CollectionAssert.AreEqual(expectedCommandArgs,
                parsedCommand.Arguments,
                "Command arguments not parsed correctly!");
        }

        [TestMethod]
        public void DeleteEventsCommandParse()
        {
            string inputCommand = "DeleteEvents Exam";

            Command parsedCommand = Command.Parse(inputCommand);

            string[] expectedCommandArgs = { "Exam" };
            Assert.AreEqual("DeleteEvents",
                parsedCommand.Name,
                "Command name not parsed correctly!");

            CollectionAssert.AreEqual(expectedCommandArgs,
                parsedCommand.Arguments,
                "Command arguments not parsed correctly!");
        }

        [TestMethod]
        public void ListEventsCommandParse()
        {
            string inputCommand = "ListEvents 2001-01-01T10:30:02 | 17";

            Command parsedCommand = Command.Parse(inputCommand);

            string[] expectedCommandArgs = { "2001-01-01T10:30:02", "17" };
            Assert.AreEqual("ListEvents",
                parsedCommand.Name,
                "Command name not parsed correctly!");

            CollectionAssert.AreEqual(expectedCommandArgs,
                parsedCommand.Arguments,
                "Command arguments not parsed correctly!");
        }
    }
}
