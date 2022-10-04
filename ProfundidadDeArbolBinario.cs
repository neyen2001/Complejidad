/*
 * Creado por SharpDevelop.
 * Usuario: Neyén
 * Fecha: 2/9/2022
 * Hora: 14:19
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;

namespace Arbol_Binario
{
	/// <summary>
	/// Description of ProfundidadDeArbolBinario.
	/// </summary>
	public class ProfundidadDeArbolBinario
	{
		private ArbolBinario<int> arbolA;
		
		public ProfundidadDeArbolBinario()
		{
		}
		
		public ProfundidadDeArbolBinario(ArbolBinario<int> arbolA){
			this.arbolA = arbolA;
		}
		
		public int sumaElementosProfundidad(int n){
            if (n < 0)
                throw new Exception("n debe ser mayor o igual a 0");

           Queue<ArbolBinario<int>> c = new Queue<ArbolBinario<int>>();
            ArbolBinario<int> arbolAux;
            int nivelParaEncolar = 0;
            int nodosDelNivel = 1;
            int suma = 0;
            
            c.Enqueue(arbolA);

            while (c.Count != 0)
            {
                //Si el nivel esta evaluado en su totalidad 
                if (nodosDelNivel >= Math.Pow(2, nivelParaEncolar))
				{
					nivelParaEncolar++;
                    nodosDelNivel = 0;
				}

                arbolAux = c.Dequeue();

                // Termina de desencolar los que no se deben imprimr, al terminar de encolar
                // el primer nivel a mostrar. Esto se debe a que termina de 
                // encolar un nivel cuando desencola el ultimo padre de los nodos
                // de ese nivel.
                if (nivelParaEncolar > n){
                	suma = arbolAux.getDatoRaiz() + suma;
                }
                // Me quedan niveles por encolar
                if (nivelParaEncolar <= n)
                {
                	if (arbolAux.getHijoIzquierdo() != null)
                		c.Enqueue(arbolAux.getHijoIzquierdo());

                	if (arbolAux.getHijoDerecho() != null)
                		c.Enqueue(arbolAux.getHijoDerecho());

                    nodosDelNivel += 2;
                }
            }

			if (nivelParaEncolar != ++n)
				throw new Exception("el arbol no tiene tantos niveles");
			
			return suma;
			
		}

		
	}
}
