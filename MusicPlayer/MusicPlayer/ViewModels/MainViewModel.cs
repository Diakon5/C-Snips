using MusicPlayer.Services;

namespace MusicPlayer.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        var resolver = Splat.Locator.GetLocator();
        MusicList = new MusicListViewModel(resolver.GetRequiredService<IFetchMusicService>());
    }

    public MusicListViewModel MusicList { get; }
}
