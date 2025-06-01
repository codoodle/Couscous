using Couscous.ViewModels;
using Microsoft.UI.Xaml;

namespace Couscous;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
#if WINDOWS
		Navigated += delegate
		{
			if (Window.BindingContext is AppWindowViewModel windowViewModel)
			{
				windowViewModel.CurrentIsSettingsPage = CurrentState.Location.ToString().Contains("settings");
			}
		};
#endif
	}
}
