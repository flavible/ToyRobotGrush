using ToyRobot.Application.Services;
using ToyRobot.Application.Validators;
using ToyRobot.Domain;

namespace ToyRobot.Tests.UnitTests.ServiceTests
{
    public class CommandServiceTests : TestBase
    {
        private ICommandService _commandService;
        protected override void ChildSetup()
        {
            _commandService = Get<ICommandService>();
        }

        [Test]
        public void CommandService_PerformedPlace()
        {
            var robot = GetRobot();
            _commandService.CommandRobot(new string[]{"place","1","1","north"}, robot);
            Assert.That(robot.X, Is.EqualTo(1));
            Assert.That(robot.Y, Is.EqualTo(1));
            Assert.That(robot.Direction, Is.EqualTo(Direction.North));
        }

        [Test]
        public void CommandService_PerformedMove()
        {
            var robot = GetRobot(1, 1, Direction.North);
            _commandService.CommandRobot(new string[] { "move" }, robot);
            Assert.That(robot.Y, Is.EqualTo(2));
        }

        [Test]
        public void CommandService_PerformedLeft()
        {
            var robot = GetRobot(1, 1, Direction.North);
            _commandService.CommandRobot(new string[] { "left" }, robot);
            Assert.That(robot.Direction, Is.EqualTo(Direction.West));
        }

        [Test]
        public void CommandService_PerformedRight()
        {
            var robot = GetRobot(1, 1, Direction.North);
            _commandService.CommandRobot(new string[] { "right" }, robot);
            Assert.That(robot.Direction, Is.EqualTo(Direction.East));
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
    }
}
