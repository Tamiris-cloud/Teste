using OpenQA.Selenium;
using System;
using Take.Properties;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;

namespace Take.Helpers
{
    public class DriverFactory
    {
        public static IWebDriver INSTANCE { get; set; } = null;

        public static void CreateInstance()
        {
            string browser = Settings.Default.BROWSER;
            string execution = Settings.Default.EXECUTION;
            string seleniumHub = Settings.Default.SELENIUM_HUB;

            if (INSTANCE == null)
            {
                switch (browser)
                {
                    case "chrome":
                        if (execution.Equals("local"))
                        {
                            INSTANCE = new ChromeDriver();
                        }

                        if (execution.Equals("remota"))
                        {
                            ChromeOptions chrome = new ChromeOptions();
                            chrome.AddArgument("no-sandbox");
                            chrome.AddArgument("--allow-running-insecure-content");
                            chrome.AddArgument("--lang=pt-BR");

                            INSTANCE = new RemoteWebDriver(new Uri(seleniumHub), chrome.ToCapabilities());
                        }

                        break;

                    case "ie":
                        if (execution.Equals("local"))
                        {
                            INSTANCE = new InternetExplorerDriver();
                        }

                        if (execution.Equals("remota"))
                        {
                            InternetExplorerOptions ie = new InternetExplorerOptions();
                            INSTANCE = new RemoteWebDriver(new Uri(seleniumHub), ie.ToCapabilities());
                        }

                        break;

                    case "firefox":
                        if (execution.Equals("local"))
                        {
                            INSTANCE = new FirefoxDriver();
                        }

                        if (execution.Equals("remota"))
                        {
                            FirefoxOptions firefox = new FirefoxOptions();
                            firefox.SetPreference("intl.accept_languages", "pt-BR");
                            INSTANCE = new RemoteWebDriver(new Uri(seleniumHub), firefox.ToCapabilities());
                        }

                        break;

                    default:
                        throw new Exception("O browser informado não existe ou não é suportado pela automação");
                }
            }
        }

        public static void QuitInstace()
        {
            INSTANCE.Quit();
            INSTANCE = null;
        }
    }
}