using Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api
{
    public class Storage
    {
        private static Storage _instance;

        public static Storage Instance
        {
            get
            {
                if (_instance == null) _instance = new Storage();
                return _instance;
            }
        }

        public MultipathTree<Movie> Tree;
        /*public Arbol<Farmaco> Indice = new Arbol<Farmaco>();
        public Arbol<Farmaco> SinExistencias = new Arbol<Farmaco>();
        public List<FarmacoPrecio> Pedidos = new List<FarmacoPrecio>();
        public string Farmacos;
        public string[] ListadoFarmacos;
        public string dir;*/
    }
}
