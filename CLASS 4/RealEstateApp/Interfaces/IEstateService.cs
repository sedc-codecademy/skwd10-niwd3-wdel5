
using RealEstateApp.Models;
using System.Threading.Tasks;

namespace RealEstateApp.Interfaces
{
    public interface IEstateService
    {
        Task<List<Estate>> GetEstates();

        Task<Estate> GetEstateById(int id);
    }
}
