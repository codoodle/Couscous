using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Couscous.Services;

namespace Couscous.Models
{
    public partial class Project : ObservableObject
    {
        private readonly ISettingsService settingsService;

        private string name = null!;
        private string description = null!;
        private string downloadPath = null!;
        private bool selected = false;

        public Project(ISettingsService settingsService)
        {
            this.settingsService = settingsService;

            WeakReferenceMessenger.Default.Register<Messages.SettingsChangedMessage>(this, (recipient, message) =>
            {
                if (message.Value == nameof(ISettingsService.GitUri))
                {
                    OnPropertyChanged(nameof(DownloadUri));
                }
            });
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string DownloadPath
        {
            get => downloadPath;
            set => SetProperty(ref downloadPath, value);
        }

        public Uri DownloadUri
        {
            get => string.IsNullOrWhiteSpace(settingsService.GitUri) ? new Uri(DownloadPath, UriKind.Relative) : new Uri(new Uri(settingsService.GitUri), DownloadPath);
        }

        public bool Selected
        {
            get => selected;
            set => SetProperty(ref selected, value);
        }
    }
}