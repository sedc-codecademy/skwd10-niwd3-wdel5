﻿using Newtonsoft.Json;
using RealEstateApp.Interfaces;
using RealEstateApp.Models;

namespace RealEstateApp.Services
{
    public class LocalEstateService : IEstateService
    {
        private readonly IImageProvider _imageProvider;
        private List<Estate> _estates = new List<Estate>();

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
                _estates = AddImages(JsonConvert.DeserializeObject<List<Estate>>(contents));

                return _estates;
            }
			catch (Exception ex)
			{
				return null;
			}
        }

        public Task<Estate> GetEstateById(int id)
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
    }
}
