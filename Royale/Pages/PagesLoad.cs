﻿using System;

namespace Royale.Pages
{
    public class PagesLoad
    {
        [ThreadStatic]
        public static CardsPage Cards;

        [ThreadStatic]
        public static CardDetailsPage CardDetails;

        public static void Init()
        {
            Cards = new CardsPage();
            CardDetails = new CardDetailsPage();
        }
    }
}
