using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Player
{
    public class Player
    {
        private ISkin _skin;
        private int _volume;
        private List<Song> songs;
        private string extension = ".wav";

        const int MIN_VOLUME = 0;
        const int MAX_VOLUME = 100;

        public Player(ISkin skin)
        {
            _skin = skin;
            songs = new List<Song>();
        }

        public int Volume
        {
            get{ return _volume;}
            set 
            {
                if (value<MIN_VOLUME)
                {
                    _volume=MIN_VOLUME;
                }
                else if (value > MAX_VOLUME)
                {
                    _volume = MAX_VOLUME;
                }
                else
                {
                    value = _volume;
                }
            }
        }
        
        public void VolumeUp()
        {
            _volume++;
        }

        public void VolumeDown()
        {
            _volume--;
        }

        public void VolumeChange(int step)
        {
             _volume += step;
        }

        public void Play()
        {
            Console.WriteLine("Player is Playing");
        }

        public void Stop()
        {
            Console.WriteLine("Player has Stopped");
        }

        public void Render(string text)
        {
            _skin.Render(text);
        }

        public void NewScreen()
        {
            _skin.Clear();
        }

        public void Add(Song song)
        {
            songs.Add(song);
        }

        public void Remove(Song song)
        {
            songs.Remove(song);
        }

        public void Load(string directoryPath)
        {
            var files = Directory.GetFiles(directoryPath);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                if (string.Equals(extension, fileInfo.Extension))
                {
                    var name = fileInfo.Name;
                    var duration = new TimeSpan(fileInfo.Length);

                    var song = new Song(duration, name);

                    Add(song);
                }
            }
        }

        public void ClearSongs()
        {
            songs.Clear();
        }

        public List<Song> GetSongs()
        {
            return songs;
        }

        public void SaveAsPlaylist(string filePath)
        {
            var formatter = new XmlSerializer(typeof(List<Song>));

            var fs = new FileStream(filePath, FileMode.Create);
            formatter.Serialize(fs, songs);
            fs.Close();
        }

        public void LoadPlaylist(string filePath)
        {
            var formatter = new XmlSerializer(typeof(List<Song>));
            var fs = new FileStream(filePath, FileMode.Open);

            songs = (List<Song>)formatter.Deserialize(fs);

            fs.Close();
        }
    }
}
