using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Music_Player.Models;

namespace Music_Player.Displaying
{
    class AlbumDisplayer : IDisplayer
    {
        readonly private String TagName = "Albums:";

        public void Display(ListBox ListBox, TextBlock ListTag, DataStorage dataStorage)
        {
            ListBox.ItemsSource = null;

            ListTag.Text = TagName;
            List<Playlist> finalPlaylists = new List<Playlist>();
            finalPlaylists.Add(new Playlist("Unknown"));

            foreach (Playlist singlePlaylist in dataStorage.GetPlaylists())// for each playlist- go for each song
            {
                foreach (Song singleSong in singlePlaylist.getSongs())// for each song- check its album and add to certain playlist
                {
                    if (singleSong.album == "Unknown")
                    {
                        finalPlaylists.First(ob => ob.PlaylistName == "Unknown").addSong(singleSong);
                    }
                    else
                    {
                        Playlist tmpPlaylist = finalPlaylists.FirstOrDefault(ob => ob.PlaylistName == singleSong.album);
                        if (tmpPlaylist != null)// if such playlist exists- add song to it
                            tmpPlaylist.addSong(singleSong);
                        else// if there is no such playlist- create it
                        {
                            finalPlaylists.Add(new Playlist(singleSong.album));
                            finalPlaylists.First(ob => ob.PlaylistName == singleSong.album).addSong(singleSong);
                        }
                    }
                }
            }

            ListBox.ItemsSource = finalPlaylists;
        }
    }
}
