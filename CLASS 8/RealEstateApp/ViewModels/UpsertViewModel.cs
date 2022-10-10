using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RealEstateApp.Interfaces;
using RealEstateApp.Models;

namespace RealEstateApp.ViewModels
{
    [QueryProperty(nameof(EstateId), nameof(EstateId))]
    [QueryProperty(nameof(IsUpdate), nameof(IsUpdate))]
    public partial class UpsertViewModel : Estate
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

        private bool _isUpdate;
        public bool IsUpdate
        {
            get => _isUpdate;
            set
            {
                _isUpdate = value;
                Title = _isUpdate ? "Update" : "Create";
                ActionIcon = _isUpdate ? "save" : "create";
            }
        }

        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private string _actionIcon;
        

        public UpsertViewModel(IEstateService estateService)
        {
            _estateService = estateService;
        }

        [RelayCommand]
        private async Task Upsert()
        {
            if (IsUpdate)
            {
                await _estateService.Update(this);
            }
            else
            {
                await _estateService.Create(this);
            }

            await Shell.Current.GoToAsync("..?Update=true");
        }

        private void InitView(Task<Estate> task)
        {
            var estate = task.Result;

            MainThread.BeginInvokeOnMainThread(() =>
            {
                Id = estate.Id;
                EstateName = estate.EstateName;
                Address = estate.Address;
                Price = estate.Price;
                RoomNumber = estate.RoomNumber;
                BathroomNumber = estate.BathroomNumber;
                Area = estate.Area;
                ContactPersonName = estate.ContactPersonName;
                ContactPersonEmail = estate.ContactPersonEmail;
                ContactPersonPhone = estate.ContactPersonPhone;
            });
        }
    }
}
