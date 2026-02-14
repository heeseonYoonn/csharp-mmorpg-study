namespace Course02_Algorithm
{

    class LinkedListPractice
    {
        class Room<T>
        {

            public T Data;
            public Room<T> Next; //가리키는 주소를 말함
            public Room<T> Prev;

        }

        class RoomList<T>
        {
            public int Count;
        }

        public void Run()
        {

            int[] _data = new int[25]; //배열
            LinkedList<int> _data3 = new LinkedList<int>(); //연결리스트 

            _data3.AddLast(101);
            _data3.AddLast(102);
            LinkedListNode<int> node = _data3.AddLast(103);
            _data3.AddLast(104);
            _data3.AddLast(105);


            _data3.Remove(node);

        }

    }
}
