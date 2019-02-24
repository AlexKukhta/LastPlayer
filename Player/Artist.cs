using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Player
{
    public class Artist
    {
        public Genre Genre { get; }
        public string Name { get; }

        public Artist()
        {

        }

        public Artist(string name, Genre genre)
        {
            this.Name = name;
            this.Genre = genre;
        }
    }
}
