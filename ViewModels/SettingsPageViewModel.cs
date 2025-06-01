using System.Windows.Input;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Couscous.Services;

namespace Couscous.ViewModels;

public partial class SettingsPageViewModel : ObservableObject
{
    private readonly ISettingsService settingsService;

    public SettingsPageViewModel(ISettingsService settingsService)
    {
        this.settingsService = settingsService;
        gitUri = settingsService.GitUri;
        javaHome = settingsService.JavaHome;
        mavenHome = settingsService.MavenHome;
        backendProjectPath = settingsService.BackendProjectPath;
        frontendProjectPath = settingsService.FrontendProjectPath;

        PickJavaHomeCommand = new AsyncRelayCommand(async () =>
        {
            var result = await FolderPicker.PickAsync(CancellationToken.None);
            if (result.IsSuccessful)
            {
                JavaHome = result.Folder.Path;
            }
        });

        PickMavenHomeCommand = new AsyncRelayCommand(async () =>
        {
            var result = await FolderPicker.PickAsync(CancellationToken.None);
            if (result.IsSuccessful)
            {
                MavenHome = result.Folder.Path;
            }
        });

        PickBackendProjectPathCommand = new AsyncRelayCommand(async () =>
        {
            var result = await FolderPicker.PickAsync(CancellationToken.None);
            if (result.IsSuccessful)
            {
                BackendProjectPath = result.Folder.Path;
            }
        });

        PickFrontendProjectPathCommand = new AsyncRelayCommand(async () =>
        {
            var result = await FolderPicker.PickAsync(CancellationToken.None);
            if (result.IsSuccessful)
            {
                FrontendProjectPath = result.Folder.Path;
            }
        });
    }

    private string gitUri;
    private string javaHome;
    private string mavenHome;
    private string backendProjectPath;
    private string frontendProjectPath;

    public string GitUri
    {
        get => gitUri;
        set
        {
            settingsService.GitUri = value;
            SetProperty(ref gitUri, value);
        }
    }

    public string JavaHome
    {
        get => javaHome;
        set
        {
            settingsService.JavaHome = value;
            SetProperty(ref javaHome, value);
        }
    }

    public string MavenHome
    {
        get => mavenHome;
        set
        {
            settingsService.MavenHome = value;
            SetProperty(ref mavenHome, value);
        }
    }

    public string BackendProjectPath
    {
        get => backendProjectPath;
        set
        {
            settingsService.BackendProjectPath = value;
            SetProperty(ref backendProjectPath, value);
        }
    }

    public string FrontendProjectPath
    {
        get => frontendProjectPath;
        set
        {
            settingsService.FrontendProjectPath = value;
            SetProperty(ref frontendProjectPath, value);
        }
    }

    public ICommand PickJavaHomeCommand { get; }

    public ICommand PickMavenHomeCommand { get; }

    public ICommand PickBackendProjectPathCommand { get; }

    public ICommand PickFrontendProjectPathCommand { get; }
}
