using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Application.Parsers;
using ToyRobot.Domain;

namespace ToyRobot.Application.Mappers
{
    /// <summary>
    /// Class to map a placement command
    /// </summary>
    public class PlaceCommandMapper : IPlaceCommandMapper
    {
        private readonly IDirectionParser _directionParser;

        public PlaceCommandMapper(IDirectionParser directionParser)
        {
            _directionParser = directionParser;
        }

        /// <summary>
        /// Maps a placement command
        /// </summary>
        /// <param name="x">Integer representation of x axis</param>
        /// <param name="y">Integer representation of y axis</param>
        /// <param name="direction">Direction robot faces</param>
        /// <returns>Placement command</returns>
        public PlaceCommand MapPlaceCommand(string x, string y, string direction)
        {
            return new PlaceCommand
            {
                Direction = _directionParser.ParseDirection(direction),
                X = int.Parse(x),
                Y = int.Parse(y)
            };
        }
    }
}
