using Couscous.ViewModels;

namespace Couscous.Pages;

public partial class BackendPage : ContentPage
{
    public BackendPage(BackendPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
