using RealEstateApp.ViewModels;

namespace RealEstateApp.Views;

public partial class LoginPage : ContentPage
{
	public static readonly string IsLoggedInKey = "IsLoggedInKey";


    public LoginPage(LoginViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}