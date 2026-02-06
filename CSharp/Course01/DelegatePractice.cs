namespace TextRPG.Course
{
    internal class DelegatePractice
    {
        internal delegate void OnLoaded(string id);
        /*
         *delegate: 함수형태를 정의함
         *void: 이 함수는 리턴값이 없음
         *OnLoaded: 매개변수 하나만 받음
         *따라서 이 delegate는 SayWord()처럼 매개변수가 string으로 1개 들어오고, 리턴타입이 없는 함수만 받을 수 있음

         *약간 함수계의 인터페이스 같은 느낌

         *main 함수에선 아래처럼 선언 / delegate끼리 체이닝도 가능함
         *DelegatePractice dp = new DelegatePractice();
            dp.OnLoad("hee", dp.SayUserID);

         * delegate의 경우, 외부 아무 곳에서나 호출될 수 있다는 단점이 있음
         * -> 이걸 한번 더 감싼게 event임
         */


        internal void OnLoad(string id, OnLoaded callback)
        {
            Console.WriteLine("로딩중");
            callback(id);

        }

        public void SayUserID(string id)
        {
            Console.WriteLine($"{id}님 안녕하세요.");
        }

        public void Chain(string id)
        {
            Console.WriteLine("chain");
        }
    }
}
