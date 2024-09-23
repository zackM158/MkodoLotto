
using Mkodo.ViewModels;
using MkodoShared.Models;

namespace Mkodo.Views;

public partial class DetailsPage : ContentPage
{
    private readonly DetailsPageViewModel viewModel;
    public DetailsPage(DetailsPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        this.viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.Initialize();
    }

}
