using System;
using ToyRobot.Domain;

namespace ToyRobot.Application.Validators
{
    /// <summary>
    /// A class to validate a direction input. 
    /// </summary>
    public class DirectionValidator : IDirectionValidator
    {
        /// <summary>
        /// Validate direction input to enum.
        /// </summary>
        /// <param name="input">string to validate</param>
        /// <returns>bool representing if input is valid direction</returns>
        public bool IsValid(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return Enum.TryParse(typeof(Direction), input.Trim(), true, out _);
        }
    }
}
