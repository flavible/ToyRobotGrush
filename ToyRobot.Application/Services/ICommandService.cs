using ToyRobot.Domain;

namespace ToyRobot.Application.Services;

public interface ICommandService
{
    void CommandRobot(string[] input, Robot robot);
}