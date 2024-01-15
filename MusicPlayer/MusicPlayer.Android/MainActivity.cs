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
using Android.Content;

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
            Bootstrapper.RegisterLazySingleton<IMusicPlayer, MusicPlayer>(Splat.Locator.CurrentMutable, Splat.Locator.Current);
        };
    }
    public override void OnCreate(Bundle? savedInstanceState, PersistableBundle? persistentState)
    {

        CrossCurrentActivity.Current.Init(this, savedInstanceState);
        base.OnCreate(savedInstanceState, persistentState);
    }
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        if (ContextCompat.CheckSelfPermission(this, global::Android.Manifest.Permission.ReadExternalStorage) != Permission.Granted)
        {
            RequestPermissions(new string[] { global::Android.Manifest.Permission.ReadExternalStorage }, 0);
        }
        if (ContextCompat.CheckSelfPermission(this, global::Android.Manifest.Permission.WriteExternalStorage) != Permission.Granted)
        {
            RequestPermissions(new string[] { global::Android.Manifest.Permission.WriteExternalStorage }, 0);
        }
        if (ContextCompat.CheckSelfPermission(this, global::Android.Manifest.Permission.ManageExternalStorage) != Permission.Granted)
        {
            RequestPermissions(new string[] { global::Android.Manifest.Permission.ManageExternalStorage }, 0);
        }
        return base.CustomizeAppBuilder(builder)
            .WithInterFont()
            .UseReactiveUI().AfterPlatformServicesSetup(UseBootstrapper());
    }
}
