namespace SandboxApp.Data;

public partial class RestCallPage : ContentPage
{
	public RestCallPage()
	{
		InitializeComponent();
		BindingContext = new RestViewModel();
	}
}