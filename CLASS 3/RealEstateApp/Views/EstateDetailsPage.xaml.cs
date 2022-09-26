namespace RealEstateApp.Views;

public partial class EstateDetailsPage : ContentPage
{
	public EstateDetailsPage()
	{
		InitializeComponent();
		imageCarousel.ItemsSource = new List<string> { "img0.png", "img1.png", "img2.png" };
	}
}