using ToyRobot.Application.Validators;
using ToyRobot.Domain;

namespace ToyRobot.Tests.UnitTests.ValidatorTests
{
    public class IntValidatorTests : TestBase
    {
        private IIntValidator _intValidator;
        protected override void ChildSetup()
        {
            _intValidator = Get<IIntValidator>();
        }

        [Test]
        [TestCase("1")]
        [TestCase("-1")]
        [TestCase("10")]
        [TestCase("5")]
        public void IntValidator_IntValid(string input)
        {
            Assert.IsTrue(_intValidator.IsValid(input));
        }

        [Test]
        [TestCase("test")]
        [TestCase("")]
        [TestCase(null)]
        public void IntValidator_IntInvalid(string input)
        {
            Assert.IsFalse(_intValidator.IsValid(input));
        }
    }
}
