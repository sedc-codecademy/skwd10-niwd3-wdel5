namespace RealEstateApp.Views;

public partial class LoginPage : ContentPage
{
	public static readonly string IsLoggedInKey = "IsLoggedInKey";


    public LoginPage()
	{
		InitializeComponent();
		if (Preferences.Default.Get(IsLoggedInKey, false))
		{
            Shell.Current.GoToAsync("//Estates");
        }
	}

	private void LoginClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Estates");
		Preferences.Default.Set(IsLoggedInKey, true);
	}
}