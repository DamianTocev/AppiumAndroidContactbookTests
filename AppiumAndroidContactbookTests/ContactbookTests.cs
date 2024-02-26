using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace ContactbookTests
{
    public class ContactbookTests
    {
        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;
        private const string appLocation = @"D:\RABOTNA\CODING\Projects\QA_Automation\APK-Fiels\contactbook-androidclient.apk";
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";


        [SetUp]
        public void PrepareApp()

        {
            this.options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", appLocation);
            driver = new AndroidDriver<AndroidElement>(new Uri(appiumServer), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void CloseApp()
        {
            driver.Dispose();
        }

        [Test]
        public void Test_Check_Name()
        {
            //var urlToAdd = "https://contactbook.geriehristova.repl.co/api";
            var urlToAdd = "https://38b0d77d-2341-4341-928b-3b9b51d48e22-00-1pnueuv4c0prr.janeway.replit.dev/api";

            var inputField = driver.FindElementById("contactbook.androidclient:id/editTextApiUrl");
            inputField.Click();
            inputField.Clear();
            inputField.SendKeys(urlToAdd);

            var connectButton = driver.FindElementById("contactbook.androidclient:id/buttonConnect");
            connectButton.Click();

            var searchField = driver.FindElementById("contactbook.androidclient:id/editTextKeyword");
            searchField.Click();
            searchField.SendKeys("steve");

            var searchButton = driver.FindElementById("contactbook.androidclient:id/buttonSearch");
            searchButton.Click();

            //Thread.Sleep(3000);

            var firstName = driver.FindElementById("contactbook.androidclient:id/textViewFirstName");
            var lastName = driver.FindElementById("contactbook.androidclient:id/textViewLastName");

            Assert.That(firstName.Text, Is.EqualTo("Steve"));
            Assert.That(lastName.Text, Is.EqualTo("Jobs"));
        }
    }
}