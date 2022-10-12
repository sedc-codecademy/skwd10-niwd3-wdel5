using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RealEstateApp.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private const string PasswordValue = "123";
        public static readonly string IsLoggedInKey = "IsLoggedInKey";

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
                Shell.Current.GoToAsync("//Estates");
                Preferences.Default.Set(IsLoggedInKey, true); 
            }
            else
            {
                NotValid = true;
            }
        }

        public LoginViewModel()
        {
            if (Preferences.Default.Get(IsLoggedInKey, false))
            {
                Shell.Current.GoToAsync("//Estates");
            }
        }
    }
}
