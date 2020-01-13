using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Utilites
{
    class Sorter : ISorter
    {
        private List<Music_Player.Models.Song> songList;
        public List<List<ListMusic_Player.Models.Song>> sortGroups; 

        public Sorter(List<Music_Player.Models.Song> songList)
        {
            this.songList = songList;
            this.sortGroups = new List<List<ListMusic_Player.Models.Song>>();
        }

        public List<Song> Sort()
        {
            return songList;
        }
    }
}
