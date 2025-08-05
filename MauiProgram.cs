using Microsoft.Extensions.Logging;

namespace SentryMauiApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseSentry(options =>
						{
							options.Dsn = "https://eb18e953812b41c3aeb042e666fd3b5c@o447951.ingest.sentry.io/5428537";
							options.Debug = true;
							// #if DEBUG
							// 							options.Debug = true;
							// #else
							// 							options.Debug = false;
							// #endif
							options.SendDefaultPii = true;
							options.AutoSessionTracking = true;
							options.IsGlobalModeEnabled = true;
							options.AttachStacktrace = true;
							options.AttachScreenshot = true;
							options.CaptureFailedRequests = true;
						})
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
