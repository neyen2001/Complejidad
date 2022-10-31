using System;
using System.Collections;
using System.Collections.Generic;

namespace tpGrafos
{
	/// <summary>
	/// Description of Grafo.
	/// </summary>
	public class Grafo<T>
	{
		public Grafo()
		{
		}
		
		private List<Vertice<T>>vertices = new List<Vertice<T>>();
	
		public void agregarVertice(Vertice<T> v) {
			v.setPosicion(vertices.Count + 1);
			vertices.Add(v);
		}

		public void eliminarVertice(Vertice<T> v) {
			vertices.Remove(v);
		}

		public void conectar(Vertice<T> origen, Vertice<T> destino, int peso) {
			origen.getAdyacentes().Add(new Arista<T>(destino,peso));
		}

		public void desConectar(Vertice<T> origen, Vertice<T> destino) {
			Arista<T> arista = origen.getAdyacentes().Find(a => a.getDestino().Equals(destino));
			origen.getAdyacentes().Remove(arista);
		}

	
		public List<Vertice<T>> getVertices() {
			return vertices;
		}

	
		public Vertice<T> vertice(int posicion) {
			return this.vertices[posicion-1];
		}

        public void DFS(Vertice<T> origen) {
			bool[] visitados = new bool[this.getVertices().Count];	//creo el vector de visitados
			_DFS(origen, visitados);								//llamo a un metodo que se creara (recomendacion del profe)
		}
		private void _DFS(Vertice<T> origen, bool[] visitados)
		{
			Console.Write(origen.getDato() + " | ");				//imprimo el origen y coloco un separador
			visitados[origen.getPosicion()-1] = true;					//paso el origen de false a true
			foreach(var ady in origen.getAdyacentes())				//ady es una arista, que recorre una lista de aristas adyacentes al origen
			{
				if (!visitados[ady.getDestino().getPosicion()-1])   //en la arista donde estoy parado me pregunto si el destino de la arista(osea la variable) esta visitada o no
					_DFS(ady.getDestino(), visitados);				//si no fue visitado, llamo recursivamente
			}
		}

		public void BFS(Vertice<T> origen) {
			Queue<Vertice<T>> c = new ();
			bool[] visitados = new bool[getVertices().Count];
            Vertice<T> aux; 

            c.Enqueue(origen);
			visitados[origen.getPosicion() - 1] = true;
			while (c.Count > 0)
			{
				aux = c.Dequeue();
				Console.Write(aux.getDato() + " | ");
				
				foreach(Arista<T> a in aux.getAdyacentes())
				{
					if (!visitados[a.getDestino().getPosicion() - 1])
					{
						c.Enqueue(a.getDestino());
						visitados[a.getDestino().getPosicion() - 1] = true;
					}
				}
			}
		}


	}
}
