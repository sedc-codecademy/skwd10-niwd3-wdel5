using RealEstateApp.Interfaces;
using RealEstateApp.Models;
using RealEstateApp.ViewModels;
using System.Collections.ObjectModel;

namespace RealEstateApp.Views;

public partial class EstatesPage : ContentPage
{
	private readonly IEstateService _estateService;

	public EstatesPage(EstatesViewModel vm,
		IEstateService estateService)
	{
		InitializeComponent();
		BindingContext = vm;
		_estateService = estateService;
	}

	private void SwipeView_SwipeStarted(object sender, SwipeStartedEventArgs e)
	{
		((EstatesViewModel)BindingContext).IsSwiping = true;
	}

	private void SwipeView_SwipeEnded(object sender, SwipeEndedEventArgs e)
	{
        ((EstatesViewModel)BindingContext).IsSwiping = false;
        collectionView.SelectedItem = null;
	}

	private void EditInvoked(object sender, EventArgs e)
	{

	}

	private void DeleteInvoked(object sender, EventArgs e)
	{
		var swipeItem = (SwipeItem)sender;
		var estate = (Estate)swipeItem.BindingContext;
		_estateService.DeleteEstateById(estate.Id);
	}
}