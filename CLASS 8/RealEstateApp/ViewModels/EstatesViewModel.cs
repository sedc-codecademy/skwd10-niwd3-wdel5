using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RealEstateApp.Interfaces;
using RealEstateApp.Models;
using RealEstateApp.Views;
using System.Collections.ObjectModel;

namespace RealEstateApp.ViewModels
{
    [QueryProperty(nameof(Update), nameof(Update))]
    public partial class EstatesViewModel : ObservableObject
    {
        private readonly IEstateService _estateService;
        private bool _notDeleting = true;

        private bool _update;
        public bool Update
        {
            get => _update;
            set
            {
                _update = value;
                LoadData();
            }
        }

        public bool IsSwiping { get; set; }

        [ObservableProperty]
        private ObservableCollection<Estate> _estates;

        [ObservableProperty]
        private Estate _selectedItem;

        public EstatesViewModel(IEstateService estateService)
        {
            _estateService = estateService;
            LoadData();
        }

        private void LoadData()
        {
            _estateService.GetEstates().ContinueWith(SetEstates);
        }

        private void SetEstates(Task<List<Estate>> task)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Estates = new ObservableCollection<Estate>(task.Result);
            });
        }

        [RelayCommand]
        private void EstatesSelectionChanged()
        {
            if (SelectedItem == null || IsSwiping)
            {
                return;
            }

            Shell.Current.GoToAsync($"{nameof(EstateDetailsPage)}?EstateId={SelectedItem.Id}");
            SelectedItem = null;
        }

        [RelayCommand]
        private void CreateEstate()
        {
            Shell.Current.GoToAsync($"{nameof(UpsertPage)}?IsUpdate=false");
        }

        [RelayCommand(CanExecute = nameof(CanDelete))]
        private async Task Delete(Estate estate)
        {
            _notDeleting = false;
            await _estateService.DeleteEstateById(estate.Id);

            MainThread.BeginInvokeOnMainThread(() =>
            {
                _estates.Remove(estate);
            });

            _estates.Remove(estate);
            _notDeleting = true;
        }

        private bool CanDelete()
        {
            return _notDeleting;
        }

        [RelayCommand]
        private void Edit(Estate estate)
        {
            Shell.Current.GoToAsync($"{nameof(UpsertPage)}?EstateId={estate.Id}&IsUpdate=true");
        }
    }
}
