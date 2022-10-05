using RealEstateApp.Views;

namespace RealEstateApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(EstateDetailsPage), typeof(EstateDetailsPage));
		Routing.RegisterRoute(nameof(UpsertPage), typeof(UpsertPage));
	}

	private void LogoutClicked(object sender, EventArgs e)
	{
		GoToAsync("//LoginPage");
		Preferences.Default.Set(LoginPage.IsLoggedInKey, false);
    }
}
