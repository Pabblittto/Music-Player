using System;

namespace Music_Player.Models
{
    class Song
    {
        public string title;
        public string artist;
        public DateTime relaseDate;
        public int duration;
        public string album;

        public Song(string title, DateTime relaseDate)
        {
            this.title = title;
            this.relaseDate = relaseDate;
        }
    }
}
