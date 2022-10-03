using RealEstateApp.Interfaces;
using RealEstateApp.Models;
using System.Collections.ObjectModel;

namespace RealEstateApp.Views;

public partial class EstatesPage : ContentPage
{
	private bool _isSwiping;
	private ObservableCollection<Estate> _estates;
	private readonly IEstateService _estateService;

	public EstatesPage(IEstateService estateService)
	{
		InitializeComponent();

        estateService.GetEstates().ContinueWith(SetEstates);
		_estateService = estateService;
	}

	private void SetEstates(Task<List<Estate>> task)
	{
		MainThread.BeginInvokeOnMainThread(() =>
		{
			_estates = new ObservableCollection<Estate>(task.Result);
			collectionView.ItemsSource = _estates;
		});
	}

	private void EstatesCollectionSelectionChange(object sender, SelectionChangedEventArgs e)
	{
		if (collectionView.SelectedItem == null || _isSwiping)
		{
			return;
		}

		var selectedEstate = (Estate)collectionView.SelectedItem;
		Shell.Current.GoToAsync($"{nameof(EstateDetailsPage)}?EstateId={selectedEstate.Id}");
		collectionView.SelectedItem = null;
	}

	private void SwipeView_SwipeStarted(object sender, SwipeStartedEventArgs e)
	{
		_isSwiping = true;
	}

	private void SwipeView_SwipeEnded(object sender, SwipeEndedEventArgs e)
	{
		_isSwiping = false;
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
		_estates.Remove(estate);
	}
}