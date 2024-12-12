using Microsoft.Extensions.Logging;
using PosterHorder.Constants;
using PosterHorder.Services;

namespace PosterHorder
{
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<ISearchMoviesService, SearchMoviesService>();
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(ApiAddress.baseAddress)
            });
            // TODO: Move hardcoded API path above
            return builder.Build();
        }
    }
}
