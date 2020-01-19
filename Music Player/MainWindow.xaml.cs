using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Music_Player.Models;


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



        // bitmap images frequently used
        private BitmapImage playBitmapImage = new BitmapImage();
        private BitmapImage pauseBitmapImage = new BitmapImage();


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

        }

        private void CreateNewPlaylistBtnClick(object sender, RoutedEventArgs e)
        {

        }

        private void LoadFromFileBtnClick(object sender, RoutedEventArgs e)
        {

        }

        private void PlayPauseBtnClick(object sender, RoutedEventArgs e)
        {

            if (MusicIsPlaying)// music is playing now and user wants to pause it
            {
                MusicIsPlaying = false;
                PlayPauseImage.Source = playBitmapImage;
                MyPlayer.Pause();


            }
            else// music is paused or stoped, user wants to play it
            {
                MusicIsPlaying = true;
                PlayPauseImage.Source = pauseBitmapImage;

                // in this promlems can occured
                MyPlayer.Play();// need check if music was selectd- something like disabled button
            }
        }

        // when user changing slider position- change value in PastTimeTextBlock -- must have
        private void SliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var elo = 10;
        }

        // when user set slider on some point
        private void SliderMouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (MusicIsPlaying)// if music was playing and user changed its position- pause it and then play it again
            {
                MyPlayer.Play();
            }

        }

        // when user pressed slider- music pause
        private void SliderMauseButtonDown(object sender, MouseButtonEventArgs e)
        {
            MyPlayer.Pause();
        }
    }
}
