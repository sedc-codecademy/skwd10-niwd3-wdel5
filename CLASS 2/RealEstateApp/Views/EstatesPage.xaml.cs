using RealEstateApp.Models;
using RealEstateApp.Services;

namespace RealEstateApp.Views;

public partial class EstatesPage : ContentPage
{
	public EstatesPage()
	{
		InitializeComponent();
		var service = new LocalEstateService();

		service.GetEstates().ContinueWith(SetEstates);
	}

	private void SetEstates(Task<List<Estate>> task)
	{
		MainThread.BeginInvokeOnMainThread(() =>
		{
			collectionView.ItemsSource = task.Result;
		});
	}
}