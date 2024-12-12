using Microsoft.Extensions.Logging;
using PosterHorder.Constants;
using PosterHorder.Services;
using PosterHorder.ViewModels;

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
            builder.Services.AddSingleton<SearchMoviesViewModel>();
            builder.Services.AddSingleton<ISearchMoviesService, SearchMoviesService>();
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(ApiAddress.baseAddress)
            });
            return builder.Build();
        }
    }
}
