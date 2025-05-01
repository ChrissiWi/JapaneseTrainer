using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using JapaneseTrainer.Data;
using Plugin.Maui.Audio;

namespace JapaneseTrainer;

public static class MauiProgram
{
	public static IServiceProvider? Services { get; private set; }
	public static string? DatabasePath { get; private set; }

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
		ConfigureServices(builder.Services);

		var app = builder.Build();
		Services = app.Services;

		// Initialize database
		using var scope = Services.CreateScope();
		var context = scope.ServiceProvider.GetRequiredService<JapaneseTrainerContext>();
		context.Database.EnsureCreated();
		
		// Seed the database with initial data
		DatabaseInitializer.Initialize(context);

		return app;
	}

	private static void ConfigureServices(IServiceCollection services)
	{
		// Create JapaneseTrainer directory in Documents if it doesn't exist
		var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		var japaneseTrainerPath = Path.Combine(documentsPath, "JapaneseTrainer");
		Directory.CreateDirectory(japaneseTrainerPath);

		// Set database path
		DatabasePath = Path.Combine(japaneseTrainerPath, "japanesetrainer.db");
		services.AddDbContext<JapaneseTrainerContext>(options =>
			options.UseSqlite($"Data Source={DatabasePath}"));

		// Register audio service
		services.AddSingleton(AudioManager.Current);
	}
}
