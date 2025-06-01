using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Couscous.Models;
using Couscous.Services;

namespace Couscous.ViewModels;

public partial class FrontendPageViewModel : ObservableObject
{
    public FrontendPageViewModel(ISettingsService settingsService)
    {
        projects =
        [
            new Project(settingsService) { Name = "Frontend Project A", Description = "Description for Frontend Project A", DownloadPath = "/path/to/frontendA" },
                new Project(settingsService) { Name = "Frontend Project B", Description = "Description for Frontend Project B", DownloadPath = "/path/to/frontendB" },
                new Project(settingsService) { Name = "Frontend Project C", Description = "Description for Frontend Project C", DownloadPath = "/path/to/frontendC" }
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
            Console.WriteLine("Projects created successfully.");
        });
    }

    private ObservableCollection<Project> projects;
    private ObservableCollection<object> selectedProjects;

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
