using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Player
{
    public static class SongsExtension
    {
        public static List<Song> SortByGenre(this List<Song> songs, Genre genre)
        {
            var newList = new List<Song>();

            foreach(var item in songs)
            {
                if (item.Artist.Genre == genre)
                {
                    newList.Add(item);
                }
            }

            foreach (var item in songs)
            {
                if (item.Artist.Genre != genre)
                {
                    newList.Add(item);
                }
            }

            return newList;
        }

        public static List<Song> Shuffle(this List<Song> songs, int initialStep)
        {
            for(var i = initialStep; i > 0; i--)
            {
                var j = 0;
                for(j += initialStep; j < songs.Count; j++)
                {
                    var temp = songs[j];
                    songs[j] = songs[j - initialStep];
                    songs[j - initialStep] = temp;
                }
            }

            return songs;
        }
    }
}
