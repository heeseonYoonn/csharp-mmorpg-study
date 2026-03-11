using System.Collections;
using TextGame;

namespace Course03_Graph
{
    class Board
    {

        /*
         * ROLE: [길찾기] 게임 내 길 패턴 생성
         */
        public int Height { get; private set; }
        public int Width { get; private set; }

        public TileType[,] Tiles { get; private set; } // 배열
        public Point Destination { get; private set; }

        private const char Shape = '\u25cf';

        //생성자
        public Board(int height, int width)
        {
            if (height < 0 || width < 0)
                throw new ArgumentOutOfRangeException($"Parameters should be upper zero. height:{height}, width:{width}");

            Height = height;
            Width = width;

            Tiles = new TileType[Height, Width];
            Destination = new Point(Height - 2, Width - 2);

            //GenerateByBinaryTreeMap();
            GenergateBySideWider();


        }

        //맵 가장자리 빌든
        public void BuildBoundaryWalls()
        {
            //사방에 벽을 뚫는 작업
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        Tiles[y, x] = TileType.Wall;
                    else
                        Tiles[y, x] = TileType.Empty;
                }
            }
        }

        //맵 경계조건 보완
        public bool IsBoundaryCase(int x, int y)
        {
            //테두리
            if (x % 2 == 0 || y % 2 == 0)
                return true;

            //오른쪽 아래 코너
            if (x == Width - 2 && y == Height - 2)
                return true;

            //맨 아랫줄 -> 오른쪽 벽 허물기
            if (y == Height - 2)
            {
                Tiles[y, x + 1] = TileType.Empty;
                return true;
            }

            //맨 오른쪽줄 -> 아래쪽 벽 허물기
            if (x == Width - 2)
            {
                Tiles[y + 1, x] = TileType.Empty;
                return true;
            }

            return false;
        }

        //트리맵 생성
        public void GenerateByBinaryTreeMap()
        {
            if (Height % 2 == 0 || Width % 2 == 0)
                throw new ArgumentException($"Parameters should be odd. height:{Height}, width:{Width}");

            BuildBoundaryWalls();

            //랜덤으로 우측 혹은 아래로 길을 뚫는 작업
            Random random = new Random();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (IsBoundaryCase(x, y))
                        continue;


                    //랜덤지정
                    if (random.Next(0, 2) == 0)
                        Tiles[y, x + 1] = TileType.Empty;
                    else
                        Tiles[y + 1, x] = TileType.Empty;

                }
            }
        }

        //사이드와이더 맵 생성
        public void GenergateBySideWider()
        {
            BuildBoundaryWalls();

            Random random = new Random();
            for (int y = 0; y < Height; y++)
            {
                int count = 1;
                for (int x = 0; x < Width; x++)
                {
                    if (IsBoundaryCase(x, y))
                        continue;

                    //랜덤지정
                    if (random.Next(0, 2) == 0)
                    {
                        Tiles[y, x + 1] = TileType.Empty;
                        count++;
                    }
                    else
                    {
                        int randomIndex = random.Next(0, count);
                        Tiles[y + 1, x - randomIndex * 2] = TileType.Empty;
                        count = 1;
                    }
                }
            }
        }

        //렌더링
        public void Render(Player player)
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (y == player.CurrentPosition.Y && x == player.CurrentPosition.X)
                        Console.ForegroundColor = ConsoleColor.Blue;

                    else if (y == Destination.Y && x == Destination.X)
                        Console.ForegroundColor = ConsoleColor.Yellow;

                    else
                        Console.ForegroundColor = GetTileColor(Tiles[y, x]);

                    Console.Write(Shape);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = prevColor;
        }

        //타일 색상 지정
        private ConsoleColor GetTileColor(TileType tileType)
        {
            switch (tileType)
            {
                case (TileType.Wall):
                    return ConsoleColor.Red;

                case (TileType.Empty):
                    return ConsoleColor.Green;

                default:
                    return ConsoleColor.Red;
            }
        }
    }
}
