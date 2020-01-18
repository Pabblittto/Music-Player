using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Models
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Playlist
    {
        public String PlaylistName { get; set; }
        public List<Song> SongList { get; set; }

        public Playlist(String name)
        {
            PlaylistName = name;
            SongList = new List<Song>();
        }
        public Playlist()
        {
            PlaylistName = "";
            SongList = new List<Song>();
        }

        public List<Song> getSongs()
        {
            return SongList;
        }

        public void addSong(Song newSong)
        {
            SongList.Add(newSong);
        }

        public void removeSong(Song songToRemove)
        {
            SongList.Remove(songToRemove);
        }

        public void setName(String newName)
        {
            PlaylistName = newName;
        }
        public void setSongs(List<Song> songs)
        {
            SongList = songs;
        }
        public string getName()
        {
            return PlaylistName;
        }


    }
}
