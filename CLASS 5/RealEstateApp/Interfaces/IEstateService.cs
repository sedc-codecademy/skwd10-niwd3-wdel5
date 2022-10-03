
using RealEstateApp.Models;

namespace RealEstateApp.Interfaces
{
    public interface IEstateService
    {
        Task<List<Estate>> GetEstates();

        Task<Estate> GetEstateById(int id);

        Task<bool> DeleteEstateById(int id);
    }
}
