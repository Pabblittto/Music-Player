using System.Collections.Generic;
using Music_Player.Models;

namespace Music_Player.IoService
{
    interface IIOService
    {
        List<Song> SearchDirectory(string dir);
        Playlist ReadPlaylist(string dir);
        void SavePlaylist(Playlist playlist, string dir, SaveFormat format);
    }

    enum SaveFormat
    {
       XML = 1,
       JSON = 2
    }
}
