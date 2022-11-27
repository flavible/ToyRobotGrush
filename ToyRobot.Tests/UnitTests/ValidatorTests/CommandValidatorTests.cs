using ToyRobot.Application.Validators;
using ToyRobot.Domain;

namespace ToyRobot.Tests.UnitTests.ValidatorTests
{
    public class CommandValidatorTests : TestBase
    {
        private ICommandValidator _commandValidator;
        protected override void ChildSetup()
        {
            _commandValidator = Get<ICommandValidator>();
        }

        [Test]
        [TestCase("place", "1", "1", "north")]
        [TestCase("move")]
        [TestCase("report")]
        [TestCase("left")]
        [TestCase("right")]
        public void CommandValidator_CommandStringIsValid(params string[] input)
        {
            Assert.IsTrue(_commandValidator.IsValidCommandStructure(input));
        }

        [Test]
        [TestCase("place", "1", "north")]
        [TestCase("place", "1", "1", "something")]
        [TestCase("place")]
        [TestCase("move", "1")]
        [TestCase("test")]
        [TestCase("")]
        [TestCase(null)]
        public void CommandValidator_CommandStringInvalid(params string[] input)
        {
            Assert.IsFalse(_commandValidator.IsValidCommandStructure(input));
        }

        [Test]
        public void CommandValidator_MoveIsValid()
        {
            Assert.IsTrue(_commandValidator.IsValidCommandForRobot(GetRobot(1, 1, Direction.North), Command.Move));
        }

        [Test]
        public void CommandValidator_MoveIsInvalidDueToPosition()
        {
            Assert.IsFalse(_commandValidator.IsValidCommandForRobot(GetRobot(1, 5, Direction.North), Command.Move));
        }

        [Test]
        public void CommandValidator_MoveIsInvalidDueToUnplaced()
        {
            Assert.IsFalse(_commandValidator.IsValidCommandForRobot(GetRobot(), Command.Move));
        }

        [Test]
        public void CommandValidator_PlaceIsValid()
        {
            var robot = GetRobot();
            var placeCommand = GetPlaceCommand(1, 1, Direction.North);
            Assert.IsTrue(_commandValidator.IsValidCommandForRobot(robot, Command.Place, placeCommand));
        }

        [Test]
        public void CommandValidator_PlaceIsInvalidDueToPlacement()
        {
            var robot = GetRobot(1, 1, Direction.North);
            var placeCommand = GetPlaceCommand(1, 1, Direction.North);
            Assert.IsFalse(_commandValidator.IsValidCommandForRobot(robot, Command.Place, placeCommand));
        }

        [Test]
        public void CommandValidator_PlaceIsInvalidDueToCommand()
        {
            var robot = GetRobot();
            Assert.IsTrue(_commandValidator.IsValidCommandForRobot(robot, Command.Place));
        }

        [Test]
        [TestCase(Command.Left)]
        [TestCase(Command.Right)]
        [TestCase(Command.Report)]
        public void CommandValidator_IsValidCommandForRobot(Command command)
        {
            var robot = GetRobot(1, 1, Direction.North);
            Assert.IsTrue(_commandValidator.IsValidCommandForRobot(robot, command));
        }

        [Test]
        [TestCase(Command.Left)]
        [TestCase(Command.Right)]
        [TestCase(Command.Report)]
        public void CommandValidator_IsInvalidCommandForRobot(Command command)
        {
            var robot = GetRobot();
            Assert.IsTrue(_commandValidator.IsValidCommandForRobot(robot, command));
        }

        private Robot GetRobot(int? x = null, int? y = null, Direction? direction = null)
        {
            return new Robot()
            {
                X = x,
                Y = y,
                Direction = direction
            };
        }

        private PlaceCommand GetPlaceCommand(int x, int y, Direction direction)
        {
            return new PlaceCommand()
            {
                X = x,
                Y = y,
                Direction = direction
            };
        }
    }
}
