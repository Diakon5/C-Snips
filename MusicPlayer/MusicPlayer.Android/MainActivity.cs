using Android.App;
using Android.Content.PM;
using MusicPlayer.Services;
using Avalonia;
using Avalonia.Android;
using Avalonia.ReactiveUI;
using System;
using Android.OS;
using Plugin.CurrentActivity;
using System.Reflection.Metadata;
using AndroidX.Core.Content;
using Android;

namespace MusicPlayer.Android;

[Activity(
    Label = "MusicPlayer.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class MainActivity : AvaloniaMainActivity<App>
{
    public static Action<AppBuilder> UseBootstrapper()
    {
        return (_) =>
        {
            Bootstrapper.RegisterLazySingleton<IFetchMusicService, FetchMusicService>(Splat.Locator.CurrentMutable, Splat.Locator.Current);
        };
    }
    public override void OnCreate(Bundle? savedInstanceState, PersistableBundle? persistentState)
    {

        CrossCurrentActivity.Current.Init(this, savedInstanceState);
        base.OnCreate(savedInstanceState, persistentState);
        if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage) != (int)Permission.Granted)
        {
            RequestPermissions(new string[] { Manifest.Permission.ReadExternalStorage }, 0);
        }
    }
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {

        return base.CustomizeAppBuilder(builder)
            .WithInterFont()
            .UseReactiveUI().AfterPlatformServicesSetup(UseBootstrapper());
    }
}
