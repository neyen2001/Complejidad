using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace tpGrafos
{
    internal class RecorridoV2<T>
    {
        public bool caminoSimpleConDFS2(Grafo<T> grafo, Vertice<T> origen, Vertice<T> destino)
        {
            bool[] visitados = new bool[grafo.getVertices().Count];                         
            List<Vertice<T>> camino = new();
            return _caminoSimpleConDFS2(grafo, origen, destino, visitados, camino);          
        }
        public bool _caminoSimpleConDFS2(Grafo<T> grafo,Vertice<T> origen, Vertice<T> destino, bool[] visitados, List<Vertice<T>> camino)
        {
            bool ok = false;
            camino.Add(origen);
            visitados[origen.getPosicion() - 1] = true;
            if (origen.getDato()!.Equals(destino.getDato()))
            {
                foreach (var v in camino)
                    Console.Write(v.getDato() + " | ");
                return true;
            }
            foreach(Arista<T> ady in origen.getAdyacentes())
            {
                if (!visitados[ady.getDestino().getPosicion() - 1])
                {
                    ok = _caminoSimpleConDFS2(grafo, ady.getDestino(), destino, visitados, camino);
                    if (ok)
                        return true;
                }
                camino.Remove(ady.getDestino());

            }
            //camino.Remove(origen);
            return ok;

        }
        //Implemente en una adaptación del recorrido DFS para buscar el camino que transite por la menor cantidad de aristas entre dos vértices que se reciben como parámetro.
        public void mejorCamino(Grafo<T> grafo, Vertice<T> origen, Vertice<T> destino)
        {
            bool[] visitados = new bool[grafo.getVertices().Count];                         
            List<Vertice<T>> camino = new();
            List<Vertice<T>> mejorCamino = new();
            mejorCamino = _mejorCamino(grafo, origen, destino, visitados, camino, mejorCamino);
            foreach (var v in mejorCamino)
                Console.Write(v.getDato() + " | ");
        }

        private List<Vertice<T>> _mejorCamino(Grafo<T> grafo, Vertice<T> origen, Vertice<T> destino, bool[] visitados, List<Vertice<T>> camino, List<Vertice<T>> mejorCamino)
        {
            camino.Add(origen);               
            visitados[origen.getPosicion() - 1] = true;
            if (origen.Equals(destino))
                if(mejorCamino.Count==0 || camino.Count < mejorCamino.Count)
                {
                    mejorCamino.Clear();
                    mejorCamino.AddRange(camino);
                }
            foreach (var ady in origen.getAdyacentes())             
            {
                if (!visitados[ady.getDestino().getPosicion() - 1])
                {
                    mejorCamino = _mejorCamino(grafo, ady.getDestino(), destino, visitados, camino, mejorCamino);
                    visitados[ady.getDestino().getPosicion() - 1] = false;
                    camino.RemoveAt(camino.Count-1);
                }
            }
            return mejorCamino;
        }

    }
}
