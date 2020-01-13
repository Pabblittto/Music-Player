using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Models
{
    [Serializable]
    class Playlist
    {
        private String PlaylistName;
        private List<Song> songList;

        public Playlist(String name)
        {
            PlaylistName = name;
        }

        public List<Song> getSongs()
        {
            return songList;
        }

        public void addSong(Song newSong)
        {
            songList.Add(newSong);
        }

        public void removeSong(Song songToRemove)
        {
            songList.Remove(songToRemove);
        }

        public void setName(String newName)
        {
            PlaylistName = newName;
        }

        public string getName()
        {
            return PlaylistName;
        }


    }
}
