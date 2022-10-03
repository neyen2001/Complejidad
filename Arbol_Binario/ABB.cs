/*
 * Creado por SharpDevelop.
 * Usuario: Neyén
 * Fecha: 2/10/2022
 * Hora: 18:42
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace Arbol_Binario
{
	/// <summary>
	/// Description of ABB.
	/// </summary>
	public class ABB<T> : ArbolBinario<T>
	{
		//no se implementa el set, aunque bastaria con new ABB(value.Dato)
		protected override ArbolBinario<T>? hijoDerecho{get{return(ArbolBinario<T>) Hijos[1];}}
		protected override ArbolBinario<T>? hijoIzquierdo{get{return(ArbolBinario<T>) Hijos[0];}}
		protected ABB<T>[] Hijos = new ABB<T>[2];
		
		public ABB(T dato) : base(dato)
		{
		}
		
		public override void agregarHijoDerecho(ArbolBinario<T> hijo)
		{
			throw new NotImplementedException();
		}
		
		public override void agregarHijoIzquierdo(ArbolBinario<T> hijo)
		{
			throw new NotImplementedException();
		}
		
		public void Agregar(T dato){
			int i = (dato > getDatoRaiz())? 1 : 0;
			if(Hijos[i] == null)
				Hijos[i] = new ABB<T>(dato);
			else
				Hijos[i].Agregar(dato);
		}
		
	}
}
	