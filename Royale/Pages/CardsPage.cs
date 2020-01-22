using Framework;
using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Royale.Pages
{
    public class CardsPage : PageBase
    {
        public readonly CardPagesMap Map;

        public CardsPage()
        {
            Map = new CardPagesMap();
        }

        public CardsPage Goto()
        {
            HeaderNav.GoToCardsPage();
            return this;
        }

        public IWebElement GetCardByName(string cardName)
        {
            if (cardName.Contains(" "))
            {
                cardName = cardName.Replace(" ", "+");
            }

            //WaithHandler.WaitForBeClickable(_driver, Map.Card(cardName));

            return Map.Card(cardName);
        }
    }



    public class CardPagesMap
    {        
        public IWebElement Card(string name) => Driver.FindElement(By.CssSelector($"a[href*='{name}']"));
    }
}
