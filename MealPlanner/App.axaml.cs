using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MealPlanner.ViewModels;
using MealPlanner.Views;

namespace MealPlanner;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mw = new MainWindowViewModel();
            desktop.MainWindow = new MainWindow
            {
                DataContext = mw
            };
            desktop.Exit += mw.OnExit;

        }

        base.OnFrameworkInitializationCompleted();
    }


}