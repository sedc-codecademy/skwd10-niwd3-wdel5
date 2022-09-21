using Newtonsoft.Json;
using RealEstateApp.Interfaces;
using RealEstateApp.Models;

namespace RealEstateApp.Services
{
    public class LocalEstateService : IEstateService
    {
        public async  Task<List<Estate>> GetEstates()
        {
			try
			{
                using var stream = await FileSystem.OpenAppPackageFileAsync("estates.json");
                using var reader = new StreamReader(stream);

                var contents = reader.ReadToEnd();

                return JsonConvert.DeserializeObject<List<Estate>>(contents);
            }
			catch (Exception ex)
			{
				return null;
			}
        }
    }
}
