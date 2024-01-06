using MusicPlayer.Models;
using MusicPlayer.Services;
using MusicPlayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Android;
using Xamarin.Essentials;

namespace MusicPlayer.Android
{
    public class FetchMusicService : IFetchMusicService
    {
        public IEnumerable<MusicItemViewModel> GetMusicItems()
        {
            
            return new ObservableCollection<MusicItemViewModel> {
                new MusicItemViewModel { Title = "Dummy Android 1" },
                new MusicItemViewModel { Title = "Dummy Android 2" }
            };
        }
    }
}
