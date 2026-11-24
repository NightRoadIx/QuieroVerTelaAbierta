using Microsoft.Extensions.Logging;
using QuieroVerTelaAbierta.ViewModels;
using QuieroVerTelaAbierta.Views;

namespace QuieroVerTelaAbierta
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

            // El registro
            // Lo que se busca es que: "cuando alguien pida esto, dale aquellito"
            builder.Services.AddTransient<ContadorViewModel>();
            builder.Services.AddTransient<ContadorPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
