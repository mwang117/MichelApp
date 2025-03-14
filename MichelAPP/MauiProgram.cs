using MichelAPP.Services;
using MichelAPP.ViewModels;
using Microsoft.Extensions.Logging;

namespace MichelAPP;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<AccueilPage>();
        builder.Services.AddTransient<GifPage>();
        builder.Services.AddSingleton<CoffeeService>();
        builder.Services.AddSingleton<CoffeeViewModel>();
        builder.Services.AddTransient<DeuxiemePage>();
        builder.Services.AddTransient<DetailPage>();
        builder.Services.AddSingleton<CoffeeViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
