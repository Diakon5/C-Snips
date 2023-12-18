using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.ViewModels
{
    public class MusicListViewModel : ViewModelBase
    {
            
        public MusicListViewModel(IEnumerable<MusicItem> items)
        {
            ListItems = new ObservableCollection<MusicItem>(items);
        }

        public ObservableCollection<MusicItem> ListItems { get; }
    }
}

