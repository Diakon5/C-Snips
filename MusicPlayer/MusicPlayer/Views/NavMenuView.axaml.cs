using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;

namespace MusicPlayer.Views;

public partial class NavMenuView : UserControl
{
    public double MaxHeightImageCalculated { get; set; } = 0;
    public NavMenuView()
    {
        InitializeComponent();
    }
}