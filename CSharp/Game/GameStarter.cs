using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG.Game
{
    internal class GameStarter
    {
        public void Run()
        {
            GameProcess process = new GameProcess();
            DestinationType destination;

            process.SetUpPlayer();

            while (true)
            {
                RPGSystem.Message("마을에 접속했습니다.");
                destination = process.SelectDestination();

                if (destination == DestinationType.Field)
                {
                    process.EnterField();
                }
                else if (destination == DestinationType.Store)
                {
                }
                else if (destination == DestinationType.ExitGame)
                {
                    RPGSystem.Message("게임을 종료합니다.");
                    break;
                }
                else
                {
                }
            }
        }
    }
}
