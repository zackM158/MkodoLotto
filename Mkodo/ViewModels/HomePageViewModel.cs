using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mkodo.Constants;
using Mkodo.Interfaces;
using MkodoShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mkodo.ViewModels;

public partial class HomePageViewModel(ILottoDataService lottoApiService,
    ICacheService cache) : BaseViewModel
{
    [ObservableProperty] private List<DrawDto>? draws;
    [ObservableProperty] private bool drawsHasError;

    public async Task Initialize()
    {
        await GetDraws();
    }

    [RelayCommand]
    public async Task GetDraws()
    {
        Draws = await lottoApiService.GetDrawsAsync();
        DrawsHasError = Draws.Count == 0;
        if (DrawsHasError)
        {
            return;
        }

        cache.Draws = Draws;
    }

    [RelayCommand]
    public async Task GoToDetails(DrawDto draw)
    {
        var navParams = new Dictionary<string, object>()
        {
            { NavigationParameterKeys.SelectedDraw, draw }
        };

        await Shell.Current.GoToAsync("DetailsPage", true, navParams);
    }
}
