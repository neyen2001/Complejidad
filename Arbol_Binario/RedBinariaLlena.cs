/*
 * Creado por SharpDevelop.
 * Usuario: Neyén
 * Fecha: 7/9/2022
 * Hora: 21:12
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;

namespace Arbol_Binario
{
	/// <summary>
	/// Description of RedBinariaLlena.
	/// </summary>
	public class RedBinariaLlena
	{
		private ArbolBinario<int> arbolA;
		public RedBinariaLlena()
		{
		}
		
		public RedBinariaLlena(ArbolBinario<int> arbolA){
			this.arbolA = arbolA;
		}
		
		
		public int retardoReenvio(){
			Queue<ArbolBinario<int>> c = new Queue<ArbolBinario<int>>();
            ArbolBinario<int> arbolAux;

           
            c.Enqueue(arbolA);
            int nivelParaEncolar = 0;
            int nodosDelNivel = 1;
            while (c.Count != 0)
            {
            	
                //Si el nivel esta evaluado en su totalidad 
                if (nodosDelNivel >= Math.Pow(2, nivelParaEncolar))
				{
                	
					nivelParaEncolar++;
                    nodosDelNivel = 0;
      
				}

                arbolAux = c.Dequeue();
        
                if (arbolAux.getHijoIzquierdo() != null)
                	c.Enqueue(arbolAux.getHijoIzquierdo());

                if (arbolAux.getHijoDerecho() != null)
                	c.Enqueue(arbolAux.getHijoDerecho());

                
                    nodosDelNivel += 2;
                    
            }
            
            return nivelParaEncolar-1;
			
		}
		
		
	}
}
