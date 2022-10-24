using System;

namespace tp3
{

	public class AVL{
		
		private IComparable dato;
		private AVL hijoIzquierdo;
		private AVL hijoDerecho;
		private int altura;
		
		public AVL(IComparable dato){
			this.dato = dato;
		}
		
		public IComparable getDatoRaiz(){
			return this.dato;
		}
		
		public AVL getHijoIzquierdo(){
			return this.hijoIzquierdo;
		}
		
		public AVL getHijoDerecho(){
			return this.hijoDerecho;
		}
	
		public void agregarHijoIzquierdo(AVL hijo){
			this.hijoIzquierdo=hijo;
		}

		public void agregarHijoDerecho(AVL hijo){
			this.hijoDerecho=hijo;
		}
		
		public void eliminarHijoIzquierdo(){
			this.hijoIzquierdo=null;
		}
		
		public void eliminarHijoDerecho(){
			this.hijoDerecho=null;
		}
		
		public AVL agregar(IComparable elem) {
			//si elem es mayor que el dato almacenado en la raiz
			if (elem.CompareTo(this.getDatoRaiz()) > 0 )
			{
				//si el hijo derecho esta vacio inserto elem
				if(this.getHijoDerecho() == null)
				{
					AVL nuevoHijoDerecho = new AVL(elem);
					this.agregarHijoDerecho(nuevoHijoDerecho);
				}
				else
					this.agregarHijoDerecho(this.getHijoDerecho().agregar(elem));
			}
			//Si elem es menor que el dato almacenado en la raiz 
			else 
			{
                if (elem.CompareTo(this.getDatoRaiz()) <= 0)
                {
                    //si el hijo derecho esta vacio inserto elem
                    if (this.getHijoIzquierdo() == null)
                    {
                        AVL nuevoHijoIzquierdo = new AVL(elem);
                        this.agregarHijoIzquierdo(nuevoHijoIzquierdo);
                    }
                    else
                        this.agregarHijoIzquierdo(this.getHijoIzquierdo().agregar(elem));
                }

            }
			//actualizar altura
			this.actualizarAltura();

			//control de desbalance
			AVL nuevaRaiz = this;
			int balance = this.calcularDesbalance();

			if(balance >= 2) // desbalance del hijo derecho
			{
				if(elem.CompareTo(this.getHijoDerecho().getDatoRaiz())> 0)		// si elem es mayor que hijo derecho, entonces RS con Derecho
					nuevaRaiz = this.rotacionSimpleDerecha();
				else
					nuevaRaiz = this.rotacionDobleDerecha();
			}
			if(balance <= -2)										//desbalance del lado izquierdo
			{
				if(elem.CompareTo(this.getHijoIzquierdo().getDatoRaiz())<= 0)		// si elem es menor que el hijo izquierdo, entonces RS con Izquierdo
					nuevaRaiz = this.rotacionSimpleIzquierda();
				else
					nuevaRaiz = this.rotacionDobleIzquierda();		// si elem es mayor que el hijo izquierdo, entonces RDI
			}
			return nuevaRaiz;
		}
		
		//Rotacion simple CON Derecho
		private AVL rotacionSimpleDerecha() {
            AVL nuevaRaiz = this.getHijoDerecho();
            this.agregarHijoDerecho(nuevaRaiz.getHijoIzquierdo());
            nuevaRaiz.agregarHijoIzquierdo(this);

            this.actualizarAltura();                                     //actualizar altura de vieja raiz
            nuevaRaiz.actualizarAltura();                               //actualizar altura de nueva raiz

            return nuevaRaiz;											//Retornamos nueva raiz
        }
		// Rotacion simple CON izquierdo 
		private AVL rotacionSimpleIzquierda() {
			AVL nuevaRaiz = this.getHijoIzquierdo();					//nueva raiz (8) hijo izquierdo de this == (14)
			this.agregarHijoIzquierdo(nuevaRaiz.getHijoDerecho());		//agrego al nodo 14 el hijo derecho del 8 que seria el 10 como hijo izquierdo
			nuevaRaiz.agregarHijoDerecho(this);                         //agrego el 14 como hijo derecho del 8 

			//actualizar altura de vieja raiz
			this.actualizarAltura();
			//actualizar altura de nueva raiz
			nuevaRaiz.actualizarAltura();
			//Retornamos nueva raiz
			return nuevaRaiz;
		}
		//rotacion doble CON izquierdo 
		private AVL rotacionDobleDerecha()
		{
			//1ero: rotacion simple con izquierdo en hijo derecho
			AVL nuevoHijoDerecho = this.getHijoDerecho().rotacionSimpleIzquierda();
			this.agregarHijoDerecho(nuevoHijoDerecho);

			//2do: rotacion simple con derecho
			return this.rotacionSimpleDerecha();
		
		}
		
			//rotacion doble CON izquierdo	
		private AVL rotacionDobleIzquierda() 
		{
            //1ero: rotacion simple con derecho en hijo izquierdo
            AVL nuevoHijoIzquierdo = this.getHijoIzquierdo().rotacionSimpleDerecha();
            this.agregarHijoIzquierdo(nuevoHijoIzquierdo);

            //2do: rotacion simple con izquierdo
            return this.rotacionSimpleIzquierda();

        }
		private void actualizarAltura()
		{
			int alturaIzq = -1;
			int alturaDer = -1;

			if (this.getHijoIzquierdo() != null)
				alturaIzq = getHijoIzquierdo().altura;

			if(this.getHijoDerecho() != null)
				alturaDer = getHijoDerecho().altura;


			if(alturaDer > alturaIzq)
				this.altura = alturaDer + 1;
			else
				this.altura = alturaIzq + 1;
		}
		
		private int calcularDesbalance()
		{
            int alturaIzq = -1;
            int alturaDer = -1;

            if (this.getHijoIzquierdo() != null)
                alturaIzq = getHijoIzquierdo().altura;

            if (this.getHijoDerecho() != null)
                alturaDer = getHijoDerecho().altura;

			return alturaDer - alturaIzq;
        }
		
	}
}