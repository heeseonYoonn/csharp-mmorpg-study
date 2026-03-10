using System;
using System.Collections.Generic;
using System.Text;

namespace Course03_Graph
{
    class DFSPractice
    {

        public void Run()
        {
            SearchAll();
        }

        bool[] visited = new bool[6];

        public void DFSMatrix(int now)
        {
            Console.WriteLine(now);
            //TODO: now 방문한다.
            visited[now] = true;

            //TODO: now와 연결된 정점들을 하나씩 확인해서, [아직 미방문상태라면] 방문한다.
            int vertexCount = Graph.matrix.GetLength(0);

            //BOOKMARK: 행렬 형태의 그래프를 방문할 때
            for (int neighbor = 0; neighbor < vertexCount; neighbor++)
            {
                if (Graph.matrix[now, neighbor] == 0)
                    continue;

                if (visited[neighbor])
                    continue;

                DFSMatrix(neighbor);

            }
        }

        public void DFSList(int now)
        {
            Console.WriteLine(now);

            //TODO: now 방문한다.
            visited[now] = true;

            //TODO: now와 연결된 정점들을 순차적으로 확인한다.
            foreach (int next in Graph.list[now])
            {
                //TODO: 이미 방문한 정점이면 continue
                if (visited[next])
                    continue;

                //TODO: 아직 미방분 상태인 네이버를 방문한다.
                DFSList(next);
            }
        }

        //모두 순회하여 방문하지 않은 정점에 대해 다시 DFS
        public void SearchAll()
        {
            visited = new bool[6];

            for (int i = 0; i < visited.Length; i++)
            {
                if (visited[i])
                    continue;

                DFSList(i);

            }

        }
    }
}
