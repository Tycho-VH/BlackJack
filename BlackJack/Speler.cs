namespace BlackJack
{
    public class Speler
    {
        public string Naam { get; set; }
        public List<(string, int)> Hand { get; set; } = new List<(string, int)>();
        public int Score { get; set; }  

       
        public void OntvangKaart((string, int) kaart)
        {
            Hand.Add(kaart);
            Score = BerekenPunten();  
        }

       
        public int BerekenPunten()
        {
            int totaal = 0;
            int azen = 0;

            foreach (var kaart in Hand)
            {
                totaal += kaart.Item2;
                if (kaart.Item1.StartsWith("Aas"))
                    azen++;
            }

           
            while (totaal > 21 && azen > 0)
            {
                totaal -= 10;
                azen--;
            }

            return totaal;
        }

       
        public List<string> HaalKaartenOp()
        {
            return Hand.ConvertAll(kaart => kaart.Item1);
        }
    }
}
