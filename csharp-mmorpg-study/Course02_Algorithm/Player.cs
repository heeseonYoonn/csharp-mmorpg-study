using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Authentication;
using System.Text;

namespace Course02_Algorithm
{
    /*
     * ROLE: [길찾기] 플레이어
     */
    class Player
    {
        public Point StartPosition { get; private set; }
        public Point CurrentPosition { get; private set; }
        public Point Destination { get; private set; }


        public Point _simulatedPosition;
        List<Point> _simulatedPath = new();

        private Board _board;
        private int _direction;

        private Point[] DirVector =
        {
            new Point(-1,0), // up
            new Point(0,1),  // right
            new Point(1,0),  // down
            new Point(0,-1)  // left
        };

        public Player(Point startPosition, Board board)
        {
            _board = board;

            StartPosition = startPosition;
            CurrentPosition = startPosition;
            _simulatedPosition = CurrentPosition;
            Destination = _board.Destination;

            InitializeDirection();
            SimulatePath();

        }

        public void SimulatePath()
        {
            //BOOKMARK: 경로 시뮬레이션
            while (!_simulatedPosition.Equals(Destination))
            {
                if (CanTurnRight(_direction))
                {
                    _direction = TurnRight(_direction);
                    SimulateMoveStep(_direction);
                }
                else if (CanMoveForward(_direction))
                {
                    SimulateMoveStep(_direction);
                }
                else
                {
                    _direction = TurnLeft(_direction);
                    continue;
                }

                _simulatedPath.Add(_simulatedPosition);
            }
        }

        public void InitializeDirection()
        {
            if (_board.Tiles[StartPosition.Y, StartPosition.X + 1] == TileType.Empty)
                _direction = (int)Direction.Right;

            else
                _direction = (int)Direction.Down;
        }

        public int TurnLeft(int direction) => (direction - 1 + 4) % 4;
        public int TurnRight(int direction) => (direction + 1) % 4;


        public Point MoveStep(int direction, Point position)
        {
            var d = DirVector[direction];

            return new Point(position.Y + d.Y, position.X + d.X);
        }

        public void SimulateMoveStep(int direction)
        {
            _simulatedPosition = MoveStep(direction, _simulatedPosition);
        }

        public bool CanMove(int direction)
        {
            var d = DirVector[direction];
            int targetY = _simulatedPosition.Y + d.Y;
            int targetX = _simulatedPosition.X + d.X;
            return (_board.Tiles[targetY, targetX] == TileType.Empty);
        }

        public bool CanTurnRight(int direction)
        {
            int rightDir = TurnRight(direction);
            return CanMove(rightDir);
        }

        public bool CanMoveForward(int direction)
        {
            return CanMove(direction);
        }


        const int MOVE_TICK = 100;
        int _sumTick;
        int _pathIndex = 0;
        public void Update(int deltaTick)
        {
            if (_pathIndex >= _simulatedPath.Count)
                return;

            if (CurrentPosition.Equals(Destination))
                return;

            _sumTick += deltaTick;
            if (_sumTick < MOVE_TICK)
                return;


            CurrentPosition = _simulatedPath[_pathIndex];
            _pathIndex++;
            _sumTick = 0;
        }
    }
}
