using System;
using ToyRobot.Domain;

namespace ToyRobot.Application.Parsers;

/// <summary>
/// Class that parses command enum
/// </summary>
public class CommandParser : ICommandParser
{
    /// <summary>
    /// Parses command enum from string
    /// </summary>
    /// <param name="input">string representation of command</param>
    /// <returns>Command enum</returns>
    public Command ParseCommand(string input)
    {
        return Enum.Parse<Command>(input, true);
    }
}