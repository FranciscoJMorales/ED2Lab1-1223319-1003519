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
            try
            {
                Console.WriteLine("Ingrese el numero del grado para el arbol");
                int grado = int.Parse(Console.ReadLine());
                MultipathTree<int> tree = new MultipathTree<int>(grado);
                Console.WriteLine("Ingrese los valores");
                var val = Console.ReadLine().Split(',');
                foreach (string n in val)
                {
                    tree.Add(int.Parse(n));
                }
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

        static string String(List<int> val)
        {
            string text = "";
            foreach(int n in val)
            {
                text += n.ToString() + ",";
            }
            if (text.EndsWith(','))
                text = text.Remove(text.Length - 1);
            return text;
        }
    }
}
