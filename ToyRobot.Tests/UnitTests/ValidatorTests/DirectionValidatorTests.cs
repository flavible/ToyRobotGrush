using ToyRobot.Application.Validators;
using ToyRobot.Domain;

namespace ToyRobot.Tests.UnitTests.ValidatorTests
{
    public class DirectionValidatorTests : TestBase
    {
        private IDirectionValidator _directionValidator;
        protected override void ChildSetup()
        {
            _directionValidator = Get<IDirectionValidator>();
        }

        [Test]
        [TestCase("north")]
        [TestCase("East")]
        [TestCase("sOuth")]
        [TestCase("west")]
        public void DirectionValidator_DirectionValid(string input)
        {
            Assert.IsTrue(_directionValidator.IsValid(input));
        }

        [Test]
        [TestCase("northas")]
        [TestCase("")]
        [TestCase(null)]
        public void DirectionValidator_DirectionInvalid(string input)
        {
            Assert.IsFalse(_directionValidator.IsValid(input));
        }
    }
}
