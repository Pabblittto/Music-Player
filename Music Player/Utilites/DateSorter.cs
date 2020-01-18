using Music_Player.Models;

namespace Music_Player.Utilites
{
    class DateSorter : SorterDecorator
    {
        public DateSorter(ISorter sorter) : base(sorter)
        {
        }

        public override int SortFn(Song item1, Song item2)
        {
            return item1.relaseDate.CompareTo(item2.relaseDate);
        }
    }
}
