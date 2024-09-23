using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Mkodo.Interfaces;
using Mkodo.Services;
using Mkodo.ViewModels;
using Mkodo.Views;
using PanCardView;
using System.Reflection;
using Mkodo.Extensions;

namespace Mkodo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseCardsView()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Roboto-Black.ttf", "Roboto");
                    fonts.AddFont("Roboto-Bold.ttf", "RobotoBold");
                    fonts.AddFont("MaterialSymbolsOutlined.ttf", "MaterialSymbols");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("Mkodo.appsettings.json");
            if (stream != null)
            {
                var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

                builder.Configuration.AddConfiguration(config);
            }

            builder.AddServices()
                .AddViewModels()
                .AddViews();

            return builder.Build();
        }
    }
}
