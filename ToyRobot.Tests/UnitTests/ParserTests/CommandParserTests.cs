using ToyRobot.Application.Parsers;
using ToyRobot.Domain;

namespace ToyRobot.Tests.UnitTests.ParserTests
{
    public class CommandParserTests : TestBase
    {
        private ICommandParser _commandParser;
        protected override void ChildSetup()
        {
            _commandParser = Get<ICommandParser>();
        }

        [Test]
        [TestCase("place", Command.Place)]
        [TestCase("Move", Command.Move)]
        [TestCase("lEft", Command.Left)]
        [TestCase(" Right", Command.Right)]
        [TestCase(" report ", Command.Report)]
        public void CommandParser_CommandValid(string input, Command command)
        {
            Assert.That(_commandParser.ParseCommand(input), Is.EqualTo(command));
        }
    }
}
