using System;
using System.Collections.Generic;
using System.Text;

namespace Course03_Graph
{
    /*
     * BFS는 최단거리 찾을 때 주로 사용됨
     * 
     */
    class BFSPractice
    {

        public void Run()
        {
            BFS(0);
        }


        public void BFS(int start)
        {
            bool[] found = new bool[6]; //각 정점 방문여부 확인
            int[] distance = new int[6]; //start로 부터 해당 정점까지의 거리
            int[] parent = new int[6]; //해당 정점의 직전 정점


            Queue<int> queue = new Queue<int>();
            //예약
            queue.Enqueue(start);

            //방문
            found[start] = true;
            distance[start] = 0;
            parent[start] = 0;

            while (queue.Count > 0)
            {
                int now = queue.Dequeue();
                Console.WriteLine(now);

                //TODO: 한번도 발견하지 않았으면 예약을 한다.
                for (int next = 0; next < Graph.matrix.GetLength(0); next++)
                {

                    //TODO: 연결 안되어있으면 컨티뉴
                    if (Graph.matrix[now, next] == 0)
                        continue;

                    //TODO: 이미 발견한 곳이면 컨티뉴
                    if (found[next] == true)
                        continue;


                    //큐에 넣음
                    queue.Enqueue(next);
                    found[next] = true;
                    distance[next] = distance[now] + 1;
                    parent[next] = now;
                }

            }


        }

    }
}
