using ToyRobot.Domain;

namespace ToyRobot.Application.Parsers;

public interface ICommandParser
{
    Command ParseCommand(string input);
}