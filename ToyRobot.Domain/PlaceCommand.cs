using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.Domain
{
    public class PlaceCommand
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
    }
}
