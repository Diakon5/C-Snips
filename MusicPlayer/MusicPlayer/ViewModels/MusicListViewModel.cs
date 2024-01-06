using MusicPlayer.Models;
using MusicPlayer.Services;
using ReactiveUI;
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
        private IFetchMusicService _fetchMusicService;
        public MusicListViewModel(IFetchMusicService fetchMusic)
        {
            _fetchMusicService = fetchMusic;
            Items = (ObservableCollection<MusicItemViewModel>)_fetchMusicService.GetMusicItems();
        }

        private MusicItemViewModel? _selectedItem;

        public MusicItemViewModel? SelectedItem
        {
            get => _selectedItem;
            set => this.RaiseAndSetIfChanged(ref _selectedItem, value);
        }
        public ObservableCollection<MusicItemViewModel> Items { get; }
    }
}

