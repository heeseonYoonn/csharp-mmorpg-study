namespace TextRPG.Course
{
    class GenericPractice
    {
        /*
         * 제네릭 사용 이유: 박싱/언박싱 성능 개선
         * ArrayList arrayList = new ArrayList(); 라고 한다면,
         * arrayList.Add(1); 이라고 할 때, 1을 stack이 아닌 heap에 저장한다. (박싱)
         * 이 arrayList에 있는 값을 꺼낼 때 다시 (int)로 캐스팅 한 후 stack에 복사한다. (언박싱)
         * 이 박싱/ 언박싱 성능을 개선한다. (컴파일 과정에서 참조인지 primitive인지 가리기 때문)
         * 
         */

        /*
        where T : class             참조 타입만
        where T : struct            값 타입만
        where T : SomeClass         SomeClass 상속
        where T : ISomeInterface    인터페이스 구현
        where T : new ()            기본 생성자 ('매개변수가 없는 생성자'를 가진 타입)
        */
        class Custom3<T> where T : new()
        {
        }

        class Custom2<T>
        {
            T[] arr = new T[10];
            T getItem(int i)
            {
                return arr[i];
            }
        }

        class Custom1<T, K>
        {
        }

        public void Run()
        {
        }
    }
}

