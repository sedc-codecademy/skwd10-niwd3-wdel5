using RealEstateApp.Interfaces;
using RealEstateApp.Models;

namespace RealEstateApp.ViewModels
{
    [QueryProperty(nameof(EstateId), nameof(EstateId))]
    public partial class EstateDetailsViewModel : Estate
    {
        private readonly IEstateService _estateService;

        private int _estateId;
        public int EstateId
        {
            get => _estateId;
            set
            {
                _estateId = value;
                Task.Run(() => _estateService.GetEstateById(value)).ContinueWith(InitView);
            }
        }

        public EstateDetailsViewModel(IEstateService estateService)
        {
            _estateService = estateService;
        }

        private void InitView(Task<Estate> task)
        {
            var estate = task.Result;

            MainThread.BeginInvokeOnMainThread(() =>
            {
                Photo = estate.Photo;
                EstateName = estate.EstateName;
                Address = estate.Address;
                Price = estate.Price;
                RoomNumber = estate.RoomNumber;
                BathroomNumber = estate.BathroomNumber;
                Area = estate.Area;
                Photos = estate.Photos;
                ContactPersonName = estate.ContactPersonName;
                ContactPersonEmail = estate.ContactPersonEmail;
                ContactPersonPhone = estate.ContactPersonPhone;
            });
        }
    }
}
