using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WorkoutTimers.App.Views;
using WorkoutTimers.Lib.Services;
using WorkoutTimers.Lib.ViewModels;

namespace WorkoutTimers.App
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
				})
				.Services
				.AddSingleton<IIntervalService,InMemoryIntervalService>()
				.AddSingleton<RegularIntervalModel>()
				.AddTransient<NewRegularIntervalModel>()
				.AddSingleton<StaggeredIntervalModel>()
				.AddTransient<NewStaggeredIntervalModel>()
				.AddSingleton<SettingsModel>()
				.AddSingleton<StaggeredIntervals>()
				.AddSingleton<RegularIntervals>()
				.AddTransient<NewStaggeredInterval>()
				.AddTransient<NewRegularInterval>()
				.AddSingleton<Settings>();


#if DEBUG
		builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}