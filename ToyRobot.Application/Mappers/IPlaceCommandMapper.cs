using ToyRobot.Domain;

namespace ToyRobot.Application.Mappers;

public interface IPlaceCommandMapper
{
    PlaceCommand MapPlaceCommand(string x, string y, string direction);
}