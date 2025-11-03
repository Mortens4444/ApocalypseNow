using ApocalypseNow.Data;
using ApocalypseNow.ViewModels;
using Microsoft.Extensions.Logging;
using System.Runtime.Versioning;

namespace ApocalypseNow
{
    public static class MauiProgram
    {
        [SupportedOSPlatform("windows10.0.17763.0")]
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

            builder.Services.AddSingleton<ChecklistRepository>();
            builder.Services.AddSingleton<ChecklistViewModel>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            var repo = app.Services.GetService<ChecklistRepository>();
            _ = repo.InitDbAsync(); // don't await here to avoid blocking startup

            // fire-and-forget init
            _ = DbInit.InitializeAndSeedAsync();
            return app;
        }
    }
}
