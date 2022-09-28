using RealEstateApp.Interfaces;
using RealEstateApp.Models;

namespace RealEstateApp.Views;

[QueryProperty(nameof(EstateId), nameof(EstateId))]
public partial class EstateDetailsPage : ContentPage
{
	private int _estateId;
	private readonly IEstateService _estateService;

	public int EstateId
	{
		get => _estateId;
		set
		{
			_estateId = value;
			Task.Run(()=> GetEstate(value)).ContinueWith(InitView);
		}
	}

	public EstateDetailsPage(IEstateService estateService)
	{
		InitializeComponent();
		_estateService = estateService;
	}

    private async Task<Estate> GetEstate(int id)
    {
		return await _estateService.GetEstateById(id);
    }

    private void InitView(Task<Estate> task)
    {
		var estate = task.Result;

		MainThread.BeginInvokeOnMainThread(() =>
		{
			Photo.Source = estate.Photo;
			EstateName.Text = estate.EstateName;
			Address.Text = estate.Address;
			Price.Text = $"$ {estate.Price}";
			Bedrooms.Text = $"{estate.RoomNumber} bedrooms";
			Bathrooms.Text = $"{estate.BathroomNumber} bathrooms";
			Area.Text = $"{estate.Area} m²";
			Photos.ItemsSource = estate.Photos;
			ContactPersonName.Text = estate.ContactPersonName;
			ContactPersonEmail.Text = estate.ContactPersonEmail;
			ContactPersonPhone.Text = estate.ContactPersonPhone;
        });
    }
}