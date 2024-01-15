using System;
using Splat;
using Avalonia;
using Avalonia.ReactiveUI;
using MusicPlayer.Services;
using MusicPlayer.ViewModels;
namespace MusicPlayer.Desktop;

class Program
{
    public static Action<AppBuilder> UseBootstrapper()
    {
        return (_) =>
        {
            Bootstrapper.RegisterLazySingleton<IFetchMusicService, FetchMusicService>(Locator.CurrentMutable, Locator.Current);
            Bootstrapper.RegisterLazySingleton<IMusicPlayer, MusicPlayer>(Locator.CurrentMutable, Locator.Current);
            //Locator.CurrentMutable.Register(() => new MusicListViewModel(Locator.Current.GetRequiredService<IFetchMusicService>()));
        };
    }
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI().AfterPlatformServicesSetup(UseBootstrapper());
}
