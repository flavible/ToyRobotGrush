using System;
using ToyRobot.Domain;

namespace ToyRobot.Application.Parsers
{
    /// <summary>
    /// Class that parses a direction enum
    /// </summary>
    public class DirectionParser : IDirectionParser
    {
        /// <summary>
        /// Parses direction enum from string
        /// </summary>
        /// <param name="input">string representation of direction</param>
        /// <returns>Direction enum</returns>
        public Direction ParseDirection(string input)
        {
            return Enum.Parse<Direction>(input, true);
        }
    }
}
