using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using Take.Helpers;
using Take.Properties;

namespace Take.Bases
{
    public class PageBase
    {
        #region Objects and constructor
        protected OpenQA.Selenium.Support.UI.WebDriverWait wait { get; private set; }
        protected IWebDriver driver { get; private set; }
        protected IJavaScriptExecutor javaScript { get; private set; }

        public PageBase()
        {
            wait = new OpenQA.Selenium.Support.UI.WebDriverWait(DriverFactory.INSTANCE, TimeSpan.FromSeconds(Convert.ToDouble(Settings.Default.DEFAULT_TIMEOUT_IN_SECONDS)));
            driver = DriverFactory.INSTANCE;
            javaScript = (IJavaScriptExecutor)driver;
        }
        #endregion

        #region Custom Actions
        protected IWebElement WaitForElement(By locator)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
            return element;
        }

        protected void Click(By locator)
        {
            Stopwatch timeOut = new Stopwatch();
            timeOut.Start();

            while (timeOut.Elapsed.Seconds <= Convert.ToInt32("30")) // Properties.Settings.Default.DEFAULT_TIMEOUT_IN_SECONDS))
            {
                try
                {
                    WaitForElement(locator).Click();
                    timeOut.Stop();
                    return;
                }
                catch (System.Reflection.TargetInvocationException)
                {
                }
                catch (StaleElementReferenceException)
                {
                }
                catch (System.InvalidOperationException)
                {
                }
                catch (WebDriverException e)
                {
                    if (e.Message.Contains("Other element would receive the click"))
                    {
                        continue;
                    }

                    if (e.Message.Contains("Element is not clickable at point"))
                    {
                        continue;
                    }
                    throw e;
                }
            }
            throw new Exception("Given element isn't visible");
        }

        protected void SendKeys(By locator, string text)
        {
            WaitForElement(locator).SendKeys(text);
        }

        protected string GetText(By locator)
        {
            string text = WaitForElement(locator).Text;
            return text;
        }

        protected string GetValue(By locator)
        {
            string text = WaitForElement(locator).GetAttribute("value");
            return text;
        }

        protected bool ReturnIfElementIsDisplayed(By locator)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
            bool result = driver.FindElement(locator).Displayed;
            return result;
        }

        protected void ClickJavaScript(By locator)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            javaScript.ExecuteScript("arguments[0].click();", element);
        }
        #endregion
    }
}