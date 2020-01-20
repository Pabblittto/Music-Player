using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Music_Player.Models;

namespace Music_Player.Displaying
{
    class ArtistDisplayer : IDisplayer
    {
        readonly private String TagName = "Artists:";

        public void Display(ListBox ListBox,TextBlock ListTag, DataStorage dataStorage)
        {
            ListBox.ItemsSource = null;

            ListTag.Text = TagName;
            List<Playlist> finalPlaylists = new List<Playlist>();
            Playlist testPiosen = new Playlist("Test z muzyczką");
            testPiosen.addSong(new Song() { title = "songasd", duration = new TimeSpan(0, 4, 33), releaseDate = new DateTime(1998, 10, 4 ),path= "C://Users//Pabblo//Desktop//Hymn ŚDM 2016 - Błogosławieni Miłosierni (Krysiek Remix).mp3"});
            testPiosen.addSong(new Song() { title = "sample", duration = new TimeSpan(0, 0, 33), releaseDate = new DateTime(1998, 10, 4 ),path= "C://Users//Pabblo//Desktop//sample.wav"});
            finalPlaylists.Add(testPiosen);
            finalPlaylists.Add(new Playlist("Unknown"));
            finalPlaylists.Add(new Playlist("Test"));
            finalPlaylists.Add(new Playlist("Test123123"));

            foreach (Playlist singlePlaylist in dataStorage.GetPlaylists())// for each playlist- go for each song
            {
                foreach(Song singleSong in singlePlaylist.getSongs())// for each song- check its artist and add to certain playlist
                {
                    if (singleSong.artist == "Unknown")
                    {
                        finalPlaylists.First(ob => ob.PlaylistName == "Unknown").addSong(singleSong);
                    }
                    else
                    {
                        Playlist tmpPlaylist = finalPlaylists.FirstOrDefault(ob => ob.PlaylistName == singleSong.artist);
                        if (tmpPlaylist != null)// if such playlist exists- add song to it
                            tmpPlaylist.addSong(singleSong);
                        else// if there is no such playlist- create it
                        {
                            finalPlaylists.Add(new Playlist(singleSong.artist));
                            finalPlaylists.First(ob => ob.PlaylistName == singleSong.artist).addSong(singleSong);
                        }
                    }
                }
            }

            ListBox.ItemsSource = finalPlaylists;
        }


    }
}
