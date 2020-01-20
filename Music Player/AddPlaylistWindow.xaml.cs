using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using Music_Player.Models;
using Music_Player.IoService;

namespace Music_Player
{
    /// <summary>
    /// Interaction logic for AddPlaylistWindow.xaml
    /// </summary>
    public partial class AddPlaylistWindow : Window
    {
        private Playlist editedPlaylist;
        public AddPlaylistWindow()
        {
            InitializeComponent();
            songsListView.ItemsSource = DataStorage.getInstance().getAllSongs();
            
        }

        public AddPlaylistWindow(Playlist playlist)
        {
            InitializeComponent();

            songsListView.ItemsSource = DataStorage.getInstance().getAllSongs();

            editedPlaylist = playlist;
            playlistNameInput.Text = editedPlaylist.PlaylistName;

            List<Song> currentSongs = DataStorage.getInstance().getAllSongs();

            foreach (Song song in playlist.SongList)
            {
                if (currentSongs.Contains(song))
                    songsListView.SelectedItems.Add(song);
            }
        }

        private void playlistSaveButton_Click(object sender, RoutedEventArgs e)
        {
            string playlistName = playlistNameInput.Text;

            Playlist playlist = new Playlist(playlistName);

            playlist.setName(playlistName);

            List<Song> songs = new List<Song>();

            foreach (Song song in songsListView.SelectedItems)
            {
                songs.Add(song);
            }

            playlist.setSongs(songs);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json and Xml files (*.json; *.xml)|*.json;*.xml";
            saveFileDialog.DefaultExt = "." + extSelect.SelectedItem.ToString();
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                IOServiceProxy.GetInstance().SavePlaylist(playlist, saveFileDialog.FileName, SaveFormat.JSON);
            }

            DialogResult = true;
            Close();
        }
    }
}
