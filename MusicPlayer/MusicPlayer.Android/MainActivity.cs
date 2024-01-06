﻿using Android.App;
using Android.Content.PM;
using MusicPlayer.Services;
using Avalonia;
using Avalonia.Android;
using Avalonia.ReactiveUI;
using System;

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
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        return base.CustomizeAppBuilder(builder)
            .WithInterFont()
            .UseReactiveUI().AfterPlatformServicesSetup(UseBootstrapper()); ;
    }
}
