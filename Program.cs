/*
 * Creado por SharpDevelop.
 * Usuario: Neyén
 * Fecha: 29/8/2022
 * Hora: 22:49
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace Arbol_Binario
{
	class Program
	{
		public static void Main(string[] args)
		{
			//ArbolBinario<int> arbolBinarioA = new ArbolBinario<int>(1);

			//ArbolBinario<int> hijoIzquierdo = new ArbolBinario<int>(2);
			//hijoIzquierdo.agregarHijoIzquierdo(new ArbolBinario<int>(4));
			//hijoIzquierdo.agregarHijoDerecho(new ArbolBinario<int>(5));

			//ArbolBinario<int> hijoDerecho = new ArbolBinario<int>(3);
			//hijoDerecho.agregarHijoIzquierdo(new ArbolBinario<int>(6));
			//hijoDerecho.agregarHijoDerecho(new ArbolBinario<int>(7));

			//arbolBinarioA.agregarHijoIzquierdo(hijoIzquierdo);
			//arbolBinarioA.agregarHijoDerecho(hijoDerecho);

			////arbol binario para poder hacer el ejercicio 8
			//ArbolBinario<string> arbolBinarioB = new ArbolBinario<string>("-");

			//ArbolBinario<string> hijoIzquierdoB = new ArbolBinario<string>("+");

			//hijoIzquierdoB.agregarHijoIzquierdo(new ArbolBinario<string>("A"));
			//hijoIzquierdoB.agregarHijoDerecho(new ArbolBinario<string>("B"));

			//ArbolBinario<string> hijoDerechoB = new ArbolBinario<string>("+");

			//ArbolBinario<string> hijoPadre = new ArbolBinario<string>("*");
			//hijoDerechoB.agregarHijoIzquierdo(hijoPadre);
			//hijoDerechoB.agregarHijoDerecho(new ArbolBinario<string>("E"));

			//arbolBinarioB.agregarHijoIzquierdo(hijoIzquierdoB);
			//arbolBinarioB.agregarHijoDerecho(hijoDerechoB);

			//ArbolBinario<string> nietoIzquierdo = new ArbolBinario<string>("C");
			//ArbolBinario<string> nietoDerecho = new ArbolBinario<string>("D");

			//hijoPadre.agregarHijoIzquierdo(nietoIzquierdo);
			//hijoPadre.agregarHijoDerecho(nietoDerecho);

			//arbolBinarioB.inorden();


			//Console.Write("recorrido por niveles: ");

			//arbolBinarioA.recorridoPorNiveles();

			//Console.Write("Recorrido entre niveles: ");
			//arbolBinarioA.recorridoEntreNiveles(1,1);
			//Console.WriteLine("La cantidad de hojas son: " + arbolBinarioA.ContarHojas());

			//ProfundidadDeArbolBinario tree = new ProfundidadDeArbolBinario(arbolBinarioA);
			//Console.WriteLine(tree.sumaElementosProfundidad(2));
			//Console.WriteLine(arbolBinarioA.incluye(7));
			//ProfundidadDeArbolBinario arbolNeyen = new ProfundidadDeArbolBinario(arbolBinarioA);
			//Console.WriteLine(arbolNeyen.sumaElementosProfundidad(1));

			//RedBinariaLlena redNeyen = new RedBinariaLlena(arbolBinarioA);
			//Console.WriteLine(redNeyen.retardoReenvio());
			//RedBinariaLlena redneyen2 = new RedBinariaLlena(hijoIzquierdo);
			//Console.WriteLine(redneyen2.retardoReenvio());

			ABB<int> t = new ABB<int>(3);
			int[] v = { 1, 4, 6, 8, 2, 5, 7 };
			for (int i = 0; i < v.Length; i++)
				t.Agregar(v[i]);
			t.recorridoPorNiveles();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}