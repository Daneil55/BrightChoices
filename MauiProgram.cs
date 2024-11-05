using Firebase.Database;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Maps;
using Plugin.Maui.Audio;

namespace BrightChoices
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkitMediaElement()
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
            builder.Services.AddSingleton(AudioManager.Current);
            builder.Services.AddTransient<Forum>();

            builder.Services.AddSingleton<MessangerPage> ();
            builder.Services.AddSingleton<MessagersList> ();
            builder.Services.AddSingleton<LearningProgress>();
            builder.Services.AddSingleton<Regis>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<Publisherxaml>();
            builder.Services.AddSingleton<ProfilePage>();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
