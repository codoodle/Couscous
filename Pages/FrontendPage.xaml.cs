using Couscous.ViewModels;

namespace Couscous.Pages;

public partial class FrontendPage : ContentPage
{
    public FrontendPage(FrontendPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
