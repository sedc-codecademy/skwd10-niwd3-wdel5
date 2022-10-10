using RealEstateApp.Interfaces;
using RealEstateApp.Models;
using RealEstateApp.ViewModels;

namespace RealEstateApp.Views;

public partial class EstateDetailsPage : ContentPage
{
	public EstateDetailsPage(EstateDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}