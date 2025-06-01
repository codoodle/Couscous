namespace Couscous.Services;

public interface ISettingsService
{
    string GitUri { get; set; }
    string JavaHome { get; set; }
    string MavenHome { get; set; }
    string BackendProjectPath { get; set; }
    string FrontendProjectPath { get; set; }
}
