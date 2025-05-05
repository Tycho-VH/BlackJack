using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class Form1 : Form
    {
        private RandomCard randomCard;
        private Button btnTrekKaart;
        private Button btnReset;
        private Label lblKaart;
        private Button btnStartSpel;
        private Button btnGeefKaarten;  
        private NumericUpDown numericAantalSpelers;
        private Label label1;
        private ListBox listBoxResultaat;
        private Panel spelersPanel;
        private List<Panel> spelerPanels;

        private List<Speler> spelers = new List<Speler>();
        private RandomCard deck = new RandomCard();


        public Form1()
        {
            InitializeComponent();
            InitializeUI();
            randomCard = new RandomCard();
        }

        private void InitializeUI()
        {
           
            btnTrekKaart = new Button
            {
                Text = "Trek een kaart",
                Location = new System.Drawing.Point(50, 50),
                Size = new System.Drawing.Size(150, 40)
            };
            btnTrekKaart.Click += BtnTrekKaart_Click;

           
            btnReset = new Button
            {
                Text = "Reset stapel",
                Location = new System.Drawing.Point(220, 50),
                Size = new System.Drawing.Size(150, 40)
            };
            btnReset.Click += BtnReset_Click;

           
            lblKaart = new Label
            {
                Text = "Kaart: Nog geen kaart getrokken",
                Location = new System.Drawing.Point(50, 100),
                Size = new System.Drawing.Size(400, 30)
            };

           
            numericAantalSpelers = new NumericUpDown
            {
                Location = new System.Drawing.Point(220, 150),
                Size = new System.Drawing.Size(60, 30),
                Minimum = 1,
                Maximum = 5,
                Value = 5
            };

           
            btnStartSpel = new Button
            {
                Text = "Start Spel",
                Location = new System.Drawing.Point(300, 150),
                Size = new System.Drawing.Size(120, 30)
            };
            btnStartSpel.Click += BtnStartSpel_Click;

           
            btnGeefKaarten = new Button
            {
                Text = "Geef Kaarten",
                Location = new System.Drawing.Point(450, 150),
                Size = new System.Drawing.Size(120, 30)
            };
            btnGeefKaarten.Click += BtnGeefKaarten_Click;

          
            listBoxResultaat = new ListBox
            {
                Location = new System.Drawing.Point(50, 200),
                Size = new System.Drawing.Size(600, 200)
            };

            
            spelersPanel = new Panel
            {
                Location = new System.Drawing.Point(50, 400),
                Size = new System.Drawing.Size(700, 100),
                AutoScroll = true
            };

           
            Controls.Add(btnTrekKaart);
            Controls.Add(btnReset);
            Controls.Add(lblKaart);
            Controls.Add(numericAantalSpelers);
            Controls.Add(btnStartSpel);
            Controls.Add(btnGeefKaarten);
            Controls.Add(listBoxResultaat);
            Controls.Add(spelersPanel);
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

        private void BtnStartSpel_Click(object sender, EventArgs e)
        {
            listBoxResultaat.Items.Clear();
            spelers.Clear();
            deck.ResetDeck();

            int aantalSpelers = (int)numericAantalSpelers.Value;
            ToonSpelers(aantalSpelers);

           
            spelerPanels = new List<Panel>();
            spelersPanel.Controls.Clear();

            // Maak panel per speler aan
            for (int i = 0; i < aantalSpelers; i++)
            {
                var spelerPanel = new Panel
                {
                    Size = new System.Drawing.Size(250, 110),
                    Location = new System.Drawing.Point(50, i * 120) 
                };

                var spelerLabel = new Label
                {
                    Text = $"Speler {i + 1}",
                    Location = new System.Drawing.Point(10, 10)
                };

                spelerPanel.Controls.Add(spelerLabel);
                spelerPanels.Add(spelerPanel);
                spelersPanel.Controls.Add(spelerPanel);

                spelers.Add(new Speler { Naam = $"Speler {i + 1}" });
            }
        }

        private void BtnGeefKaarten_Click(object sender, EventArgs e)
        {
            if (spelers.Count == 0)
            {
                MessageBox.Show("Er zijn geen spelers om kaarten aan uit te delen.");
                return;
            }

            bool kaartGedeeld = false;

            foreach (var speler in spelers)
            {
                // Geef alleen een kaart als de speler minder dan 2 kaarten heeft
                if (speler.Hand.Count < 2)
                {
                    var kaart = deck.GetRandomCard();
                    speler.OntvangKaart(kaart);
                    ToonSpelerKaarten(speler);
                    kaartGedeeld = true;
                }
            }

            if (!kaartGedeeld)
            {
                MessageBox.Show("Alle spelers hebben al 2 kaarten.");
            }
        }


        private void ToonSpelerKaarten(Speler speler)
        {
            foreach (var spelerPanel in spelerPanels)
            {
                var naamLabel = spelerPanel.Controls[0] as Label;
                if (naamLabel.Text == speler.Naam)
                {
                   
                    while (spelerPanel.Controls.Count > 1)
                        spelerPanel.Controls.RemoveAt(1);

                    // Toon kaarten
                    var kaartenLabel = new Label
                    {
                        Text = "Kaarten: " + string.Join(", ", speler.Hand.ConvertAll(x => x.Item1)),
                        Location = new System.Drawing.Point(10, 30),
                        AutoSize = true
                    };
                    spelerPanel.Controls.Add(kaartenLabel);

                }
            }
                }
            }
        }
