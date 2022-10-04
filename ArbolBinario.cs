using System;
using System.Collections.Generic;

namespace Arbol_Binario
{
	public class ArbolBinario<T>
	{
		protected T dato;
		protected virtual ArbolBinario<T> hijoIzquierdo{get;set;}
		protected virtual ArbolBinario<T> hijoDerecho{get;set;}
	
		
		public ArbolBinario(T dato) {
			this.dato = dato;
		}
	
		public T getDatoRaiz() {
			return this.dato;
		}
	
		public ArbolBinario<T> getHijoIzquierdo() {
			return this.hijoIzquierdo;
		}
	
		public ArbolBinario<T> getHijoDerecho() {
			return this.hijoDerecho;
		}
	
		public virtual void agregarHijoIzquierdo(ArbolBinario<T> hijo) {
			this.hijoIzquierdo = hijo;
		}
	
		public virtual void agregarHijoDerecho(ArbolBinario<T> hijo) {
			this.hijoDerecho = hijo;
		}
	
		public void eliminarHijoIzquierdo() {
			this.hijoIzquierdo = null;
		}
	
		public void eliminarHijoDerecho() {
			this.hijoDerecho = null;
		}
	
		public bool esHoja() {
			return this.hijoIzquierdo == null && this.hijoDerecho == null;
		}
		
		public void inorden() {
			// hijo izquierdo recursivamente
			if(this.hijoIzquierdo != null)
				this.hijoIzquierdo.inorden();
			
			// se procesa raiz
			Console.Write(this.dato + " ");
			
			// hijo derecho recursivamente
			if(this.hijoDerecho != null)
				this.hijoDerecho.inorden();
		}
		
		public void preorden() {
			// se procesa raiz
			Console.Write(this.dato + " ");
			
			// hijo izquierdo recursivamente
			if(this.hijoIzquierdo != null)
				this.hijoIzquierdo.preorden();
			
			// hijo derecho recursivamente
			if(this.hijoDerecho != null)
				this.hijoDerecho.preorden();
		}
		
		public void postorden() {
			// hijo izquierdo recursivamente
			if(this.hijoIzquierdo != null)
				this.hijoIzquierdo.postorden();
			
			// hijo derecho recursivamente
			if(this.hijoDerecho != null)
				this.hijoDerecho.postorden();
			
			// se procesa raiz
			Console.Write(this.dato + " ");
		}
		
		public void recorridoPorNiveles() {
			Queue<ArbolBinario<T>> c = new Queue<ArbolBinario<T>>();
			ArbolBinario<T> arbolAux;
			
			c.Enqueue(this);
			
			while(c.Count != 0){
				arbolAux = c.Dequeue();
				
				Console.Write(arbolAux.dato + " ");
				
				if(arbolAux.hijoIzquierdo != null)
					c.Enqueue(arbolAux.hijoIzquierdo);
				
				if(arbolAux.hijoDerecho != null)
					c.Enqueue(arbolAux.hijoDerecho);
			}
		}
	

		public int ContarHojas() {
			int a = 0;
			if (this.hijoIzquierdo != null)
				a = this.hijoIzquierdo.ContarHojas();
			if (this.hijoDerecho != null)
				a += this.hijoDerecho.ContarHojas();
			if (a == 0)
				return 1;
			return a;
		}
		
		public void recorridoEntreNiveles(int n,int m) {
            Queue<ArbolBinario<T>> c = new Queue<ArbolBinario<T>>();
            ArbolBinario<T> arbolAux;

            if (n < 0)
                throw new Exception("n debe ser mayor o igual a 0");

            if (m < n)
                throw new Exception("m debe ser mayor o igual a n");

            c.Enqueue(this);
            int nivelParaEncolar = 0;
            int nodosDelNivel = 1;

            while (c.Count != 0)
            {
                //Si el nivel esta evaluado en su totalidad 
                if (nodosDelNivel >= Math.Pow(2, nivelParaEncolar))
				{
					nivelParaEncolar++;
                    nodosDelNivel = 0;
					Console.WriteLine("||");
				}

                arbolAux = c.Dequeue();

                // Termina de desencolar los que no se deben imprimr, al terminar de encolar
                // el primer nivel a mostrar. Esto se debe a que termina de 
                // encolar un nivel cuando desencola el ultimo padre de los nodos
                // de ese nivel.
                if (nivelParaEncolar > n)
                    Console.Write(arbolAux.dato + " ");

                // Me quedan niveles por encolar
                if (nivelParaEncolar <= m)
                {
                    if (arbolAux.hijoIzquierdo != null)
						c.Enqueue(arbolAux.hijoIzquierdo);
					
				    if (arbolAux.hijoDerecho != null)
						c.Enqueue(arbolAux.hijoDerecho);

					
                    nodosDelNivel += 2;
                }
            }

			if (nivelParaEncolar != ++m)
				Console.WriteLine("el arbol no tiene tantos niveles");
        }
		
		public bool incluye(T dato){
			bool esta = false;
			if (dato.Equals(getDatoRaiz()))
				return true;
			// hijo izquierdo recursivamente
			if(this.hijoIzquierdo != null)
				esta = this.hijoIzquierdo.incluye(dato);
			
				
			// hijo derecho recursivamente
			if(!esta && this.hijoDerecho != null)
				esta = this.hijoDerecho.incluye(dato);
			
			return esta;
	
		}
		
		
		
		
		
		
		
		
	}
}
