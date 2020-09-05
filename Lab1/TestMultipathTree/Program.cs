using System;
using System.Collections.Generic;
using Generics;
using TestMultipathTree;
namespace TestMultipathTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int grado;
            try
            {
                Console.WriteLine("Ingrese el numero del grado para el arbol");
                grado = int.Parse(Console.ReadLine());
                MultipathTree<int> tree = new MultipathTree<int>(grado);
                Console.WriteLine("Ingrese los valores");
                var val = Console.ReadLine().Split(',');
                foreach (string n in val)
                {
                    tree.Add(int.Parse(n));
                }
                /*do
                {
                    insertarArbol(tree);
                    Console.WriteLine("¿Desea seguir ingresando valores? 1.Si 2.No");
                    insertar = int.Parse(Console.ReadLine());
                } while (insertar == 1);*/
                Console.WriteLine("Preorden:");
                Console.WriteLine(String(tree.Preorden()));
                Console.WriteLine("Inorden:");
                Console.WriteLine(String(tree.Inorden()));
                Console.WriteLine("Postorden:");
                Console.WriteLine(String(tree.Postorden()));
                Console.WriteLine(tree.Count.ToString());
                tree.Clear();
                Console.ReadLine();
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

        static string String(List<int> val)
        {
            string text = "";
            foreach(int n in val)
            {
                text += n.ToString() + ",";
            }
            return text;
        }
    }
}
