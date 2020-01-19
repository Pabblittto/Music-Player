using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Models
{
    public class PlaylistMemento
    {
        public List<Song> songs;
        public String name;

        public PlaylistMemento(Playlist playlist)
        {
            this.songs = new List<Song>(playlist.getSongs());
            this.name = new String(playlist.getName().ToCharArray());
        }
    }
}
