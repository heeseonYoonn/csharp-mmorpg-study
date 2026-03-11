using System;
using System.Collections.Generic;
using System.Text;

namespace Course03_Graph
{
    public static class DirVector
    {
        public static readonly Point[] FourDirections =
       {
            new Point(-1,0), // up
            new Point(0,1),  // right
            new Point(1,0),  // down
            new Point(0,-1)  // left
        };

    }
}
