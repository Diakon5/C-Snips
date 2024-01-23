using Avalonia.Data;
using Avalonia.Interactivity;
using DynamicData.Binding;
using MusicPlayer.Services;
using ReactiveUI;

namespace MusicPlayer.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        var resolver = Splat.Locator.GetLocator();
        MusicList = new MusicListViewModel(resolver.GetRequiredService<IFetchMusicService>());
        MusicList.PropertyChanged += MusicList_PropertyChanged;
        Player = new PlayerViewModel(resolver.GetRequiredService<IMusicPlayer>());

    }

    private void MusicList_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(MusicList.SelectedItem))
        {
            OnSelectedItemChange();
        }
    }
    private void OnSelectedItemChange()
    {
        Player.Play(MusicList.SelectedItem.LocalPath);
    }
    public MusicListViewModel MusicList { get; }
    public PlayerViewModel Player { get; }
}
