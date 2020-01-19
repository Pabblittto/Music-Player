using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Models
{
    class DataStorage
    {
        private static DataStorage instance;

        private List<Playlist> playlists;

        private DataStorage()
        {
            playlists = new List<Playlist>();
        }

        public static DataStorage getInstance()
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

        public void addSongs(List<Song> songList)
        {
            Playlist playlist = playlists.Find(item => item.getName().Equals("Unnamed Playlist"));
            if(playlist != null)
                playlist.SongList.AddRange(songList);
            else
            {
                playlist = new Playlist("Unnamed Playlist");
                playlist.SongList.AddRange(songList);
                playlists.Add(playlist);
            }
            return;
        }

        public List<Song> getAllSongs()
        {
            return playlists.SelectMany(playlist => playlist.SongList).ToList();
        }

    }
}
