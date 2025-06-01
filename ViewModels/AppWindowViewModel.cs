using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Couscous.ViewModels;

public partial class AppWindowViewModel : ObservableObject
{
    public AppWindowViewModel()
    {
        NavigateToHomeCommand = new AsyncRelayCommand(() => Shell.Current.GoToAsync("//home"));
        NavigateToSettingsCommand = new AsyncRelayCommand(() => Shell.Current.GoToAsync("//settings"));
    }

    public string Title { get; set; } = "쿠스쿠스";


    private bool currentIsSettingsPage = false;

    public bool CurrentIsSettingsPage
    {
        get => currentIsSettingsPage;
        set
        {
            SetProperty(ref currentIsSettingsPage, value);
        }
    }

    public ICommand NavigateToHomeCommand { get; }

    public ICommand NavigateToSettingsCommand { get; }
}