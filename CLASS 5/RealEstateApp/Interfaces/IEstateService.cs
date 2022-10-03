
using RealEstateApp.Models;

namespace RealEstateApp.Interfaces
{
    public interface IEstateService
    {
        Task<List<Estate>> GetEstates();

        Task<Estate> GetEstateById(long id);

        Task<bool> DeleteEstateById(long id);
    }
}
