using Newtonsoft.Json;
using RealEstateApp.Interfaces;
using RealEstateApp.Models;

namespace RealEstateApp.Services
{
    public class LocalEstateService : IEstateService
    {
        private readonly IImageProvider _imageProvider;
        private long NextId => _estates.Max(x => x.Id) + 1;
        private List<Estate> _estates = new List<Estate>();
        private string PathToEstates = Path.Combine(FileSystem.AppDataDirectory, "estates.json");

        public LocalEstateService(IImageProvider imageProvider)
        {
            _imageProvider = imageProvider;
        }

        public async  Task<List<Estate>> GetEstates()
        {
			try
			{
                if (File.Exists(PathToEstates))
                {
                    var estatesJson = File.ReadAllText(PathToEstates);

                    _estates = JsonConvert.DeserializeObject<List<Estate>>(estatesJson);
                    return _estates;
                }

                if (!_estates.Any())
                {
                    using var stream = await FileSystem.OpenAppPackageFileAsync("estates.json");
                    using var reader = new StreamReader(stream);

                    var contents = reader.ReadToEnd();
                    _estates = AddImages(JsonConvert.DeserializeObject<List<Estate>>(contents));

                    WriteAllEstates();
                }

                return _estates;
            }
			catch (Exception ex)
			{
				return null;
			}
        }

        public Task<Estate> GetEstateById(long id)
        {
            return Task.FromResult(_estates.FirstOrDefault(x => x.Id == id));
        }

        private List<Estate> AddImages(List<Estate> estates)
        {
            foreach (var estate in estates)
            {
                estate.Photo = _imageProvider.GetImage();
                estate.Photos = _imageProvider.GetImages(5);
            }

            return estates;
        }

        public Task<bool> DeleteEstateById(long id)
        {
            var estate = _estates.FirstOrDefault(x => x.Id == id);

            if (estate == null)
            {
                return Task.FromResult(false);
            }

            _estates.Remove(estate);

            WriteAllEstates();

            return Task.FromResult(true);
        }

        public Task<Estate> Update(Estate estate)
        {
            var estateToUpdate = _estates.FirstOrDefault(x=> x.Id == estate.Id);

            if (estateToUpdate == null)
            {
                return Task.FromResult(default(Estate));
            }

            estateToUpdate.EstateName = estate.EstateName;
            estateToUpdate.Address = estate.Address;
            estateToUpdate.RoomNumber = estate.RoomNumber;
            estateToUpdate.BathroomNumber = estate.BathroomNumber;
            estateToUpdate.Area = estate.Area;
            estateToUpdate.Price = estate.Price;
            estateToUpdate.ContactPersonName = estate.ContactPersonName;
            estateToUpdate.ContactPersonEmail = estate.ContactPersonEmail;
            estateToUpdate.ContactPersonPhone = estate.ContactPersonPhone;

            WriteAllEstates();

            return Task.FromResult(estateToUpdate);
        }

        public Task<Estate> Create(Estate estate)
        {
            estate.Id = NextId;
            _estates.Insert(0, estate);

            WriteAllEstates();

            return Task.FromResult(estate);
        }

        private void WriteAllEstates()
        {
            File.WriteAllText(PathToEstates, JsonConvert.SerializeObject(_estates));
        }
    }
}
