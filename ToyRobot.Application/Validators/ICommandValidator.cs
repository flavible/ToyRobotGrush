using ToyRobot.Domain;

namespace ToyRobot.Application.Validators;

public interface ICommandValidator
{
    bool IsValidCommandStructure(string[] input);
    bool IsValidCommandForRobot(Robot robot, Command command, PlaceCommand? placeCommand = null);
}