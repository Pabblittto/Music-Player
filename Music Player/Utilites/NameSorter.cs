using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Utilites
{
    class NameSorter : SorterDecorator
    {
        public NameSorter(ISorter sorter) : base(sorter)
        {
        }

        public override List<Models.Song> Sort()
        {
            List<Models.Song> songList =  base.Sort();

            if (base.sortGroups.Count == 0)
            {
                songList.Sort((x, y) => x.title.CompareTo(y.title));
                return songList;
            } else
            {
                List<Models.Song> tmpGroup = new List<Models.Song>();

            }
        }

        private int comparer(Models.Song item1, Models.Song.item2, string property)
        {
            item1.GetType().GetProperty(property).GetValue(item1, null)
        }
    }
}
