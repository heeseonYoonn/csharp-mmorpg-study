namespace Course02_Algorithm
{

    class LinkedListPractice
    {
        class MyLinkedListNode<T>
        {

            public T Data;
            public MyLinkedListNode<T> Next; //가리키는 주소를 말함
            public MyLinkedListNode<T> Prev;

        }

        class MyLinkedList<T>
        {
            public MyLinkedListNode<T> Head = null; //첫번째
            public MyLinkedListNode<T> Tail = null; //마지막
            public int Count = 0;

            //O(1)
            public MyLinkedListNode<T> AddLast(T data)
            {
                MyLinkedListNode<T> newMyLinkedListNode = new MyLinkedListNode<T>();
                newMyLinkedListNode.Data = data;

                if (Head == null)
                {
                    Head = newMyLinkedListNode;
                }

                //기존의 [마지막 방]과 [새로 추가되는 방]을 연결한다.
                if (Tail != null)
                {
                    Tail.Next = newMyLinkedListNode;
                    newMyLinkedListNode.Prev = Tail;
                }

                //[새로 추가되는 방]을 [마지막 방]으로 인정한다.
                Tail = newMyLinkedListNode;
                Count++;
                return newMyLinkedListNode;
            }


            // 101 102 103 104
            //O(1)
            public void Remove(MyLinkedListNode<T> room)
            {
                //[기존의 첫번째 방의 다음 방]을 [첫번째 방으로]인정한다.
                if (Head == room)
                {
                    Head = room.Next;

                }

                //[기존의 마지막 방의 이전 방]을 [마지막 방으로]인정한다.
                else if (Tail == room)
                {
                    Tail = room.Prev;
                }
                else
                {
                    if (room.Prev != null)
                        room.Prev.Next = room.Next;

                    if (room.Next != null)
                        room.Next.Prev = room.Prev;
                }

                Count--;
            }
        }




        public void Run()
        {

            int[] _data = new int[25]; //배열
            MyLinkedList<int> _data3 = new MyLinkedList<int>(); //연결리스트 

            _data3.AddLast(101);
            _data3.AddLast(102);
            MyLinkedListNode<int> node = _data3.AddLast(103);
            _data3.AddLast(104);
            _data3.AddLast(105);


            _data3.Remove(node);

        }

    }
}
