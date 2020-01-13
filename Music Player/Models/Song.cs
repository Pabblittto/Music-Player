using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Models
{
    class Song
    {
        public string title;
        public string artist;
        public DateTime relaseDate;
        public int duration;
        public string album;

        public Song(string title)
        {
            this.title = title;
        }
    }
}
