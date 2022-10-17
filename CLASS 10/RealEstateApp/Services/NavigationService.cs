using RealEstateApp.Interfaces;

namespace RealEstateApp.Services
{
    public class NavigationService : INavigationService
    {
        public async Task GoToAsync(string path)
        {
            await Shell.Current.GoToAsync(path);
        }
    }
}
