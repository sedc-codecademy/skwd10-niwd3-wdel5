using RealEstateApp.ViewModels;

namespace RealEstateApp.Views;

public partial class UpsertPage : ContentPage
{
	public UpsertPage(UpsertViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}