using System;
using ToyRobot.Application.Mappers;
using ToyRobot.Application.Parsers;
using ToyRobot.Application.Validators;
using ToyRobot.Domain;

namespace ToyRobot.Application.Services
{
    /// <summary>
    /// Class that performs all command options for the toy robot
    /// </summary>
    public class CommandService : ICommandService
    {
        private readonly ICommandValidator _commandValidator;
        private readonly ICommandParser _commandParser;
        private readonly IPlaceCommandMapper _placeCommandMapper;
        public CommandService(ICommandParser commandParser, ICommandValidator commandValidator, IPlaceCommandMapper placeCommandMapper)
        {
            _commandValidator = commandValidator;
            _commandParser = commandParser;
            _placeCommandMapper = placeCommandMapper;
        }

        /// <summary>
        /// Validates and performs command options for the toy robot
        /// </summary>
        /// <param name="input">Command input as a string array</param>
        /// <param name="robot">Robot to perform commands on</param>
        public void CommandRobot(string[] input, Robot robot)
        {
            if (!_commandValidator.IsValidCommandStructure(input))
            {
                return;
            };

            var command = _commandParser.ParseCommand(input[0]);

            PlaceCommand? placeCommand = null;
            if (command == Command.Place)
            {
                placeCommand = _placeCommandMapper.MapPlaceCommand(input[1], input[2], input[3]);
            }

            if (!_commandValidator.IsValidCommandForRobot(robot, command, placeCommand))
            {
                return;
            }

            CommandRobotInternal(robot, command, placeCommand);
        }

        /// <summary>
        /// Performs all commands for the toy robot
        /// </summary>
        /// <param name="robot">Robot to perform commands on</param>
        /// <param name="command">Command enum to perform</param>
        /// <param name="placeCommand">Nullable place command arguments</param>
        private void CommandRobotInternal(Robot robot, Command command, PlaceCommand? placeCommand = null)
        {
            switch (command)
            {
                case Command.Place:
                    PlaceRobot(robot, placeCommand);
                    break;
                case Command.Move:
                    MoveRobot(robot);
                    break;
                case Command.Left:
                    RotateRobot(robot, -1);
                    break;
                case Command.Right:
                    RotateRobot(robot, 1);
                    break;
                case Command.Report:
                    Report(robot);
                    break;

            }
        }

        /// <summary>
        /// Performs the place command
        /// Sets the robot's x coordinate, y coordinate and direction
        /// </summary>
        /// <param name="robot">Robot to place</param>
        /// <param name="placeCommand">Place command arguments</param>
        private void PlaceRobot(Robot robot, PlaceCommand placeCommand)
        {
            robot.X = placeCommand.X;
            robot.Y = placeCommand.Y;
            robot.Direction = placeCommand.Direction;
        }

        /// <summary>
        /// Performs the move command
        /// Increments the robots x or y coordinates based on robot direction
        /// </summary>
        /// <param name="robot">Robot to move</param>
        private void MoveRobot(Robot robot)
        {
            switch(robot.Direction)
            {
                case Direction.North:
                    robot.Y += 1;
                    break;
                case Direction.East:
                    robot.X += 1;
                    break;
                case Direction.South:
                    robot.Y -= 1;
                    break;
                case Direction.West:
                    robot.X -= 1;
                    break;
            };
        }

        /// <summary>
        /// Performs the rotate command (Left/Right)
        /// Changes to robot's direction to the left with -1 and to the right with 1
        /// </summary>
        /// <param name="robot">Robot to rotate</param>
        /// <param name="rotationDirection">Direction to rotate as an integer</param>
        private void RotateRobot(Robot robot, int rotationDirection)
        {
            var newDirection = robot.Direction.Value + rotationDirection;
            robot.Direction = (int) newDirection < 0 ? Direction.West : (int) newDirection > 3 ? Direction.North : newDirection;
        }

        /// <summary>
        /// Performs the report command
        /// Reports the robot's position and direction in format x,y,direction if placed
        /// Reports that the robot is not placed if relevant 
        /// </summary>
        /// <param name="robot"></param>
        private void Report(Robot robot)
        {
            var message = "Output: ";
            message += robot.IsPlaced ? $"{robot.X}, {robot.Y}, {robot.Direction.ToString()}" : "Robot in hand";

            Console.WriteLine(message);
        }
    }
}