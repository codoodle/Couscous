using CommunityToolkit.Maui.Markup;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Couscous.Services;
using Couscous.ViewModels;

namespace Couscous;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.UseMauiCommunityToolkitMarkup()
			.ConfigureFonts(fonts =>
		{
			fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			fonts.AddFont("Segoe Fluent Icons.ttf", "Segoe Fluent Icons");
		});
		builder.Services.AddSingleton<ISettingsService, SettingsService>();
		builder.Services.AddSingleton<BackendPageViewModel>();
		builder.Services.AddSingleton<FrontendPageViewModel>();
		builder.Services.AddSingleton<SettingsPageViewModel>();
#if DEBUG
		builder.Logging.AddDebug();
#endif
		return builder.Build();
	}
}