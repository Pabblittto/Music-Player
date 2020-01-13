using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Utilites
{
    interface ISorter
    {
        List<List<ListMusic_Player.Models.Song>> sortGroups; 
        List<Music_Player.Models.Song> Sort();
    }
}
