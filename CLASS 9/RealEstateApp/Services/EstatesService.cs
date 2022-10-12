using RealEstateApp.Interfaces;
using RealEstateApp.Models;

namespace RealEstateApp.Services
{
    public class EstatesService : IEstateService
    {
        private const string EstatesRoute = "Estates";
        private readonly IRestService _restService;

        public EstatesService(IRestService restService)
        {
            _restService = restService;
        }

        public async Task<List<Estate>> GetEstates()
        {
            return await _restService.GetAsync<List<Estate>>(EstatesRoute);
        }

        public async Task<Estate> GetEstateById(long id)
        {
            return await _restService.GetAsync<Estate>($"{EstatesRoute}/{id}");
        }

        public async Task<Estate> Create(Estate estate)
        {
            return await _restService.PostAsync<Estate>(EstatesRoute, estate);
        }

        public async Task<Estate> Update(Estate estate)
        {
            return await _restService.PatchAsync<Estate>(EstatesRoute, estate);
        }

        public async Task<bool> DeleteEstateById(long id)
        {
            return await _restService.DeleteAsync($"{EstatesRoute}/{id}");
        }
    }
}
