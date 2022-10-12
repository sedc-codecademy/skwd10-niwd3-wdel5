namespace RealEstateApp.Interfaces
{
    public interface IRestService
    {
        Task<T> GetAsync<T>(string route);

        Task<T> PostAsync<T>(string route, object body);

        Task<T> PatchAsync<T>(string route, object body);

        Task<bool> DeleteAsync(string route);
    }
}
