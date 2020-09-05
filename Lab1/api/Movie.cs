using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api
{
    public class Movie : IComparable
    {
        public string Director { get; set; }
        public double ImdbRating { get; set; }
        public string Genre { get; set; }
        public string ReleaseDate { get; set; }
        public int RottenTomatoesRating { get; set; }
        public string Title { get; set; }

        public int CompareTo(object obj)
        {
            return this.Title.CompareTo(((Movie)obj).Title);
        }
    }
}
