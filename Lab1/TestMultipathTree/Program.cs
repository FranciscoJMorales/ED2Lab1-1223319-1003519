using System;
using System.Collections.Generic;
using Generics;
using TestMultipathTree;
using System.IO;
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

                int backmenu = 0;
                do
                {

                    Console.WriteLine("¿Qué metodo desea utilizar para la inserción? \n 1.Ingresarlos a través de comas \n 2. Cargar un archivo de texto");
                    int op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            Console.WriteLine("Ingrese los valores");
                            var val = Console.ReadLine().Split(',');
                            foreach (string n in val)
                            {
                                tree.Add(int.Parse(n));
                            }
                            break;
                        case 2:
                            Console.WriteLine("Coloque el txt encima de la consola");
                            string dir = Console.ReadLine();

                            Insertartxt(dir, tree);
                            break;

                    }

                    Console.WriteLine("¿Desea seguir ingresando valores? 1.Si 2.No");
                    backmenu = int.Parse(Console.ReadLine());
                } while (backmenu == 1);

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

        static public void Insertartxt(string dir, MultipathTree<int> tree)
        {
            try
            {
                string archivo;
                using (StreamReader lector = new StreamReader(dir))
                {
                    archivo = lector.ReadToEnd();
                }

                string[] list;
                list = archivo.Split(new char[] { '\r', '\t', '\n', ',', }, StringSplitOptions.RemoveEmptyEntries);
                string[] text = (string[])list.Clone();

                for (int i = 1; i < text.Length; i++)
                {
                    if (text[i] != "")
                    {
                        tree.Add(int.Parse(text[i]));

                    }
                }
            }
            catch
            {
                Console.WriteLine("Carga del archivo erronea, verifique el formato del archivo");
            }
        }
    }
}
