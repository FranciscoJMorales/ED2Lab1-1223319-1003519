using System;
using Generics;
using TestMultipathTree;
namespace TestMultipathTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int grado, insertar = 1;
            try
            {
                Console.WriteLine("Ingrese el numero del grado para el arbol");
                grado = int.Parse(Console.ReadLine());
                MultipathTree<int> tree = new MultipathTree<int>(grado);

                do
                {
                    insertarArbol(tree);
                    Console.WriteLine("¿Desea seguir ingresando valores? 1.Si 2.No");
                    insertar = int.Parse(Console.ReadLine());
                } while (insertar == 1);

            }
            catch
            {
                Console.WriteLine("Error producido no controlado");
            }
           
            
        }

        static void insertarArbol(MultipathTree<int> tree)
        {
            int valor;
            Console.WriteLine("Ingrese el valor a ingresar");
            tree.Add(valor = int.Parse(Console.ReadLine()));
           
        
        }
    }
}
