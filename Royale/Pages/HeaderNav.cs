using Framework.Selenium;
using OpenQA.Selenium;
using System;

namespace Royale.Pages
{
    public class HeaderNav
    {
        public readonly HeaderNavMap Map;

        public HeaderNav()
        {
            Map = new HeaderNavMap();
        }

        public void GoToCardsPage() 
        {
            Map.CardTabLink.Click();
        }
    }



    public class HeaderNavMap
    {
        public IWebElement CardTabLink => Driver.FindElement(By.CssSelector("a[href='/cards']"));
    }
}
