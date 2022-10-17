namespace RealEstateApp.Interfaces
{
    public interface IMyPreferences
    {
        T Get<T>(string key, T defaultValue);
        void Set<T>(string key, T value);
    }
}
