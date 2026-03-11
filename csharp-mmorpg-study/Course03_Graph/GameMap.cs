using System;
using System.Collections.Generic;
using System.Text;

namespace Course03_Graph
{
    /*
     * ROLE: [길찾기] 게임 메타 설정
     */
    class GameMap
    {

        Board _board;
        Player _player;
        Navigator _navigator;

        public GameMap()
        {
            _board = new Board(25, 25);
            _navigator = new Navigator(_board);
            _player = new Player(new Point(1, 1), _board, _navigator);
        }

        public void GameLoop()
        {
            Console.CursorVisible = false;
            int lastTick = 0;
            const int WAIT_TICK = 1000 / 20;
            ConsoleColor prevColor = Console.ForegroundColor;

            while (true)
            {
                #region 프레임관리
                int currentTick = System.Environment.TickCount;
                int deltaTick = currentTick - lastTick;
                if (deltaTick < WAIT_TICK)
                    continue;

                lastTick = currentTick;
                #endregion

                Update(deltaTick);
                RenderFrame();
            }

        }

        public void Update(int deltaTick) => _player.Execute(deltaTick);
        public void RenderFrame() => _board.Render(_player);

    }
}
