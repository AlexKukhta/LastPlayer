using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Player
{
    [Serializable]
    public class Song : ISerializable
    {
        public LikeEnum LikeValue { get; private set; }
        public TimeSpan Duration { get; }
        public string Title { get; }
        public Artist Artist { get; }
        public Album Album { get; }

        public Song()
        {
            Artist = new Artist();
            Album = new Album();
        }

        public Song(TimeSpan duration, string title) : this()
        {
            Duration = duration;
            Title = title;
            LikeValue = LikeEnum.NoneLike;
        }

        public Song(TimeSpan duration, string title, Artist artist, Album album) : this(duration, title)
        {
            Artist = artist;
            Album = album;
        }

        protected Song(SerializationInfo info, StreamingContext context)
        {
            LikeValue = (LikeEnum)info.GetValue("LikeValue", typeof(LikeEnum));
            Duration = (TimeSpan)info.GetValue("Duration", typeof(TimeSpan));
            Title = (string)info.GetValue("Title", typeof(string));
            Artist = (Artist)info.GetValue("Artist", typeof(Artist));
            Album = (Album)info.GetValue("Album", typeof(Album));
        }

        public void Like()
        {
            LikeValue = LikeEnum.Like;
        }

        public void Dislike()
        {
            LikeValue = LikeEnum.Dislike;
        }

        public void Deconstruct(out LikeEnum likeValue, out TimeSpan duration, out string title, out string artistName,
            out Genre genre, out byte[] thumbnale, out string albumName, out int albumYear)
        {
            likeValue = LikeValue;
            duration = Duration;
            title = Title;
            artistName = string.Empty;
            genre = Artist.Genre;
            thumbnale = new byte[0];
            albumName = string.Empty;
            albumYear = Album.Year;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("LikeValue", LikeValue);
            info.AddValue("Duration", Duration);
            info.AddValue("Title", Title);
            info.AddValue("Artist", Artist);
            info.AddValue("Album", Album);
        }
    }
}
