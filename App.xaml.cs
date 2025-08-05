namespace SentryMauiApp;

public partial class App : Application
{
	public App()
	{
		// 		SentrySdk.Init(options =>
		// 		{
		// 			options.Dsn = "https://eb18e953812b41c3aeb042e666fd3b5c@o447951.ingest.sentry.io/5428537";
		// #if DEBUG
		// 			options.Debug = true;
		// #else
		// options.Debug = false;
		// #endif
		// 			options.SendDefaultPii = true;
		// 			options.AutoSessionTracking = true;
		// 			options.IsGlobalModeEnabled = true;
		// 			options.AttachStacktrace = true;
		// 			//options.AttachScreenshots = true;
		// 			options.CaptureFailedRequests = true;
		// 		});
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new AppShell());
	}
}
