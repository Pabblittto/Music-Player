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


        public PlaylistCareTaker()
        {
            playlists = new List<Playlist>();
            mementos = new List<List<PlaylistMemento>>();
        }
        public PlaylistMemento getMemento(Playlist playlist, int exactMemento)
        {
            int index = this.playlists.IndexOf(playlist);
            return mementos[index][exactMemento];
        }
        public List<PlaylistMemento> getMementos(Playlist playlist)
        {
            return mementos[playlists.IndexOf(playlist)];
        }
        public void addMemento(PlaylistMemento memento, Playlist playlist)
        {
            if (!playlists.Contains(playlist))
            {
                playlists.Add(playlist);
                mementos.Add(new List<PlaylistMemento>());
                mementos[mementos.Count - 1].Add(memento);
            } 
            else
            {
                mementos[playlists.IndexOf(playlist)].Add(memento);
            }
                
        }
    }
}
