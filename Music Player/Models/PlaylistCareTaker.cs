using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Models
{
    class PlaylistCareTaker
    {
        public List<List<PlaylistMemento>> mementos;
        public List<Playlist> playlists;

        public PlaylistMemento getMemento(Playlist playlist)
        {
            int index = this.playlists.IndexOf(playlist);
            return mementos[index][mementos.Count()-1];
        }
    }
}
