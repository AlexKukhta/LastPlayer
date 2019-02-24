using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Player
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = "c:\\WavSongs\\songs.xml";
            var directory = "c:\\WavSongs";
            var player = new Player(new ColorSkin(ConsoleColor.Red));
            player.Volume = 20;

            int totalDuration = 0;

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

            if (File.Exists(filePath))
            {
                player.LoadPlaylist(filePath);
            }
            else
            {
                player.Load(directory);
                GenerateLikes(player.GetSongs());
            }


            //var songs = GenerateSongs();

            //GenerateLikes(songs);
            //songs = songs.SortByGenre(Genre.Rock);
            //player.Songs = songs;
            player.Play();

            ListSongs(player);

            //var shuffledSongs = songs.Shuffle(3);

            //Console.WriteLine("SHUFFLE");
            //ListSongs(shuffledSongs);

            player.Stop();

            player.SaveAsPlaylist("c:\\WavSongs\\songs.xml");


            //var a = new Song[] { song1, song3 };
            Console.ReadLine();
        }

        //public static Tuple<string, TimeSpan, bool> GetSongData(Song songs)
        //{
        //    return new Tuple<string, TimeSpan, bool>(songs.name, songs.duration, false);
        //}

        public static void ListSongs(Player player)
        {
            player.NewScreen();

            var songs = player.GetSongs();

            for (var i = 0; i < songs.Count; i++)
            {
                Console.WriteLine("The song is starting play");

                for (var j = 0; j < songs.Count; j++)
                {
                    dynamic songData = GetSongData(songs[j], i == j);
                    
                    TraceInfo(player, songData.title, songData.minutes, songData.seconds, songData.albumYear, songData.likeValue,
                        songData.genre, songData.isSongNext);
                }

                Console.WriteLine("The song is finishing play");
            }
        }

        public static object GetSongData(Song song, bool isSongNext)
        {
            song.Deconstruct(out LikeEnum likeValue, out TimeSpan duration, out string title, out string artistName,
                out Genre genre, out byte[] thumbnale, out string albumName, out int albumYear);

            return new
            {
                title,
                minutes = duration.Minutes,
                seconds = duration.Seconds,
                albumYear,
                likeValue,
                genre,
                isSongNext
            };
        }

        public static List<Song> FilterByGenre(List<Song> songs, Genre genre)
        {
            return songs.OrderBy(s => s.Artist.Genre).ToList();
        }

        public static void TraceInfo(Player player, string title, int minutes, int seconds, int albumYear, LikeEnum likeValue, Genre genre,
            bool isSongNext)
        {
            var output = $"Title {title.ThreeDots(25)}" + Environment.NewLine +
                        $"Minutes {minutes}" + Environment.NewLine +
                        $"Seconds {seconds}" + Environment.NewLine +
                        $"AlbumYear {albumYear}" + Environment.NewLine +
                        $"Genre {genre}" + Environment.NewLine +
                        $"IsNextSong {isSongNext}" + Environment.NewLine;

            switch (likeValue)
            {
                case LikeEnum.NoneLike:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case LikeEnum.Like:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case LikeEnum.Dislike:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }

        }

        public static List<Song> GenerateSongs()
        {
            var songs = new List<Song>();
            var random = new Random();
            var songsCount = random.Next(5, 10);

            for (var i = 0; i < songsCount; i++)
            {
                var modulo = i % 3;
                var genre = Genre.Classic;

                if (modulo == 0)
                {
                    genre = Genre.HipHop;
                }
                else if (modulo == 1)
                {
                    genre = Genre.Rock;
                }

                var song = new Song(new TimeSpan(random.Next(24), random.Next(60), random.Next(60)), $"Title{i.ToString()}", new Artist($"Artist {i.ToString()}", genre), new Album());

                songs.Add(song);
            }

            return songs;
        }
        
        public static void GenerateLikes(List<Song> songs)
        {
            for (var i = 0; i < songs.Count(); i++)
            {
                var modulo = i % 3;

                if (modulo == 0)
                {
                    songs[i].Like();
                }
                else if (modulo == 1)
                {
                    songs[i].Dislike();
                }
            }
        }
    }
}
