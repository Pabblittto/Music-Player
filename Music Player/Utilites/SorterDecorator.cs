using Music_Player.Models;
using System.Collections.Generic;
using System.Linq;

namespace Music_Player.Utilites
{
    abstract class SorterDecorator : ISorter
    {
        protected ISorter sorter;
        public List<List<Song>> sortGroups;

        public SorterDecorator(ISorter sorter)
        {
            this.sorter = sorter;
        }

        virtual public List<Song> Sort()
        {
            List<Song> songList = this.sorter.Sort();

            if (sorter.GetSortGroups().Count == 0)
            {
                songList.Sort((x, y) => SortFn(x, y));
                sortGroups = MakeGroups(songList);
                return songList;
            }
            else
            {
                List<List<Song>> childGroups = sorter.GetSortGroups();
                List<List<Song>> newGroups = new List<List<Song>>();
                List<Song> tmpGroup = new List<Song>();

                childGroups = childGroups.Select(group =>
                {
                    group.Sort((x, y) => SortFn(x, y));
                    return group;
                }).ToList();

                List<Song> sortedSongs = childGroups.SelectMany(e => e).ToList();
                sortGroups = MakeGroups(sortedSongs);
                return sortedSongs;
            }
        }

        List<List<Song>> MakeGroups(List<Song> songList) {
            List<List<Song>> groups = new List<List<Song>>();
            List<Song> tmpGroup = new List<Song>();

            for (int i = 0; i < songList.Count; i++)
			{
                if(
                    i == 0 || 
                    (tmpGroup.Count > 0 && songList[i].title.CompareTo(songList[i - 1].title) == 0) || 
                    tmpGroup.Count == 0
                ){
                    tmpGroup.Add(songList[i]);
                } else
                {
                    groups.Add(new List<Song>(tmpGroup));
                    tmpGroup = new List<Song>();
                    tmpGroup.Add(songList[i]);
                }

                if (i == songList.Count - 1 && tmpGroup.Count > 0)
                    groups.Add(new List<Song>(tmpGroup));
			}

            return groups;
        }

        public List<List<Song>> GetSortGroups()
        {
            return sortGroups;
        }

        virtual public int SortFn(Song item1, Song item2)
        {
            return 1;
        }
    }
}
