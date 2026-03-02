using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Authentication;
using System.Text;

namespace Course02_Algorithm
{
    class Player
    {
        public (int Y, int X) InitialPosition { get; private set; }
        public (int Y, int X) CurrentPosition { get; private set; }
        public (int Y, int X) Destination { get; private set; }
        private Board _board;
        int _direction;

        public (int Y, int X)[] DirVector =
        {
            (-1, 0) , //up
            (0 , 1)  , //right
            (1 , 0)  , //down
            (0 ,-1)   //left
        };



        public Player((int Y, int X) initialPosition, Board board)
        {
            _board = board;
            InitialPosition = initialPosition;
            CurrentPosition = initialPosition;
            Destination = _board.Destination;

            if (_board.Tiles[CurrentPosition.Y, CurrentPosition.X + 1] == TileType.Empty)
                _direction = (int)Direction.Right;
            else
                _direction = (int)Direction.Down;

            while (false)
            {
                //TODO:여기로 길 찾기 로직 옮긴 후, 플레이어가 이동하는 지점을 리스트에 저장
            }

        }

        public int TurnLeft(int direction) => (direction - 1 + 4) % 4;
        public int TurnRight(int direction) => (direction + 1) % 4;



        public void Move(int direction)
        {
            var d = DirVector[direction];
            CurrentPosition = (CurrentPosition.Y + d.Y, CurrentPosition.X + d.X);
        }


        public bool CanMove(int directoin)
        {
            var d = DirVector[directoin];
            int targetY = CurrentPosition.Y + d.Y;
            int targetX = CurrentPosition.X + d.X;
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


        private const int MOVE_TICK = 100;
        private int _sumTick;
        public void Update(int deltaTick)
        {
            if (CurrentPosition == Destination)
                return;

            _sumTick += deltaTick;

            if (_sumTick > MOVE_TICK)
            {
                if (CanTurnRight(_direction))
                {
                    _direction = TurnRight(_direction);
                    Move(_direction);
                }
                else if (CanMoveForward(_direction))
                    Move(_direction);

                else
                    _direction = TurnLeft(_direction);

                //초기화
                _sumTick = 0;
            }
        }
    }
}
