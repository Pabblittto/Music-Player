using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Music_Player.Displaying;
using Music_Player.IoService;
using Music_Player.Models;
using Music_Player.IoService;
using Music_Player.Utilites;


namespace Music_Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool MusicIsPlaying = false;
        private Player MyPlayer;
        private DataStorage MyDataStorage;

        private IDisplayer Displayer;
        private List<Song> unsortedSongList;
        private ISorter sorter;
        private Playlist selectedPlaylist;

        DispatcherTimer Slidertimer = new DispatcherTimer();
        

        // bitmap images frequently used
        private BitmapImage playBitmapImage = new BitmapImage();
        private BitmapImage pauseBitmapImage = new BitmapImage();

        IOServiceProxy fileService = IOServiceProxy.GetInstance();

        



        public MainWindow()
        {

            InitializeComponent();

            playBitmapImage.BeginInit();// creating play Bitmap image
            playBitmapImage.UriSource = new Uri("/images/play.png", UriKind.Relative);
            playBitmapImage.EndInit();

            pauseBitmapImage.BeginInit();// creating pause Bitmap image
            pauseBitmapImage.UriSource = new Uri("/images/pause.png", UriKind.Relative);
            pauseBitmapImage.EndInit();

            MyPlayer = Player.getInstance();
            MyDataStorage = DataStorage.getInstance();
            Displayer = new PlaylistDisplayer();
            Displayer.Display(PlaylistsListBox, DisplayTag, MyDataStorage);

            Slidertimer.Interval = new TimeSpan(0, 0, 1);
            Slidertimer.Tick += MoveSliderByOneSecondEvent;


        }

        private void MoveSliderByOneSecondEvent(Object source, EventArgs e)
        {
            if (MusicSlider.Value <= MyPlayer.getSongLength().TotalSeconds)
            {
                MusicSlider.Value = MusicSlider.Value + 1;
                PastTimeTextBlock.Text = TimeSpan.FromSeconds(MusicSlider.Value).ToString();
            }
            else
            {
                NextSongBtnClick(null, null);
            }
        }

        private void CreateNewPlaylistBtnClick(object sender, RoutedEventArgs e)
        {
            AddPlaylistWindow addPlaylistWindow = new AddPlaylistWindow();
            addPlaylistWindow.ShowDialog();
        }

        private void LoadFromFileBtnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog filePicker = new OpenFileDialog();
            filePicker.Title = "Select Playlist";
            filePicker.Filter = "Json and xml files(*.json;*.xml)|*.json;*.xml";

            if(filePicker.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                MyDataStorage.AddPlaylist(fileService.ReadPlaylist(filePicker.FileName));
                Displayer.Display(PlaylistsListBox, DisplayTag, MyDataStorage);
            }
            
        }

        private void PlayPauseBtnClick(object sender, RoutedEventArgs e)
        {

            if (MusicIsPlaying)// music is playing now and user wants to pause it
            {
                MusicIsPlaying = false;
                PlayPauseImage.Source = playBitmapImage;
                MyPlayer.Pause();
                Slidertimer.Stop();

            }
            else// music is paused or stoped, user wants to play it
            {
                MusicIsPlaying = true;
                PlayPauseImage.Source = pauseBitmapImage;
                Slidertimer.Start();
                // in this promlems can occured
                MyPlayer.Play();// need check if music was selectd- something like disabled button
            }
        }

        // when user changing slider position- change value in PastTimeTextBlock -- must have
        private void SliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider tmpSlider = sender as Slider;
            PastTimeTextBlock.Text = TimeSpan.FromSeconds(tmpSlider.Value).ToString();
        }

        // when user set slider on some point
        private void SliderMouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            MyPlayer.setCertainMoment((int)MusicSlider.Value);
            if (MusicIsPlaying)// if music was playing and user changed its position- pause it and then play it again
            {
                Slidertimer.Start();
                MyPlayer.Play();
            }
        }

        // when user pressed slider- music pause
        private void SliderMauseButtonDown(object sender, MouseButtonEventArgs e)
        {
            Slidertimer.Stop();
            MyPlayer.Pause();
        }

        private void DisplayByPlaylistsBtnClick(object sender, RoutedEventArgs e)
        {
            Displayer = new PlaylistDisplayer();
            Displayer.Display(PlaylistsListBox, DisplayTag, MyDataStorage);
        }

        private void DisplayByArtistsBtnClick(object sender, RoutedEventArgs e)
        {
            Displayer = new ArtistDisplayer();
            Displayer.Display(PlaylistsListBox, DisplayTag, MyDataStorage);
        }

        private void DisplayByAlbumsBtnClick(object sender, RoutedEventArgs e)
        {
            Displayer = new AlbumDisplayer();
            Displayer.Display(PlaylistsListBox, DisplayTag, MyDataStorage);
        }


        private void CertainPlaylistSelectedClick(object sender, SelectionChangedEventArgs e)
        {

            Playlist selected = ((sender as System.Windows.Controls.ListBox).SelectedItem as Playlist);
            if(selected!=null)
            {
                selectedPlaylist = selected;
                unsortedSongList = selected.getSongs();
                sorter = new Sorter(unsortedSongList);
                MusicsFromPlaylist.ItemsSource = selected.getSongs();
            }
            else
            {
                MusicsFromPlaylist.ItemsSource = new List<Song>();
            }
            
        }

        private void CertainSongDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MusicIsPlaying)
                MyPlayer.Stop();

            Song clickedMusic = ((sender as System.Windows.Controls.ListBox).SelectedItem as Song);

            MakePlayerPlayCertainMusic(clickedMusic);
            if (MusicIsPlaying)
                MyPlayer.Play();
            //PlayPauseBtnClick(null, null);// trigger btn click
        }

        private void NextSongBtnClick(object sender, RoutedEventArgs e)
        {
            int Allelements=(MusicsFromPlaylist.ItemsSource as List<Song>).Count;
            int currentIndex = MusicsFromPlaylist.SelectedIndex;
            if (currentIndex + 1 == Allelements)// the last element is playing right now- play first element
            {
                MusicsFromPlaylist.SelectedIndex = 0;
            }
            else
            {
                MusicsFromPlaylist.SelectedIndex++;
            }
            MyPlayer.Stop();
            MakePlayerPlayCertainMusic(MusicsFromPlaylist.SelectedItem as Song);
            if (MusicIsPlaying)
                MyPlayer.Play();

        }

        private void MakePlayerPlayCertainMusic(Song MusicToPlay)
        {
            if (MusicToPlay != null)
            {
                SongTitle.Text = MusicToPlay.title;
                SongAtrist.Text = MusicToPlay.artist;
                SongAlbum.Text = MusicToPlay.album;
                SongReleaseDate.Text = MusicToPlay.releaseDate.ToShortDateString();



                MyPlayer.SetSong(MusicToPlay);

                PrevBtn.IsEnabled = true;
                NextBtn.IsEnabled = true;
                PlayBtn.IsEnabled = true;
                MusicSlider.IsEnabled = true;
                MusicSlider.Maximum = MusicToPlay.duration.TotalSeconds;
                MusicSlider.Value = 0;
                FullTimeTextBlock.Text = MusicToPlay.duration.ToString();
            }

        }

        private void PrevSongBtnClick(object sender, RoutedEventArgs e)
        {
            int Allelements = (MusicsFromPlaylist.ItemsSource as List<Song>).Count;
            int currentIndex = MusicsFromPlaylist.SelectedIndex;
            if (currentIndex == 0)// If current music is first
            {
                MusicsFromPlaylist.SelectedIndex = Allelements-1;
            }
            else
            {
                MusicsFromPlaylist.SelectedIndex--;
            }
            MyPlayer.Stop();
            MakePlayerPlayCertainMusic(MusicsFromPlaylist.SelectedItem as Song);
            if (MusicIsPlaying)
                MyPlayer.Play();

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    List<Song> songList = IOServiceProxy.GetInstance().SearchDirectory(fbd.SelectedPath);
                    DataStorage.getInstance().addSongs(songList);
                }
            }
            Displayer.Display(PlaylistsListBox, DisplayTag, MyDataStorage);
        }
        
        private void SortTitleBtnClick(object sender, RoutedEventArgs e)
        {
            MusicsFromPlaylist.ItemsSource = new List<Song>();
            sorter = new NameSorter(sorter);
            MusicsFromPlaylist.ItemsSource = sorter.Sort();
            SortTitleBtn.IsEnabled = false;
        }

        private void SortDurationBtnClick(object sender, RoutedEventArgs e)
        {
            MusicsFromPlaylist.ItemsSource = new List<Song>();
            sorter = new DurationSorter(sorter);
            MusicsFromPlaylist.ItemsSource = sorter.Sort();
            SortDurationBtn.IsEnabled = false;
        }

        private void SortReleaseBtnClick(object sender, RoutedEventArgs e)
        {
            MusicsFromPlaylist.ItemsSource = new List<Song>();
            sorter = new DateSorter(sorter);
            MusicsFromPlaylist.ItemsSource = sorter.Sort();
            SortDateBtn.IsEnabled = false;
        }

        private void ResetSortingBtnClick(object sender, RoutedEventArgs e)
        {
            MusicsFromPlaylist.ItemsSource = new List<Song>();
            sorter = new Sorter(unsortedSongList);
            MusicsFromPlaylist.ItemsSource = unsortedSongList;
            SortTitleBtn.IsEnabled = true;
            SortDurationBtn.IsEnabled = true;
            SortDateBtn.IsEnabled = true;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AddPlaylistWindow addPlaylistWindow = new AddPlaylistWindow(selectedPlaylist);
            addPlaylistWindow.ShowDialog();
        }
    }
}
