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
using Music_Player.Utilites;
using Music_Player.Models;
using Music_Player.PlaylistManager;


namespace Music_Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool MusicIsPlaying= false;
        private Player MyPlayer;
        private DataStorage MyDataStorage;
        


        // bitmap images frequently used
        private BitmapImage playBitmapImage = new BitmapImage();
        private BitmapImage pauseBitmapImage = new BitmapImage();


        public MainWindow()
        {

            InitializeComponent();


        }
    }
}
