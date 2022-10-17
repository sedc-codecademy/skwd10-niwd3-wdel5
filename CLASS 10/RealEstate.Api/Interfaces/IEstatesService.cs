using RealEstate.Api.Models;

namespace RealEstate.Api.Interfaces
{
    public interface IEstatesService
    {
        Task<List<Estate>> GetEstates();

        Task<Estate> GetEstateById(long id);

        Task<Estate> Create(Estate estate);

        Task<Estate> Update(Estate estate);

        Task<bool> DeleteEstateById(long id);
    }
}
