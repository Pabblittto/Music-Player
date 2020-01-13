using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Utilites
{
    abstract class SorterDecorator : ISorter
    {
        protected ISorter sorter;
        public List<List<ListMusic_Player.Models.Song>> sortGroups;

        public SorterDecorator(ISorter sorter)
        {
            this.sorter = sorter;
        }

        virtual public List<Music_Player.Models.Song> Sort()
        {
            return this.sorter.Sort();
        }
    }
}
