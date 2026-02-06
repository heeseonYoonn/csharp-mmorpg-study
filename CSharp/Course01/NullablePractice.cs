namespace TextRPG.Course
{
    class NullablePractice
    {
        /*
         * Nullable -> Null + able 
         * [1] int? number 이런 식으로 선언하거나
         * [2] int b = number ?? 0; 이런식으로 선언함

         * Nullable을 사용하는 주요 목적:
         * Nullable 타입은 원래 null을 가질 수 없는 int, float와 같은 값 타입 변수가 
         * '유효한 값이 없음' 상태를 나타내기 위해 null 값을 가질 수 있도록 해줘요.
         * 
         */

        class Monster
        {
            public int Id {  get; set; }
        }


        public void Run()
        {
            int? number = null;
            int b = number ?? 0;

            number = 3;
            int a = number.Value;

            /*
             * nullabel을 사용하려면 반드시 null 체크를 해야함
                if(number.HasValue)     
             */

            //[1] 지금 이 코드를 
            Monster monster = null;
            if(monster != null)
            {
                int monsterId = monster.Id;
            }

            //[2] 이렇게 바꿀 수 있다.
            //int id는 Nullable이기 때문에 null도 가능하고 Id도 가능하다.
            int? id = monster?.Id;
        }
    }
}
