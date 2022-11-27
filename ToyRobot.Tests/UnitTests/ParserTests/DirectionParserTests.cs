using ToyRobot.Application.Parsers;
using ToyRobot.Domain;

namespace ToyRobot.Tests.UnitTests.ParserTests
{
    public class DirectionParserTests : TestBase
    {
        private IDirectionParser _directionParser;
        protected override void ChildSetup()
        {
            _directionParser = Get<IDirectionParser>();
        }

        [Test]
        [TestCase("north", Direction.North)]
        [TestCase("East", Direction.East)]
        [TestCase("sOuth", Direction.South)]
        [TestCase("west", Direction.West)]
        public void DirectionParser_DirectionValid(string input, Direction direction)
        {
            Assert.That(_directionParser.ParseDirection(input), Is.EqualTo(direction));
        }
    }
}
