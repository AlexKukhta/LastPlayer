using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player();
            // player.Volume = 20;

            int totalDuration = 0;

            player.Songs = GetSongsData(ref totalDuration, out int minDuration, out int maxDuration);
            Console.WriteLine($"Total: {totalDuration}, Min: {minDuration}, MAX {maxDuration}");

            //TraceInfo(player)

            player.Play();
            player.VolumeUp();
            Console.WriteLine(player.Volume);


            player.VolumeChange(-20);
            Console.WriteLine(player.Volume);
            Console.WriteLine(new string('-', 20));

            player.VolumeChange(400);
            Console.WriteLine(player.Volume);

            player.VolumeChange(500);
            Console.WriteLine(player.Volume);
            player.Stop();


            var song1 = CreateSong();

            player.Songs = new Song[] { song1 };

            var song2 = CreateNamedSong("AcDc");

            var song3 = CreateSong("Acdc", 200);

            player.Songs = new Song[] { song1, song2, song3 };
            player.Play();
            Console.ReadLine();
        }

        public static Song[] GetSongsData(ref int totalDuration, out int minDuration, out int maxDuration)
        {
            minDuration = 1000;
            maxDuration = 0;

            var artist = new Artist();
            artist.Genre = "rock";
            artist.Name = "Bi2";
            Console.WriteLine(artist.Genre);
            Console.WriteLine(artist.Name);

            var artist2 = new Artist("metall");
            Console.WriteLine(artist2.Genre);
            Console.WriteLine(artist2.Name);

            var artist3 = new Artist("AcDc", "rock-n-roll");
            Console.WriteLine(artist3.Name);
            Console.WriteLine(artist3.Genre);

            var album = new Album();
            album.Name = "Rock";
            album.Year = 2000;

            var songs = new Song[10];
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                var Songs = new Song()
                {

                    Duration = random.Next(1000),
                    name = $"Lajki{i}",
                    Album = album,
                    Artist = artist
                };
                songs[i] = Songs;

                totalDuration += Songs.Duration;

                if (Songs.Duration < minDuration)
                {
                    minDuration = Songs.Duration;
                }
                maxDuration = Math.Max(maxDuration, Songs.Duration);
            }

            return songs;
        }

        public static void TraceInfo(Player player)
        {
            Console.WriteLine(player.Songs[0].Artist.Name);
            Console.WriteLine(player.Songs[0].Duration);
            Console.WriteLine(player.Songs.Length);
            Console.WriteLine(player.Volume);
        }

        public static Song CreateSong()
        {
            return new Song { name = "Uknown", Duration = 120 };
        }


        public static Song CreateNamedSong(string name)
        {
            return CreateSong(name, 120);
        }

        public static Song CreateSong(string name, int duration)
        {
            return new Song { name = name, Duration = duration };
        }
    }
}
