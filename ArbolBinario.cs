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
            Queue<ArbolBinario<T>?> c = new();
            ArbolBinario<T>? e;
            c.Enqueue(this);
            c.Enqueue(null);
            int nivel = 0;
			string s = "";
            while (c.Count > 1)
            {
                if ((e = c.Dequeue()) == null)
                {
                    if (++nivel > m)
                        return; 
					c.Enqueue(null);
					s += "\n";
                }
                else
                {
					if ( nivel >= n )
						s += e.dato;
					if (e.hijoIzquierdo != null)
					{
						c.Enqueue(e.hijoIzquierdo);
						s += "i";
					}
                    if (e.hijoDerecho != null)
					{
                        c.Enqueue(e.hijoDerecho);
						s += "d";
                    }
					s += " ";
                }
            }
			Console.WriteLine(s);
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
