using Couscous.ViewModels;

namespace Couscous.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
