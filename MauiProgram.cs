using FluentIcons.Maui;
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
                .UseFluentIcons(true)
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("SF Hollywood Hills Bold.ttf", "HollywoodHillsBold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<SearchMoviesViewModel>();

            builder.Services.AddTransient<BigPosterPage>();
            builder.Services.AddTransient<BigPosterViewModel>();
            
            builder.Services.AddTransient<ISearchMoviesService, SearchMoviesService>();
            
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(ApiAddress.queryBaseAddress)
            });
            return builder.Build();
        }
    }
}
