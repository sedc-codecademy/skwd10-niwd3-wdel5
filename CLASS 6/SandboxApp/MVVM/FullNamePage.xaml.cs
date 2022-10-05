namespace SandboxApp.MVVM;

public partial class FullNamePage : ContentPage
{
	public FullNamePage()
	{
		InitializeComponent();
		BindingContext = new FullPageViewModel();
	}

	//private void Entry_TextChanged(object sender, TextChangedEventArgs e)
	//{
	//	//llNameLabel.Text = $"{FirstNameLabel.Text} {LastNameLabel.Text}";
	//}
}