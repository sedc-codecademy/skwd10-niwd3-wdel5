using FluentAssertions;
using NSubstitute;
using NuGet.Frameworks;
using NUnit.Framework;
using RealEstateApp.Interfaces;
using RealEstateApp.ViewModels;

namespace RealEstate.UnitTests
{
    public class LoginViewModelTests
    {
        private IMyPreferences _preferences;
        private INavigationService _navigationService;

        [SetUp]
        public void Setup()
        {
            _preferences = Substitute.For<IMyPreferences>();
            _navigationService = Substitute.For<INavigationService>();
        }

        [Test]
        public void WhenIncorrectPasswordIsEntered_ErrorLabelIsShown()
        {
            _preferences.Get<bool>(LoginViewModel.IsLoggedInKey, false).Returns(false);
            var sut = new LoginViewModel(_preferences, _navigationService);
            sut.Username = "Username";
            sut.Password = "WrongPassword";

            sut.LoginCommand.Execute(null);

            sut.NotValid.Should().BeTrue();
        }

        [Test]
        public void WhenUserAlreadyLoggedIn_UserIsNavigatedToEstates()
        {
            _preferences.Get<bool>(LoginViewModel.IsLoggedInKey, false).Returns(true);

            var sut = new LoginViewModel(_preferences, _navigationService);

            _navigationService.Received(1).GoToAsync("//Estates");
        }
    }
}
