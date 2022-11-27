using ToyRobot.Application.Validators;
using ToyRobot.Domain;

namespace ToyRobot.Tests.UnitTests.ValidatorTests
{
    public class PlacementValidatorTests : TestBase
    {
        private IPlacementValidator _placementValidator;
        protected override void ChildSetup()
        {
            _placementValidator = Get<IPlacementValidator>();
        }

        [Test]
        [TestCase(1,1)]
        [TestCase(0,4)]
        [TestCase(3,2)]
        public void PlacementValidator_PlacementValid(int x, int y)
        {
            Assert.IsTrue(_placementValidator.IsValidPlace(x, y));
        }

        [Test]
        [TestCase(-1,0)]
        [TestCase(-1,6)]
        [TestCase(0,6)]
        [TestCase(0,-1)]
        public void PlacementValidator_PlacementInvalid(int x, int y)
        {
            Assert.IsFalse(_placementValidator.IsValidPlace(x, y));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void PlacementValidator_PlacementOnAxisValid(int x)
        {
            Assert.IsTrue(_placementValidator.IsValidOnAxis(x));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(6)]
        [TestCase(6000)]
        public void PlacementValidator_PlacementOnAxisInvalid(int x)
        {
            Assert.IsFalse(_placementValidator.IsValidOnAxis(x));
        }
    }
}
