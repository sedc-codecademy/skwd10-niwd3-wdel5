using RealEstateApp.Interfaces;

namespace RealEstateApp.Services
{
    public class MyPreferences : IMyPreferences
    {
        public T Get<T>(string key, T defaultValue)
        {
            return Preferences.Default.Get<T>(key, defaultValue);
        }

        public void Set<T>(string key, T value)
        {
            Preferences.Default.Set(key, value);
        }
    }
}
