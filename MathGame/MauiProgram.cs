using MathGame.Data;
using Microsoft.Extensions.Logging;

namespace MathGame
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
            //dependency injection
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "game.db");
            //registering service 
            builder.Services.AddSingleton( s => 
            ActivatorUtilities.CreateInstance<GameRepository>(s, dbPath) );

            return builder.Build();
        }
    }
}
