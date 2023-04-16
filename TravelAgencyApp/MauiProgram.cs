using Microsoft.Extensions.DependencyInjection;
using TravelAgencyApp.ViewModels;
using TravelAgencyApp.Views;

namespace TravelAgencyApp;

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
		builder.Services.AddSingleton<MenuShell>();
        builder.Services.AddSingleton<AuthenticationView>();
        builder.Services.AddSingleton<RegisterPageView>();
        builder.Services.AddSingleton<ProfileView>();
        builder.Services.AddSingleton<BasketView>();
        builder.Services.AddSingleton<MainMenu>();

        builder.Services.AddSingleton<AuthenticationViewModel>();
        builder.Services.AddSingleton<RegisterViewModel>();
        builder.Services.AddSingleton<MainMenuViewModel>();
        return builder.Build();
	}
}
