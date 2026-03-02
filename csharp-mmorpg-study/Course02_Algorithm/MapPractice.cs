using System;
using System.Collections.Generic;
using System.Text;

namespace Course02_Algorithm
{
    class MapPractice
    {

        Board? _board;
        Player? _player;


        public void Run()
        {
            InitializeMap();
            GameLoop();
        }

        public void InitializeMap()
        {
            _board = new Board(25, 25);
            _player = new Player((1,1), _board);
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

        

        public void Update(int deltaTick) => _player.Update(deltaTick);

        public void RenderFrame() => _board.Render(_player);

    }
}
