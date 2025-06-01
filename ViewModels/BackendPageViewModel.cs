using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Couscous.Models;
using Couscous.Services;

namespace Couscous.ViewModels;

public partial class BackendPageViewModel : ObservableObject
{
    public BackendPageViewModel(ISettingsService settingsService)
    {
        projects =
        [
            new Project(settingsService) { Name = "Backend Project A", Description = "Description for Backend Project A", DownloadPath = "/path/to/backendA" },
                new Project(settingsService) { Name = "Backend Project B", Description = "Description for Backend Project B", DownloadPath = "/path/to/backendB" },
                new Project(settingsService) { Name = "Backend Project C", Description = "Description for Backend Project C", DownloadPath = "/path/to/backendC" }
        ];
        selectedProjects = [];

        CreateProjectCommand = new AsyncRelayCommand(async () =>
        {
            Console.WriteLine("Creating project...");
            if (SelectedProjects.Count == 0)
            {
                Console.WriteLine("No projects selected.");
                return;
            }
            foreach (var project in SelectedProjects)
            {
                if (project is Project p)
                {
                    Console.WriteLine($"Project Name: {p.Name}");
                    Console.WriteLine($"Description: {p.Description}");
                    Console.WriteLine($"Download Path: {p.DownloadPath}");
                }
            }
            Console.WriteLine($"Projects created successfully.{settingsService.GitUri}");
            // var startInfo = new ProcessStartInfo
            // {
            //     FileName = "ipconfig",
            //     Arguments = "/all",
            //     RedirectStandardOutput = true,
            // };

            // var process = new Process
            // {
            //     StartInfo = startInfo,
            // };
            // process.Start();
            // string output = await process.StandardOutput.ReadToEndAsync();
            // Console.Write(output);
            // await process.WaitForExitAsync().ContinueWith(t =>
            // {
            //     if (t.IsFaulted)
            //     {
            //         Console.WriteLine("Error: " + t.Exception?.GetBaseException().Message);
            //     }
            //     else
            //     {
            //         Console.WriteLine("Process completed successfully.");
            //     }
            // });
        });
    }

    private string? pom;
    private ObservableCollection<Project> projects;
    private ObservableCollection<object> selectedProjects;

    public string? Pom
    {
        get => pom;
        set => SetProperty(ref pom, value);
    }

    public ObservableCollection<Project> Projects
    {
        get => projects;
        set => SetProperty(ref projects, value);
    }

    public ObservableCollection<object> SelectedProjects
    {
        get => selectedProjects;
        set => SetProperty(ref selectedProjects, value);
    }

    public ICommand CreateProjectCommand { get; }
}
