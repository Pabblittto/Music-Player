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

namespace Music_Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Models.Song> songList = new List<Models.Song>();

            songList.Add(new Models.Song("a"));
            songList.Add(new Models.Song("c"));
            songList.Add(new Models.Song("b"));

            songList = new Utilites.NameSorter(new Utilites.Sorter(songList)).Sort();
        }
    }
}
