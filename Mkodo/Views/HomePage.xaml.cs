
using Mkodo.ViewModels;

namespace Mkodo.Views;

public partial class HomePage : ContentPage
{
    private readonly HomePageViewModel viewModel;
    private static bool initialized;
    public HomePage(HomePageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        this.viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (!initialized)
        {
            await viewModel.Initialize();
            initialized = true;
        }
    }
}
