using System.Collections.Generic;
using Music_Player.Models;

namespace Music_Player.Utilites
{
    interface ISorter
    {
        List<Song> Sort();
        List<List<Song>> GetSortGroups();
        int SortFn(Song item1, Song item2);
    }
}
