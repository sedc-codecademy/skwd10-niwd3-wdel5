using RealEstateApp.Interfaces;
using RealEstateApp.Models;
using RealEstateApp.ViewModels;
using System.Collections.ObjectModel;

namespace RealEstateApp.Views;

public partial class EstatesPage : ContentPage
{
	public EstatesPage(EstatesViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
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
}