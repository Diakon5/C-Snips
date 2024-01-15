using Avalonia.Data;
using Avalonia.Interactivity;
using DynamicData.Binding;
using MusicPlayer.Services;
using ReactiveUI;

namespace MusicPlayer.ViewModels;

public class MainViewModel : ViewModelBase
{
    private ViewModelBase _viewModel;
    public MainViewModel()
    {
        var resolver = Splat.Locator.GetLocator();
        MusicList = new MusicListViewModel(resolver.GetRequiredService<IFetchMusicService>());
        MusicList.PropertyChanged += MusicList_PropertyChanged;
    }

    private void MusicList_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(MusicList.SelectedItem))
        {
            OnSelectedItemChange();
        }
    }
    public ViewModelBase ContentViewModel
    {
        get => _viewModel;
        private set => this.RaiseAndSetIfChanged(ref _viewModel, value);
    }
    private void OnSelectedItemChange()
    {

    }
    public MusicListViewModel MusicList { get; }
}
