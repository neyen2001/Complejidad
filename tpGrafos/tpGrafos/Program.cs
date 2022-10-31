using System;
using System.Collections;

namespace tpGrafos
{
    class Program
    {
        public static void Main(string[] args)
        {
            Grafo<int> grafo = new Grafo<int>();
           
            grafo.agregarVertice(new Vertice<int>(1));      //1
            grafo.agregarVertice(new Vertice<int>(2));      //2
            grafo.agregarVertice(new Vertice<int>(3));      //3
            grafo.agregarVertice(new Vertice<int>(4));      //4
            grafo.agregarVertice(new Vertice<int>(5));      //5
            grafo.agregarVertice(new Vertice<int>(6));      //6
            grafo.agregarVertice(new Vertice<int>(7));      //7

            grafo.conectar(grafo.vertice(1), grafo.vertice(2), 0);  // 1-2
            grafo.conectar(grafo.vertice(1), grafo.vertice(4), 0);  // 1-4 
            grafo.conectar(grafo.vertice(2), grafo.vertice(5), 0);  // 2-5 
            grafo.conectar(grafo.vertice(3), grafo.vertice(5), 0);  // 3-5
            grafo.conectar(grafo.vertice(4), grafo.vertice(2), 0);  // 4-2
            grafo.conectar(grafo.vertice(4), grafo.vertice(5), 0);  // 4-5
            grafo.conectar(grafo.vertice(4), grafo.vertice(6), 0);  // 4-6
            grafo.conectar(grafo.vertice(4), grafo.vertice(3), 0);  // 4-3
            grafo.conectar(grafo.vertice(5), grafo.vertice(7), 0);  // 5-7
            grafo.conectar(grafo.vertice(6), grafo.vertice(3), 0);  // 6-3
            grafo.conectar(grafo.vertice(6), grafo.vertice(7), 0);  // 6-7


            //Console.WriteLine("-------- recorrido DFS ----------");
            //grafo.DFS(grafo.vertice(1));

            //Console.WriteLine("\n\n-------- recorrido BFS ----------");
            //grafo.BFS(grafo.vertice(1));

            //Console.WriteLine("\n");
            //Console.WriteLine("---------recorridoSimpleDFS-----------");
            //bool x = new RecorridoV2<int>().caminoSimpleConDFS2(grafo, grafo.vertice(1), grafo.vertice(6));

            //Console.WriteLine("\n");
            //Console.WriteLine("--------verticesADistanciaConBFS---------");
            //list = new Recorrido<int>().verticesADistanciaConBFS(grafo,o,2);
            //foreach (var v in list)
            //    Console.WriteLine(v.getDato());

         //   Console.WriteLine("\n");
          //  Console.WriteLine("---Menor cantidad de aristas---");
           // RecorridoV2<int> mejorCamino = new RecorridoV2<int>().mejorCamino(grafo, grafo.vertice(1), grafo.vertice(7));
           // RecorridoV2<int>().mejorCamino(grafo, grafo.vertice(1), grafo.vertice(7));

            RecorridoV2<int> mejorNeyen = new RecorridoV2<int>();
            mejorNeyen.mejorCamino(grafo, grafo.vertice(1), grafo.vertice(7));



            Console.WriteLine();
        }
    }
}
