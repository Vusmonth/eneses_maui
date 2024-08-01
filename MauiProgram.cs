using enesens_mobile.Context;
using enesens_mobile.Pages;
using enesens_mobile.Services;
using Microsoft.Extensions.Logging;

namespace enesens_mobile;

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
        
        var cookieHandler = new CookieHandler();
        var httpClient = new HttpService(cookieHandler);

        builder.Services.AddSingleton(httpClient);
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<AuthService>();
        builder.Services.AddSingleton<DashboardService>();
        builder.Services.AddSingleton<Dashboard>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}