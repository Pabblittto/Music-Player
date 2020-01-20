using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music_Player.Models;

namespace Music_Player.Utilites
{
    class DurationSorter : SorterDecorator
    {
        public DurationSorter(ISorter sorter) : base(sorter)
        {
        }

        public override int SortFn(Song item1, Song item2)
        {
            return item1.duration.CompareTo(item2.duration);
        }
    }
}
