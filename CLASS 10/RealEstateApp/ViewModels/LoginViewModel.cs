using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RealEstateApp.Interfaces;

namespace RealEstateApp.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private const string PasswordValue = "123";
        public static readonly string IsLoggedInKey = "IsLoggedInKey";
        private readonly IMyPreferences _preferences;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private string _username;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private bool _notValid;

        [RelayCommand]
        private void Login()
        {
            if (!string.IsNullOrEmpty(Username)
                && !string.IsNullOrEmpty(Password)
                && Password == PasswordValue)
            {
                _navigationService.GoToAsync("//Estates");
                _preferences.Set(IsLoggedInKey, true); 
            }
            else
            {
                NotValid = true;
            }
        }

        public LoginViewModel(IMyPreferences preferences,
            INavigationService navigationService)
        {
            _preferences = preferences;
            _navigationService = navigationService;

            var a = _preferences.Get(IsLoggedInKey, false);

            if (_preferences.Get(IsLoggedInKey, false))
            {
                _navigationService.GoToAsync("//Estates");
            }
        }
    }
}
