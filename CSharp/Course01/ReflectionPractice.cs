using System.Reflection;


namespace TextRPG.Course
{
    class ReflectionPractice
    {
        /*
         * Reflection은 객체를 실시간으로 분석할 수 있음 
         * -> 객체의 구조를 들여다보고, 건드리고, 실행까지 할 수 있게 해주는 기능
         * 
         * Attribute는 컴퓨터가 이해할 수 있는 주석이다. (유니티랑 같이 쓸 때 사용)
         */

        class Important : System.Attribute
        {
            string message;
            public Important(string message) { this.message = message; }
        }


        class Monster
        {
            [Important("Significant")]
            public int hp;

            protected int attack;
            private float speed;

            void Attack() { }
        }
        public void Run()
        {
            /*
             * Reflection = X-ray라고 생각하면된다.
             */
            
            Monster monster = new Monster();
            Type type = monster.GetType();

            var fields = type.GetFields(System.Reflection.BindingFlags.Public
                | System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.Static
                | System.Reflection.BindingFlags.Instance);


            foreach (FieldInfo field in fields)
            {
                string access = "protected";
                if(field.IsPublic)
                    access = "public";
                else if(field.IsPrivate)
                    access = "private";

                var attributes = field.GetCustomAttributes();


                Console.WriteLine($"{access}, {field.FieldType.Name}, {field.Name}");
            }

        }

    }
}
