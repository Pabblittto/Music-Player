using Music_Player.Models;
using System.Collections.Generic;

namespace Music_Player.Utilites
{
    class Sorter : ISorter
    {
        private List<Song> songList;
        private List<List<Song>> sortGroups; 

        public Sorter(List<Song> songList)
        {
            this.songList = new List<Song>(songList);
            sortGroups = new List<List<Song>>();
        }

        public List<Song> Sort()
        {
            return songList;
        }

        public List<List<Song>> GetSortGroups() { return sortGroups; }

        public int SortFn(Song item1, Song item2)
        {
            return 1;
        }
    }
}
