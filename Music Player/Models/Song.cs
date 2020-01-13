]using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Models
{
    [Serializable]
    class Song
    {
        public string title;
        public string artist;
        public DateTime releaseDate;
        public TimeSpan duration;
        public string album;
        public string path;
    }
}
