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
        private Playlist beforeUpdate;
        public PlaylistCareTaker playlistCareTaker = PlaylistCareTaker.getInstance();
        public AddPlaylistWindow()
        {
            InitializeComponent();
            songsListView.ItemsSource = DataStorage.getInstance().getAllSongs();
            playlistCareTaker = PlaylistCareTaker.getInstance();
           
        }

        public AddPlaylistWindow(Playlist playlist)
        {
            InitializeComponent();

            songsListView.ItemsSource = DataStorage.getInstance().getAllSongs();

            editedPlaylist = playlist;
            beforeUpdate = playlist;
            playlistNameInput.Text = editedPlaylist.PlaylistName;

            List<Song> currentSongs = DataStorage.getInstance().getAllSongs();

            foreach (Song song in playlist.SongList)
            {
                if (currentSongs.Contains(song))
                    songsListView.SelectedItems.Add(song);
            }
            if(playlistCareTaker.playlists.Contains(playlist))
            {
                int index = 1;

                foreach (PlaylistMemento memento in playlistCareTaker.getMementos(playlist))
                {
                    System.Windows.Controls.Button tmp = new System.Windows.Controls.Button();
                    Playlist mementoPlaylist = new Playlist();
                    mementoPlaylist.setName(memento.name);
                    mementoPlaylist.setSongs(memento.songs);
                    tmp.Content = memento.name;
                    tmp.Click += (sender, args) =>
                    {
                        editedPlaylist = mementoPlaylist;
                        playlistNameInput.Text = editedPlaylist.PlaylistName;
                        currentSongs = DataStorage.getInstance().getAllSongs();

                        foreach (Song song in mementoPlaylist.SongList)
                        {
                            if (currentSongs.Contains(song))
                                songsListView.SelectedItems.Add(song);
                        }
                    };
                    stack.Children.Add(tmp);
                }
            

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

            int index = DataStorage.getInstance().playlists.IndexOf(beforeUpdate);
            if (playlistCareTaker.playlists.Contains(beforeUpdate))
            {
                playlistCareTaker.playlists[playlistCareTaker.playlists.IndexOf(beforeUpdate)] = playlist;
            }
            
            playlistCareTaker.addMemento(playlist.createMemento(),playlist);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json and Xml files (*.json; *.xml)|*.json;*.xml";
            saveFileDialog.DefaultExt = "." + extSelect.SelectedItem.ToString();
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                IOServiceProxy.GetInstance().SavePlaylist(playlist, saveFileDialog.FileName, SaveFormat.JSON);
            }

            if (index != -1)
            {
                DataStorage.getInstance().playlists.RemoveAt(index);

                DataStorage.getInstance().playlists.Add(playlist);

            }
            DataStorage.getInstance().playlists.Add(playlist);

            DialogResult = true;
            Close();
        }
    }
}
