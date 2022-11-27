using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.Domain
{
    public class Robot
    {
        public int? X { get; set; }
        public int? Y { get; set; }
        public Direction? Direction { get; set; }

        public bool IsPlaced => X.HasValue && Y.HasValue && Direction.HasValue;
    }
}
