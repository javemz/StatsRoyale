using Framework.Models;
using Framework.Selenium;
using Framework.Services;
using NUnit.Framework;
using Royale.Pages;
using System.Collections.Generic;

namespace Royale.Test
{
    public class CardTests
    {
        [SetUp]
        public void BeforeEach()
        {
            Driver.Init();
            PagesLoad.Init();
            Driver.Goto("https://statsroyale.com/");
        }

        [TearDown]
        public void AfterEach()
        {
            Driver.Current.Quit();
        }

        static IList<Card> apiCards = new ApiCardService().GetAllCards();

        [Test]
        [TestCaseSource("apiCards")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_is_on_Cards_Page(Card card)
        {
            var cardOnPage = PagesLoad.Cards.Goto().GetCardByName(card.Name);
            Assert.That(cardOnPage.Displayed);
        }

        [Test, Category("cards")]
        [TestCaseSource("apiCards")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_headers_are_correct_on_Card_Details_Page(Card card)
        {
            PagesLoad.Cards.Goto().GetCardByName(card.Name).Click();

            var cardOnPage = PagesLoad.CardDetails.GetBaseCard();

            Assert.AreEqual(card.Name, cardOnPage.Name);
            Assert.AreEqual(card.Type, cardOnPage.Type);
            Assert.AreEqual(card.Arena, cardOnPage.Arena);
            Assert.AreEqual(card.Rarity, cardOnPage.Rarity);
        }
    }

}