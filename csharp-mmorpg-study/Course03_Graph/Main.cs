using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Course03_Graph
{

    class Graph
    {
        //행렬
        int[,] adj1 = new int[6, 6]
        {
            {0, 1, 0, 1, 0, 0},
            {1, 0, 1, 1, 0, 0},
            {0, 1, 0, 0, 0, 0},
            {1, 1, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 1},
            {0, 0, 0, 0, 1, 0},
        };

        //리스트
        List<int>[] adj2 = new List<int>[]
        {
            new List<int>() {1, 3},
            new List<int>() {0, 2, 3},
            new List<int>() {1},
            new List<int>() {0, 1},
            new List<int>() {5},
            new List<int>() {4},
        };


        bool[] visited = new bool[6];

        public void DFSMatrix(int now)
        {
            Console.WriteLine(now);
            //TODO: now 방문한다.
            visited[now] = true;

            //TODO: now와 연결된 정점들을 하나씩 확인해서, [아직 미방문상태라면] 방문한다.
            int vertexCount = adj1.GetLength(0);

            //BOOKMARK: 행렬 형태릐 그래프를 방문할 때
            for (int neighbor = 0; neighbor < vertexCount; neighbor++)
            {
                if (adj1[now, neighbor] == 0)
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
            foreach (int next in adj2[now])
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


    class Main
    {
        public void Run()
        {
            /*
             * DFS (Depth Fisrt Search)
             * BFS (Breadth First Search)
             */

            Graph graph = new Graph();
            graph.SearchAll();
        }

    }
}

