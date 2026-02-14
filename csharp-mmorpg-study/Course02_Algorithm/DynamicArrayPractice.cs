using System;
using System.Collections.Generic;
using System.Text;

namespace Course02_Algorithm
{
    class DynamicArrayPractice
    {

        /*
         * 동적배열 구현
         */
        class MyList<T>
        {
            const int DEFAULT_SIZE = 1;
            T[] _data = new T[DEFAULT_SIZE]; //예약된 데이터의 총 모음

            public int Count = 0; //실제로 사용 중인 데이터 갯수
            public int Capacity { get { return _data.Length; } } //예약된 데이터 갯수


            /*
             * O(1) 
             * 예외케이스: 느린 복사작업은 가끔 일어나기 때문
             */
            public void Add(T item)
            {
                //TODO: 공간이 충분히 확보되었는지 확인
                if (Count >= Capacity)
                {
                    //TODO: 공간을 다시 늘려서 확보
                    T[] newArray = new T[Count * 2]; //여기서 growth factor = 2
                    for (int i = 0; i < Count; i++)
                        newArray[i] = _data[i];

                    _data = newArray;
                }

                //TODO: 공간에 데이터를 삽입
                _data[Count] = item;
                Count++;
            }

            /*
             * O(1)
             */
            public T this[int index]
            {
                get { return _data[index]; }
                set { _data[index] = value; }
            }


            /*
             * O(N)
             */
            public void RemoveAt(int index)
            {
                //TODO: 해당 index에 값이 있는지 확인
                if (_data[index] != null)
                {
                    for (int i = index; i < Count - 1; i++)
                    {
                        _data[i] = _data[i + 1];
                    }

                    _data[Count - 1] = default(T);
                    Count--;
                }
            }
        }



        public void Run()
        {
            int[] _data = new int[25]; //배열
            MyList<int> _data2 = new MyList<int>(); //동적배열
            LinkedList<int> _data3 = new LinkedList<int>(); //연결리스트 

            _data2.Add(101);
            _data2.Add(102);
            _data2.Add(103);
            _data2.Add(104);
            _data2.Add(105);

            int temp = _data2[2];

            _data2.RemoveAt(2);
        }
    }
}
