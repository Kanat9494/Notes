
namespace Notes;

[XamlCompilation(XamlCompilationOptions.Compile)]
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
			.UseSharpnadoCollectionView(loggerEnable: false);


#if DEBUG
        builder.Logging.AddDebug();
#endif



		return builder.Build();
	}
}
