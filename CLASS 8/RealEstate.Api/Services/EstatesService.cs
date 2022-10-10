using RealEstate.Api.Interfaces;
using RealEstate.Api.Models;

namespace RealEstate.Api.Services
{
    public class EstatesService : IEstatesService
    {
        public Task<Estate> Create(Estate estate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEstateById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Estate> GetEstateById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Estate>> GetEstates()
        {
            throw new NotImplementedException();
        }

        public Task<Estate> Update(Estate estate)
        {
            throw new NotImplementedException();
        }
    }
}
