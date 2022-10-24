using System;
using System.Collections;

namespace tpGrafos
{
    class Program
    {
        public static void Main(string[] args)
        {
            Grafo<int> grafo = new Grafo<int>();

            grafo.agregarVertice(new Vertice<int>(1));  //1
            grafo.agregarVertice(new Vertice<int>(2));  //2
            grafo.agregarVertice(new Vertice<int>(3));  //3
            grafo.agregarVertice(new Vertice<int>(4));  //4
            grafo.agregarVertice(new Vertice<int>(5));  //5

            grafo.conectar(grafo.vertice(1), grafo.vertice(2), 0);  // 1-2

            grafo.conectar(grafo.vertice(1), grafo.vertice(5), 0);  // 1-5 
            grafo.conectar(grafo.vertice(2), grafo.vertice(3), 0);  // 2-3
            grafo.conectar(grafo.vertice(2), grafo.vertice(4), 0);  // 2-4
            grafo.conectar(grafo.vertice(2), grafo.vertice(5), 0);  // 2-5
            grafo.conectar(grafo.vertice(4), grafo.vertice(3), 0);  // 3-4
            grafo.conectar(grafo.vertice(4), grafo.vertice(5), 0);  // 4-5

            Console.WriteLine("-------- recorrido DFS ----------");
            grafo.DFS(grafo.vertice(1));

            Console.WriteLine("\n\n-------- recorrido BFS ----------");
            grafo.BFS(grafo.vertice(1));

        }
    }
}