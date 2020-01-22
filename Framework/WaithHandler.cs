using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework
{
    public static class WaithHandler
    {

        public static void WaitForBeClickable(IWebDriver _driver, IWebElement _element)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
                wait.Until(driver1 => Visibility(_element));
                wait.Until(driver1 => Present(_element));
            }
            catch (WebDriverTimeoutException)
            {

            }
        }

        public static bool Visibility(IWebElement _element)
        {
            bool flag = false;
            try
            {
                flag = _element.Displayed;
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }

        private static bool Present(IWebElement _element)
        {
            bool flag;
            try
            {
                flag = _element != null;
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }
    }

}
