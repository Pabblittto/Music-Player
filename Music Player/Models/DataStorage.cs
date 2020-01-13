using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Models
{
    class DataStorage
    {
        private DataStorage instance;

        private List<Playlist> playlists;

        private DataStorage()
        {
            playlists = new List<Playlist>();
        }

        public DataStorage getInstance()
        {
            if (instance == null)
                instance = new DataStorage();
            return instance;
        }

        public List<Playlist> GetPlaylists()
        {
            return playlists;
        }

        public void AddPlaylist(Playlist newPlaylist)
        {
            playlists.Add(newPlaylist);
        }

    }
}
