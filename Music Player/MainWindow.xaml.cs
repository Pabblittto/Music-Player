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
            List<Models.Song> songList2 = new List<Models.Song>();

            songList.Add(new Models.Song("a", DateTime.Now));
            songList.Add(new Models.Song("c", new DateTime(2010, 3, 3)));
            songList.Add(new Models.Song("c", new DateTime(2002, 3, 3)));
            songList.Add(new Models.Song("c", new DateTime(2001, 3, 3)));
            songList.Add(new Models.Song("b", new DateTime(2030, 3, 3)));

            songList = new DateSorter(new NameSorter(new Sorter(songList))).Sort();
            songList2 = new NameSorter(new DateSorter(new Sorter(songList))).Sort();
        }
    }
}
