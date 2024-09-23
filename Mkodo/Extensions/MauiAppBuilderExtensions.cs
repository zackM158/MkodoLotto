using Mkodo.Interfaces;
using Mkodo.Services;
using Mkodo.ViewModels;
using Mkodo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mkodo.Extensions;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder AddServices(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<ILottoDataService, LottoLocalDataService>()
        .AddSingleton<ICacheService, CacheService>()
        .AddSingleton<IAssemblyWrapper, AssemblyWrapper>();

        return builder;
    }
    public static MauiAppBuilder AddViewModels(this MauiAppBuilder builder)
    {
        builder.Services
            .AddTransient<HomePageViewModel>()
            .AddTransient<DetailsPageViewModel>();

        return builder;
    }
    public static MauiAppBuilder AddViews(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<HomePage>()
            .AddTransient<DetailsPage>();

        return builder;
    }
}
