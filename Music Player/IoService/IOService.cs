using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music_Player.PlaylistManager;

namespace Music_Player.IoService
{
    class IOService : IIOService
    {
        public Playlist ReadPlaylist(string dir)
        {
            PlaylistManager.PlaylistManager playlistManager;
            string extension = Path.GetExtension(dir);
            
            switch (extension)
            {
                case ".xml":
                    playlistManager = new XMLPlaylistManager();
                    break;
                case ".json":
                    playlistManager = new JSONPlaylistManager();
                    break;
                default:
                    throw new Exception("Unknown format");
            }

            return playlistManager.LoadPlaylist(dir);
        }

        public void SavePlaylist(Playlist playlist, string dir, SaveFormat format)
        {
            PlaylistManager.PlaylistManager playlistManager;

            switch (format)
            {
                case SaveFormat.XML:
                    playlistManager = new XMLPlaylistManager();
                    break;
                case SaveFormat.JSON:
                    playlistManager = new JSONPlaylistManager();
                    break;
                default:
                    throw new Exception("Unknown format");
            }

            playlistManager.SavePlaylist(dir, playlist);

        }

        public List<Song> SearchDirectory(string dir)
        {
            try
            {
                List<Song> songList = new List<Song>();
                string[] files = Directory.GetFiles(dir);
                foreach (string file in files)
                {
                    if (Path.GetExtension(file) != ".mp3")
                        continue;

                    TagLib.File songTfile = TagLib.File.Create(file);
                    songList.Add(CreateSongFromTfile(songTfile, file));
                }

                return songList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Song CreateSongFromTfile(TagLib.File file, string fileLocation)
        {
            Song song = new Song();

            if (!string.IsNullOrEmpty(file.Tag.Title))
                song.title = file.Tag.Title;
            else
                song.title = file.Name;

            if (!string.IsNullOrEmpty(file.Tag.FirstPerformer) && !file.Tag.FirstPerformer.Equals(file.Tag.Title))
                song.artist = file.Tag.FirstPerformer;
            else
                song.artist = "Unknown";

            song.releaseDate = new DateTime(file.Tag.Year);
            song.duration = file.Properties.Duration;
            if (!string.IsNullOrEmpty(file.Tag.Album) && !file.Tag.Album.Equals(file.Name))
                song.album = file.Tag.Album;
            else
                song.album = "Unknown";
            song.path = fileLocation;

            return song;
        }
    }
}
