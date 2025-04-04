using System;
using System.Collections.Generic;

namespace BlackJack
{
    class RandomCard
    {
        private static Random random = new Random();
        private List<(string, int)> kaarten;

        public RandomCard()
        {
            ResetDeck(); 
        }

        public (string, int) GetRandomCard()
        {
            if (kaarten.Count == 0)
            {
                throw new InvalidOperationException("De kaartenstapel is leeg!");
            }

            int index = random.Next(kaarten.Count);
            var kaart = kaarten[index];
            kaarten.RemoveAt(index); // Verwijder de kaart zodat deze niet opnieuw getrokken wordt
            return kaart;
        }

        public void ResetDeck()
        {
            KaartenStapel stapel = new KaartenStapel();
            kaarten = stapel.GetKaarten();
        }
    }
}
