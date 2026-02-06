namespace TextRPG.Course
{
    class EventPractice
    {

        /*
         * delegate를 직접 호출할 수 없게 wrapping한게 event임
         * 
         * 구독자를 모집하고, 특정 이벤트가 발생하면 해당 구독자들에 대해 어떤 함수가 실행되면
         * 이게 바로 옵저버 패턴 
         */


        /*
         * [1] 일단 delegate로 선언을 함
         * delegate를 직접 사용하지 않는 이유는, 이 delegate 타입의 함수를 아무데서나 호출될 수 있기 때문
         */
        public delegate void OnInputKey();

        /*
         * [2] 이 이벤트에 대해선
         * public
         * event:event 전용 delegate임
         * OnInputKey:타입 (매개변수가 없고, 리턴타입이 없는 함수)
         * InputKey: 이벤트 이름
         */
        public event OnInputKey InputKey; //구독신청


        /*
         * 매개변수가 없고, 리턴타입이 없는 함수
         */
        public void Update()
        {
            if (!Console.KeyAvailable)
            {
                return;
            }

            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.A) //특정 이벤트 발생
            {
                InputKey();
            }
        }

        public void TestInputKey() => Console.WriteLine("\n'A' is pressed.");
        public void TestInputKey2() => Console.WriteLine("\n'A' is pressed2.");


        public void Run()
        {
            EventPractice eventManager = new EventPractice();

            /*
             *+=: 구독
             *-=: 구독취소
             */
            eventManager.InputKey += TestInputKey;
            eventManager.InputKey += TestInputKey2;

            while (true)
            {
                eventManager.Update();
            }
        }
    }
}
