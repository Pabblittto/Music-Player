using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Music_Player.Models;

namespace Music_Player.Displaying
{
    class PlaylistDisplayer : IDisplayer
    {
        readonly private String TagName = "Playlists:";

        public void Display(ListBox ListBox, TextBlock ListTag, DataStorage dataStorage)
        {
            ListBox.ItemsSource = null;
            ListTag.Text = TagName;
            ListBox.ItemsSource = dataStorage.GetPlaylists();
        }
    }
}
