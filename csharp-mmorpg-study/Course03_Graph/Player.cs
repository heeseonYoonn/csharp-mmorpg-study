using System.Runtime.InteropServices;

namespace Course03_Graph
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
        private Navigator _navigator;
        private int _direction;



        public Player(Point startPosition, Board board, Navigator navigator)
        {
            _board = board;

            StartPosition = startPosition;
            CurrentPosition = startPosition;
            Destination = _board.Destination;

            _simulatedPosition = CurrentPosition;
            _navigator = navigator;

            InitializeDirection();
            SimulatePath();

        }

        //BOOKMARK: 경로 시뮬레이션
        public void SimulatePath()
        {
            //ApplyRightHandRule();
            ApplyBFS();
        }

        private void ApplyBFS()
        {
            bool[,] found = new bool[_board.Height, _board.Width];
            Point[,] parent = new Point[_board.Height, _board.Width];

            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(StartPosition);
            found[StartPosition.Y, StartPosition.X] = true;
            parent[StartPosition.Y, StartPosition.X] = new Point(StartPosition.Y, StartPosition.X);

            while (queue.Count > 0)
            {
                Point current = queue.Dequeue();


                //연결된 부분 확인
                foreach (Point direction in DirVector.FourDirections)
                {
                    Point next = _navigator.GetNextPoint(current, direction);

                    if (!_navigator.CanMove(next))
                        continue;

                    if (found[next.Y, next.X])
                        continue;

                    queue.Enqueue(next);
                    found[next.Y, next.X] = true;
                    parent[next.Y, next.X] = current;

                }
            }

            

        }


        private void ApplyRightHandRule()
        {
            while (!_simulatedPosition.Equals(Destination))
            {
                if (_navigator.CanTurnRight(_simulatedPosition, _direction))
                {
                    _direction = DirectionHelper.TurnRight(_direction);
                    SimulateMoveStep(_direction);
                }
                else if (_navigator.CanMove(_simulatedPosition, _direction))
                {
                    SimulateMoveStep(_direction);
                }
                else
                {
                    _direction = DirectionHelper.TurnLeft(_direction);
                    continue;
                }

                _simulatedPath.Add(_simulatedPosition);
            }
        }




        private void InitializeDirection()
        {
            if (_board.Tiles[StartPosition.Y, StartPosition.X + 1] == TileType.Empty)
                _direction = (int)Direction.Right;

            else
                _direction = (int)Direction.Down;
        }




        private Point MoveStep(int direction, Point position)
        {
            var d = DirVector.FourDirections[direction];
            return new Point(position.Y + d.Y, position.X + d.X);
        }

        private void SimulateMoveStep(int direction)
        {
            _simulatedPosition = MoveStep(direction, _simulatedPosition);
        }




        const int MOVE_TICK = 100;
        int _sumTick;
        int _pathIndex = 0;
        public void Execute(int deltaTick)
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
