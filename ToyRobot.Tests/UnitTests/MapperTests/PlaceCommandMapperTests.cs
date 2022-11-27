using ToyRobot.Application.Mappers;
using ToyRobot.Application.Parsers;
using ToyRobot.Domain;

namespace ToyRobot.Tests.UnitTests.MapperTests
{
    public class PlaceCommandMapperTests : TestBase
    {
        private IPlaceCommandMapper _placeCommandMapper;
        protected override void ChildSetup()
        {
            _placeCommandMapper = Get<IPlaceCommandMapper>();
        }

        [Test]
        public void PlaceCommandMapper_XMappedCorrectly()
        {
            var mapped = _placeCommandMapper.MapPlaceCommand("1", "2", "north");
            Assert.That(mapped.X, Is.EqualTo(1));
        }

        [Test]
        public void PlaceCommandMapper_YMappedCorrectly()
        {
            var mapped = _placeCommandMapper.MapPlaceCommand("1", "2", "north");
            Assert.That(mapped.X, Is.EqualTo(2));
        }

        [Test]
        public void PlaceCommandMapper_DirectionMappedCorrectly()
        {
            var mapped = _placeCommandMapper.MapPlaceCommand("1", "2", "north");
            Assert.That(mapped.Direction, Is.EqualTo(Direction.North));
        }
    }
}
