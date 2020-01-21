using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Models
{
    public class PlaylistCareTaker
    {
        public List<List<PlaylistMemento>> mementos;
        public List<Playlist> playlists;
        private static PlaylistCareTaker instance;

        private PlaylistCareTaker()
        {
            playlists = new List<Playlist>();
            mementos = new List<List<PlaylistMemento>>();
        }
        public static PlaylistCareTaker getInstance()
        {
            if (instance == null)
                instance = new PlaylistCareTaker();
            return instance;
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
                if(mementos[playlists.IndexOf(playlist)].Count == 0)
                {
                    mementos.Add(new List<PlaylistMemento>());
                }
                mementos[playlists.IndexOf(playlist)].Add(memento);
            }
                
        }
    }
}
