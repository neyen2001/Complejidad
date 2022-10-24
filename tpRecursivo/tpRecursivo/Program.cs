using System;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

namespace tpRecursivo
{
    class Program
    {
        public static void Main(string[] args)
            {
            static int rec2(int n)
            {
                if (n <= 1)
                    return 1;
                else
                    return (2 * rec2(n - 1));
            }

            static int rec1(int n)
            {
                if (n <= 1)
                    return 1;
                else
                    return (rec1(n - 1) + rec1(n - 1));
             }
            static int rec3(int n)
            {
                if (n == 0)
                    return 0;
                else
                {
                    if (n == 1)
                        return 1;
                    else
                        return (rec3(n - 2) * rec3(n - 2));
                }
            }
            static double rec4 (int n)
            {
                if (n == 1)
                    return 1;
                else
                        return 8 * rec4(n / 2) + Math.Pow(n,3);
             }
            
            static double rec5(int n)
            {
                if (n == 0)
                    return 0;
                else
                {
                    if (n == 1)
                        return 1;
                    else
                        return Math.Pow(rec5(n - 2), 2);
                }    
            }
            static int funcion(int n)
            {
                
                if (n <= 1)
                    return 1;
                else
                {
                   
                    return funcion(n / 2) + funcion(n / 2);
                }
            }


            Console.WriteLine("ingrese una numero: ");
             int num =int.Parse(Console.ReadLine()!);
             int resultado = funcion(num);
             Console.WriteLine(resultado);

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}