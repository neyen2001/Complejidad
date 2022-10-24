using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpGrafos
{
    public class Recorrido<T>
    {
        public List<Vertice<T>> caminoSimpleConDFS(Grafo<T> grafo, Vertice<T> origen, Vertice<T> destino)
        {
            bool[] visitados = new bool[grafo.getVertices().Count];  //creo el vector de visitados
            List<Vertice<T>> list = new();
            return _caminoSimpleConDFS(grafo,origen,destino, visitados,list);          //llamo a un metodo que se creara (recomendacion del profe)
        }
        public List<Vertice<T>> _caminoSimpleConDFS(Grafo<T> grafo, Vertice<T> origen,
               Vertice<T> destino, bool[] visitados, List<Vertice<T>> list)
        {
            list.Add(origen);                //imprimo el origen y coloco un separador
            visitados[origen.getPosicion() - 1] = true;
            if (origen.getDato()!.Equals(destino.getDato()))
                return list;                 //paso el origen de false a true
            foreach (var ady in origen.getAdyacentes())             //ady es una arista, que recorre una lista de aristas adyacentes al origen
            {
                if (!visitados[ady.getDestino().getPosicion() - 1])   //en la arista donde estoy parado me pregunto si el destino de la arista(osea la variable) esta visitada o no
                    _caminoSimpleConDFS(grafo, ady.getDestino(),destino, visitados,list);              //si no fue visitado, llamo recursivamente
            }
            return list;
        }
        public List<Vertice<T>> verticesADistanciaConBFS(Grafo<T> grafo, Vertice<T> origen, int nroDeAristas)
        {
            Queue<Vertice<T>?> c = new();
            List<Vertice<T>> list = new();
            bool[] visitados = new bool[grafo.getVertices().Count];
            Vertice<T>? aux;
            int nivel = 0;

            c.Enqueue(origen);
            c.Enqueue(null);
            visitados[origen.getPosicion() - 1] = true;
            while (c.Count > 0)
            {
                aux = c.Dequeue();
                if (aux == null)
                {
                    nivel++;
                    if (nivel > nroDeAristas)
                        return list;
                    c.Enqueue(null);
                }
                else
                {
                    if (nivel == nroDeAristas)
                        list.Add(aux);

                    foreach (Arista<T> a in aux.getAdyacentes())
                    {
                        if (!visitados[a.getDestino().getPosicion() - 1])
                        {
                            c.Enqueue(a.getDestino());
                            visitados[a.getDestino().getPosicion() - 1] = true;
                        }
                    }
                }
            }
            return list;
        }
    }
}
