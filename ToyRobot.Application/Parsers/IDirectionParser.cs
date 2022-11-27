using ToyRobot.Domain;

namespace ToyRobot.Application.Parsers;

public interface IDirectionParser
{
    Direction ParseDirection(string input);
}