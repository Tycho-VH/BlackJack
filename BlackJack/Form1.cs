using System;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class Form1 : Form
    {
        private RandomCard randomCard;
        private Button btnTrekKaart;
        private Button btnReset;
        private Label lblKaart;

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
            randomCard = new RandomCard();
        }

        private void InitializeUI()
        {
            // Knop om een kaart te trekken
            btnTrekKaart = new Button
            {
                Text = "Trek een kaart",
                Location = new System.Drawing.Point(50, 50),
                Size = new System.Drawing.Size(150, 40)
            };
            btnTrekKaart.Click += BtnTrekKaart_Click;

            // Knop om de stapel te resetten
            btnReset = new Button
            {
                Text = "Reset stapel",
                Location = new System.Drawing.Point(100, 100),
                Size = new System.Drawing.Size(150, 40)
            };
            btnReset.Click += BtnReset_Click;

            // Label om de getrokken kaart te laten zien
            lblKaart = new Label
            {
                Text = "Kaart: Nog geen kaart getrokken",
                Location = new System.Drawing.Point(50, 150),
                Size = new System.Drawing.Size(300, 40)
            };

            // Controls toevoegen aan de Form
            Controls.Add(btnTrekKaart);
            Controls.Add(btnReset);
            Controls.Add(lblKaart);
        }

        private void BtnTrekKaart_Click(object sender, EventArgs e)
        {
            try
            {
                var kaart = randomCard.GetRandomCard();
                lblKaart.Text = $"Kaart: {kaart.Item1} ({kaart.Item2} punten)";
            }
            catch (InvalidOperationException)
            {
                lblKaart.Text = "Kaarten zijn op! Reset de stapel.";
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            randomCard.ResetDeck();
            lblKaart.Text = "Stapel gereset! Trek een kaart.";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
