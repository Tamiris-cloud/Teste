using NUnit.Framework;
using Take.Helpers;
using Take.Properties;

namespace Take.Bases
{
    public class TestBase
    {
        [SetUp]
        public void SetUp()
        {
            DriverFactory.CreateInstance();
            DriverFactory.INSTANCE.Manage().Window.Maximize();
            DriverFactory.INSTANCE.Navigate().GoToUrl(Settings.Default.DEFAUL_APPLICATION_URL);
        }

        [TearDown]
        public void TearDown()
        {
            DriverFactory.QuitInstace();
        }
    }
}
