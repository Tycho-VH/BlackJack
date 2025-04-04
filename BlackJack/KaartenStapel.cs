using System;
using System.Collections.Generic;

namespace BlackJack
{
    class KaartenStapel
    {
        private List<(string, int)> blackjackCards;

        public KaartenStapel()
        {
            InitializeBlackjackDeck();
        }

        private void InitializeBlackjackDeck()
        {
            blackjackCards = new List<(string, int)>
            {
                ("2 Harten", 2), ("3 Harten", 3), ("4 Harten", 4), ("5 Harten", 5),
                ("6 Harten", 6), ("7 Harten", 7), ("8 Harten", 8), ("9 Harten", 9),
                ("10 Harten", 10), ("Boer Harten", 10), ("Dame Harten", 10),
                ("Heer Harten", 10), ("Aas Harten", 11),

                ("2 Ruiten", 2), ("3 Ruiten", 3), ("4 Ruiten", 4), ("5 Ruiten", 5),
                ("6 Ruiten", 6), ("7 Ruiten", 7), ("8 Ruiten", 8), ("9 Ruiten", 9),
                ("10 Ruiten", 10), ("Boer Ruiten", 10), ("Dame Ruiten", 10),
                ("Heer Ruiten", 10), ("Aas Ruiten", 11),

                ("2 Schoppen", 2), ("3 Schoppen", 3), ("4 Schoppen", 4), ("5 Schoppen", 5),
                ("6 Schoppen", 6), ("7 Schoppen", 7), ("8 Schoppen", 8), ("9 Schoppen", 9),
                ("10 Schoppen", 10), ("Boer Schoppen", 10), ("Dame Schoppen", 10),
                ("Heer Schoppen", 10), ("Aas Schoppen", 11),

                ("2 Klaveren", 2), ("3 Klaveren", 3), ("4 Klaveren", 4), ("5 Klaveren", 5),
                ("6 Klaveren", 6), ("7 Klaveren", 7), ("8 Klaveren", 8), ("9 Klaveren", 9),
                ("10 Klaveren", 10), ("Boer Klaveren", 10), ("Dame Klaveren", 10),
                ("Heer Klaveren", 10), ("Aas Klaveren", 11)
            };
        }

        public List<(string, int)> GetKaarten()
        {
            return new List<(string, int)>(blackjackCards); // Kopie maken zodat de lijst intact blijft
        }
    }
}
