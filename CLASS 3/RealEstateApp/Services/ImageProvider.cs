﻿using RealEstateApp.Interfaces;

namespace RealEstateApp.Services
{
    public class ImageProvider : IImageProvider
    {
        private int _currentImage;

        private readonly List<string> _images = new List<string>
        {
            "img0.png",
            "img1.png",
            "img2.png",
            "img3.png",
            "img4.png",
            "img5.png",
            "img6.png",
            "img7.png",
        };

        public string GetImage()
        {
            if (_currentImage == _images.Count)
            {
                _currentImage = 0;
            }

            var image = _images[_currentImage];
            _currentImage++;

            return image;
        }
    }
}
