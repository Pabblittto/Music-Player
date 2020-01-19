using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Music_Player.Displaying
{
    interface IDisplayer
    {
        void Display(ListBox ListBox, TextBlock ListTag, DataStorage dataStorage);

    }
}
