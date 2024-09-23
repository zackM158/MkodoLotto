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

[QueryProperty(nameof(SelectedDraw), NavigationParameterKeys.SelectedDraw)]
public partial class DetailsPageViewModel(ICacheService cache) : BaseViewModel
{
    [ObservableProperty] private List<DrawDto>? draws;
    [ObservableProperty] private DrawDto? selectedDraw;
    [ObservableProperty] private int currentIndex;
    [ObservableProperty] private bool drawsHasError;

    public void Initialize()
    {
        Draws = cache.Draws;

        DrawsHasError = Draws == null || SelectedDraw == null || Draws.Count == 0;
        if (DrawsHasError)
        {
            return;
        }

        CurrentIndex = Draws!.IndexOf(SelectedDraw!);
    }

}
