namespace Course02_Algorithm
{
    class LinearDataStructure
    {

        public void Run()
        {
            #region 선형구조 설명
            /*
             * 선형구조: 자료를 순차적으로 나열한 형  태 -> 배열, 연결리스트, 스택/큐
             * [1] 배열: 연속적 but, 갯수가 고정됨
             * [2] 동적배열: 유동적 (확장, 축소가능), 연속적 but, 데이터 이동 시 비용, 중간삽입/삭제
             *  -> 실제로 사용할 데이터양보다 여유분을 두고 차지 & 데이터 이동 횟수를 최소화
             *  -> 하지만 여유분까지 데이터가 가득하면 또 데이터 이동 불가피  (또 이동 시 추가로 여유분도 같이 차지)
             * 
             * [3] 연결리스트: 연속되지 않은 방을 사용하여 중간 추가/삭제 but, N번째 방 바로 검색 불가 (Random Access 불가)
             * 
             */
            #endregion

            #region 변수
            Console.CursorVisible = false;
            int lastTick = 0;
            const int WAIT_TICK = 1000 / 30; //  1/30초, 단위가 ms이므로 *1000 
            const int SIZE = 25;
            const char CIRCLE = '\u25cf';
            #endregion


            while (true)
            {
                #region 프레임관리
                int currentTick = System.Environment.TickCount;
                if (currentTick - lastTick < WAIT_TICK)
                    continue;

                lastTick = currentTick;
                #endregion

                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(CIRCLE);
                    }
                    Console.WriteLine();
                }

            }

        }
    }
}
