using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Domain;

namespace ToyRobot.Application.Validators
{
    /// <summary>
    /// Class to check validity of an integer
    /// </summary>
    public class IntValidator : IIntValidator
    {
        /// <summary>
        /// Checks if string is a valid integer
        /// </summary>
        /// <param name="input">String to check integer validity</param>
        /// <returns>True if valid integer, false otherwise</returns>
        public bool IsValid(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return int.TryParse(input.Trim(), out _);
        }
    }
}
