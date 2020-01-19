using Music_Player.Models;
using System.Collections.Generic;

namespace Music_Player.IoService
{
    class IOServiceProxy : IIOService
    {
        private static IOServiceProxy INSTANCE;
        private Dictionary<string, List<Song>> cacheList;
        private IOService iOService;
        private IOServiceProxy()
        {
            cacheList = new Dictionary<string, List<Song>>();
        }

        public static IOServiceProxy GetInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new IOServiceProxy();
            return INSTANCE;
        }
        public Playlist ReadPlaylist(string dir)
        {
            iOService = new IOService();
            Playlist playlist = iOService.ReadPlaylist(dir);
            iOService = null;
            return playlist;
        }

        public void SavePlaylist(Playlist playlist, string dir, SaveFormat format)
        {
            iOService = new IOService();
            iOService.SavePlaylist(playlist, dir, format);
            iOService = null;
        }

        public List<Song> SearchDirectory(string dir)
        {
            if (cacheList.ContainsKey(dir))
                return cacheList[dir];

            iOService = new IOService();
            List<Song> songList = iOService.SearchDirectory(dir);
            iOService = null;
            return songList;
        }
    }
}
