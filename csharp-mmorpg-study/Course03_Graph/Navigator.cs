using Course02_Algorithm;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Course03_Graph
{
    /*
     * ROLE: [길찾기] 보드 탐색
     */

    class Navigator
    {
        Board _board;

        public Navigator(Board board)
        {
            _board = board;

        }
        
        public bool CanMove(Point next)
        {
            if (next.X < 0 || next.X > _board.Width || next.Y < 0 || next.Y > _board.Height)
                return false;

            return (_board.Tiles[next.Y, next.X] == TileType.Empty);
        }

        public bool CanMove(Point current, Point delta)
        {
            Point next = GetNextPoint(current, delta);
            return CanMove(next);
        }

        public bool CanMove(Point current, int direction)
        {
            var delta = DirVector.FourDirections[direction];
            return CanMove(current, delta);
        }

        public bool CanTurnRight(Point current, int direction)
        {
            int rightDir = DirectionHelper.TurnRight(direction);
            return CanMove(current, rightDir);
        }

        public Point GetNextPoint(Point current, Point delta)
        {
            return new Point(current.Y + delta.Y, current.X + delta.X);
        }
    }
}
