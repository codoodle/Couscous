using Couscous.ViewModels;

namespace Couscous;

public partial class AppWindow : Window
{
    public AppWindow()
    {
        InitializeComponent();
        BindingContext = new AppWindowViewModel();
    }
}