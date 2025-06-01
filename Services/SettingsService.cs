using CommunityToolkit.Mvvm.Messaging;

namespace Couscous.Services;

public sealed class SettingsService : ISettingsService
{
    private const string GitUriKey = "git";
    private static readonly string GitUriDefault = string.Empty;
    private const string JavaHomeKey = "java_home";
    private static readonly string JavaHomeDefault = string.Empty;
    private const string MavenHomeKey = "maven_home";
    private static readonly string MavenHomeDefault = string.Empty;
    private const string BackendProjectPathKey = "backend_project_path";
    private static readonly string BackendProjectPathDefault = string.Empty;
    private const string FrontendProjectPathKey = "frontend_project_path";
    private static readonly string FrontendProjectPathDefault = string.Empty;

    public string GitUri
    {
        get => Preferences.Get(GitUriKey, GitUriDefault);
        set
        {
            Preferences.Set(GitUriKey, value);
            WeakReferenceMessenger.Default.Send(new Messages.SettingsChangedMessage(nameof(GitUri)));
        }
    }

    public string JavaHome
    {
        get => Preferences.Get(JavaHomeKey, JavaHomeDefault);
        set
        {
            Preferences.Set(JavaHomeKey, value);
            WeakReferenceMessenger.Default.Send(new Messages.SettingsChangedMessage(nameof(JavaHome)));
        }
    }

    public string MavenHome
    {
        get => Preferences.Get(MavenHomeKey, MavenHomeDefault);
        set
        {
            Preferences.Set(MavenHomeKey, value);
            WeakReferenceMessenger.Default.Send(new Messages.SettingsChangedMessage(nameof(MavenHome)));
        }
    }

    public string BackendProjectPath
    {
        get => Preferences.Get(BackendProjectPathKey, BackendProjectPathDefault);
        set
        {
            Preferences.Set(BackendProjectPathKey, value);
            WeakReferenceMessenger.Default.Send(new Messages.SettingsChangedMessage(nameof(BackendProjectPath)));
        }
    }

    public string FrontendProjectPath
    {
        get => Preferences.Get(FrontendProjectPathKey, FrontendProjectPathDefault);
        set
        {
            Preferences.Set(FrontendProjectPathKey, value);
            WeakReferenceMessenger.Default.Send(new Messages.SettingsChangedMessage(nameof(FrontendProjectPath)));
        }
    }
}
