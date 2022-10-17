using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace RealEstate.UITests
{
    public class UITests
    {
        private AndroidDriver<AndroidElement> _driver;
        private DefaultWait<AndroidDriver<AndroidElement>> _wait;

        [SetUp]
        public void Setup()
        {
            var driverOption = new AppiumOptions();
            driverOption.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOption.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "12");
            driverOption.AddAdditionalCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            driverOption.AddAdditionalCapability("appPackage", "com.companyname.realestateapp");
            driverOption.AddAdditionalCapability("appActivity", "crc6487c6afeb28c0d00b.MainActivity");

            _driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), driverOption);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);

            _wait = new DefaultWait<AndroidDriver<AndroidElement>>(_driver)
            {
                Timeout = TimeSpan.FromSeconds(30),
                PollingInterval = TimeSpan.FromSeconds(500),
            };
            _wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            _driver.LaunchApp();
        }

        [Test]
        public void WhenWrongPasswordIsEntered_ErrorLabelIsShown()
        {
            var userename = _driver.FindElementById(GetElement("Username"));
            var password = _driver.FindElementById(GetElement("Password"));
            var button = _driver.FindElementById(GetElement("LoginButton"));

            userename.SendKeys("Username");
            password.SendKeys("WrongPassword");
            button.Click();

            var errorLabel = _wait.Until((driver) =>
            {
                return driver.FindElementById(GetElement("ErrorLabel"));
            });
            errorLabel.Should().NotBeNull();
        }

        [Test]
        public void WhenCorrectPasswordIsEntered_UserIsNavigatedToEstatesPage()
        {
            var userename = _driver.FindElementById(GetElement("Username"));
            var password = _driver.FindElementById(GetElement("Password"));
            var button = _driver.FindElementById(GetElement("LoginButton"));

            userename.SendKeys("Username");
            password.SendKeys("123");
            button.Click();

            var estatesPage = _wait.Until((driver) =>
            {
                return driver.FindElementById(GetElement("EstatesPage"));
            });
            estatesPage.Should().NotBeNull();
        }

        [Test]
        public void TestScrollingAction()
        {
            var username = _driver.FindElementById(GetElement("Username"));
            var password = _driver.FindElementById(GetElement("Password"));
            var loginButton = _driver.FindElementById(GetElement("LoginButton"));

            username.SendKeys("Hello World");
            password.SendKeys("123");
            loginButton.Click();

            var estatesPage = _wait.Until(driver => driver.FindElementById(GetElement("EstatesPage")));

            var collectionView = _driver.FindElementById(GetElement("Collection"));

            FlickUp(_driver, collectionView);
            Thread.Sleep(500);
            FlickUp(_driver, collectionView);
            Thread.Sleep(500);
            FlickUp(_driver, collectionView);
        }

        private void FlickUp(AndroidDriver<AndroidElement> driver, AndroidElement element)
        {
            var input = new PointerInputDevice(PointerKind.Touch);
            ActionSequence flickUp = new ActionSequence(input);
            flickUp.AddAction(input.CreatePointerMove(element, 0, 400, TimeSpan.Zero));
            flickUp.AddAction(input.CreatePointerDown(MouseButton.Left));
            flickUp.AddAction(input.CreatePointerMove(element, 0, -400, TimeSpan.FromMilliseconds(200)));
            flickUp.AddAction(input.CreatePointerUp(MouseButton.Left));

            driver.PerformActions(new List<ActionSequence> { flickUp });
        }

        [TearDown]
        public void TearDown()
        {
            _driver.CloseApp();
            _driver?.Dispose();
        }

        private string GetElement(string id) => $"com.companyname.realestateapp:id/{id}";
    }
}
