using Newtonsoft.Json;
using RealEstateApp.Interfaces;
using RealEstateApp.Models;

namespace RealEstateApp.Services
{
    public class LocalEstateService : IEstateService
    {
        private readonly IImageProvider _imageProvider;

        public LocalEstateService(IImageProvider imageProvider)
        {
            _imageProvider = imageProvider;
        }

        public async  Task<List<Estate>> GetEstates()
        {
			try
			{
                using var stream = await FileSystem.OpenAppPackageFileAsync("estates.json");
                using var reader = new StreamReader(stream);

                var contents = reader.ReadToEnd();
                var estates = AddImages(JsonConvert.DeserializeObject<List<Estate>>(contents));

                return estates;
            }
			catch (Exception ex)
			{
				return null;
			}
        }

        private List<Estate> AddImages(List<Estate> estates)
        {
            foreach (var estate in estates)
            {
                estate.Photo = _imageProvider.GetImage();
            }

            return estates;
        }
    }
}
