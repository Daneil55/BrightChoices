using Firebase.Database;
using Microsoft.Extensions.Logging;

namespace BrightChoices
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
                    //fonts.AddFont("JosefinSans-Italic-VariableFont_wght.ttf", "Josefin1");
                    //fonts.AddFont("JosefinSans-VariableFont_wght.ttf", "Josefin2");
                     fonts.AddFont("shapes.ttf", "Icon");
                    //fonts.AddFont("MaterialSymbolsRounded-VariableFont_FILL,GRAD,opsz,wght.ttf", "Icon2");
                    //fonts.AddFont("MaterialSymbolsSharp-VariableFont_FILL,GRAD,opsz,wght.ttf", "Icon3");
                });

#if DEBUG
            builder.Services.AddSingleton(new FirebaseClient("https://brightgs-a18bb-default-rtdb.asia-southeast1.firebasedatabase.app/"));
            builder.Services.AddSingleton<Regis>();
            builder.Services.AddSingleton<MainPage>();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
