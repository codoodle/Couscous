namespace Couscous;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		// BindingContext = new AppViewModel();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new AppWindow();
	}
}