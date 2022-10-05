using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using RealEstateApp.Interfaces;
using RealEstateApp.Models;
using RealEstateApp.Views;
using System.Collections.ObjectModel;

namespace RealEstateApp.ViewModels
{
    public partial class EstatesViewModel : ObservableObject
    {
        private readonly IEstateService _estateService;

        public bool IsSwiping { get; set; }

        [ObservableProperty]
        private ObservableCollection<Estate> _estates;

        [ObservableProperty]
        private Estate _selectedItem;

        public EstatesViewModel(IEstateService estateService)
        {
            estateService.GetEstates().ContinueWith(SetEstates);
            _estateService = estateService;
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
            Shell.Current.GoToAsync(nameof(UpsertPage));
        }

        [RelayCommand]
        private void Delete()
        {
            System.Diagnostics.Debug.WriteLine("a");
            //_estateService.DeleteEstateById(estate.Id);
            //_estates.Remove(estate);
        }

        //[RelayCommand]
        //private void Edit()
        //{

        //}
    }
}
