using Music_Player.Models;

namespace Music_Player.Utilites
{
    class NameSorter : SorterDecorator
    {
        public NameSorter(ISorter sorter) : base(sorter)
        {
        }

        public override int SortFn(Song item1, Song item2)
        {
            return item1.title.CompareTo(item2.title);
        }
    }
}
