using System;
using System.Collections.Generic;
using System.Text;

namespace Course03_Graph
{
    public static class DirectionHelper
    {

        public static int TurnLeft(int direction)
        {
            return (direction - 1 + 4) % 4;
        }

        public static int TurnRight(int direction)
        {
            return (direction + 1) % 4;
        }
    }
}
