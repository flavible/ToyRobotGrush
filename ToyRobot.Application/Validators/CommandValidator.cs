using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using ToyRobot.Application.Parsers;
using ToyRobot.Domain;

namespace ToyRobot.Application.Validators
{
    /// <summary>
    /// Class that validates command structure and command arguments
    /// </summary>
    public class CommandValidator : ICommandValidator
    {
        private readonly ICommandParser _commandParser;
        private readonly IDirectionValidator _directionValidator;
        private readonly IPlacementValidator _placementValidator;
        private readonly IIntValidator _intValidator;

        public CommandValidator(IDirectionValidator directionValidator, IPlacementValidator placementValidator,
            IIntValidator intValidator, ICommandParser commandParser)
        {
            _directionValidator = directionValidator;
            _placementValidator = placementValidator;
            _intValidator = intValidator;
            _commandParser = commandParser;
        }
        
        /// <summary>
        /// Validates if command is valid and is in a valid format
        /// </summary>
        /// <param name="input">Command as a string array</param>
        /// <returns>True is valid command, false otherwise</returns>
        public bool IsValidCommandStructure(string[] input)
        {
            if (input?.Any(x => x!=null) == false)
            {
                Console.WriteLine("No input entered");
                return false;
            }

            if (!IsValid(input[0]))
            {
                Console.WriteLine("Command not recognised");
                return false;
            }

            var command = _commandParser.ParseCommand(input[0]);

            switch (command)
            {
                case Command.Place:
                    return IsValidPlaceCommandStructure(input);
                default:
                    if (input.Length > 1)
                    {
                        Console.WriteLine("Invalid arguments for command");
                        return false;
                    }
                    break;
            }

            return true;
        }

        /// <summary>
        /// Validates if command is valid on a given robot
        /// </summary>
        /// <param name="robot">Robot to check command validity against</param>
        /// <param name="command">Command enum</param>
        /// <param name="placeCommand">Nullable place command arguments</param>
        /// <returns>True if command is valid on robot, false otherwise</returns>
        public bool IsValidCommandForRobot(Robot robot, Command command, PlaceCommand? placeCommand = null)
        {
            switch (command)
            {
                case Command.Place:
                    return IsValidPlaceCommand(robot, placeCommand);
                case Command.Move:
                    return IsValidMoveCommand(robot);
            }

            return true;
        }

        /// <summary>
        /// Validates whether a command string is valid
        /// </summary>
        /// <param name="input">command enum as string</param>
        /// <returns>command enum</returns>
        private bool IsValid(string input)
        {
            return Enum.TryParse(typeof(Command), input.Trim(), true, out _);
        }

        /// <summary>
        /// Validates whether place command is in valid structure
        /// </summary>
        /// <param name="input">place command as string</param>
        /// <returns>True is valid place command, false otherwise</returns>
        private bool IsValidPlaceCommandStructure(string[] input)
        {
            if (input.Length != 4)
            {
                Console.WriteLine("Not enough arguments for place command");
                return false;
            }

            if (!_intValidator.IsValid(input[1]))
            {
                Console.WriteLine("X coordinate must be an integer");
                return false;
            }

            if (!_intValidator.IsValid(input[2]))
            {
                Console.WriteLine("Y coordinate must be an integer");
                return false;
            }

            if (!_directionValidator.IsValid(input[3]))
            {
                Console.WriteLine("Invalid direction string");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates whether place command is valid on a given robot
        /// </summary>
        /// <param name="robot">Robot to check place command validity against</param>
        /// <param name="placeCommand">Place command arguments</param>
        /// <returns>True if valid place command on robot, false otherwise</returns>
        private bool IsValidPlaceCommand(Robot robot, PlaceCommand? placeCommand)
        {
            if (robot.IsPlaced)
            {
                Console.WriteLine("Robot is already placed");
                return false;
            }

            if (placeCommand != null && !_placementValidator.IsValidPlace(placeCommand.X, placeCommand.Y))
            {
                Console.WriteLine("Placement is outside range, place within 5,5");
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// Validates whether move command is valid on given robot
        /// </summary>
        /// <param name="robot">Robot to check move command against</param>
        /// <returns>True if valid move command, false otherwise</returns>
        private bool IsValidMoveCommand(Robot robot)
        {
            if (!robot.IsPlaced)
            {
                Console.WriteLine("Robot must be placed before it can move");
                return false;
            }
            var axisInt = GetMovementInt(robot);
            if (!_placementValidator.IsValidOnAxis(axisInt))
            {
                Console.WriteLine("This move would result in the robot falling off the edge");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns the integer representation of a movement command as if move was called
        /// </summary>
        /// <param name="robot">Robot to check movement against</param>
        /// <returns>Integer representation of axis position</returns>
        private int GetMovementInt(Robot robot)
        {
            return robot.Direction switch
            {
                Direction.North => robot.Y.Value + 1,
                Direction.East => robot.X.Value + 1,
                Direction.South => robot.Y.Value - 1,
                Direction.West => robot.X.Value - 1
            };
        }
    }
}
