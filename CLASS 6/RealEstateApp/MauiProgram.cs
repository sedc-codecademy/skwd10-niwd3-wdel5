using RealEstateApp.Interfaces;
using RealEstateApp.Services;
using RealEstateApp.ViewModels;
using RealEstateApp.Views;

namespace RealEstateApp;

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

		builder.Services.AddSingleton<IEstateService, LocalEstateService>();
		builder.Services.AddSingleton<IImageProvider, ImageProvider>();

		builder.Services.AddSingleton<LoginPage>();
		builder.Services.AddTransient<EstatesPage>();
		builder.Services.AddTransient<EstateDetailsPage>();
		builder.Services.AddTransient<UpsertPage>();

		builder.Services.AddTransient<LoginViewModel>();
		builder.Services.AddTransient<EstatesViewModel>();
        builder.Services.AddTransient<EstateDetailsViewModel>();
		builder.Services.AddTransient<UpsertViewModel>();

        return builder.Build();
	}
}
