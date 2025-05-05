namespace BlackJack
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;



        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnStartSpel = new Button();
            listBoxResultaat = new ListBox();
            numericAantalSpelers = new NumericUpDown();
            label1 = new Label();
            btnGeefKaarten = new Button();
            spelersPanel = new Panel();
            spelerPanels = new List<Panel>();

            ((System.ComponentModel.ISupportInitialize)(numericAantalSpelers)).BeginInit();
            SuspendLayout();

           
            btnStartSpel.Location = new Point(360, 450);
            btnStartSpel.Name = "btnStartSpel";
            btnStartSpel.Size = new Size(120, 35);
            btnStartSpel.TabIndex = 0;
            btnStartSpel.Text = "Start Spel";
            btnStartSpel.UseVisualStyleBackColor = true;
            btnStartSpel.Click += BtnStartSpel_Click;

           
            listBoxResultaat.FormattingEnabled = true;
            listBoxResultaat.ItemHeight = 20;
            listBoxResultaat.Location = new Point(50, 30);
            listBoxResultaat.Name = "listBoxResultaat";
            listBoxResultaat.Size = new Size(700, 304);
            listBoxResultaat.TabIndex = 1;

           
            numericAantalSpelers.Location = new Point(180, 410);
            numericAantalSpelers.Minimum = 1;
            numericAantalSpelers.Maximum = 5;
            numericAantalSpelers.Value = 0;
            numericAantalSpelers.Name = "numericAantalSpelers";
            numericAantalSpelers.Size = new Size(30, 20);
            numericAantalSpelers.TabIndex = 2;

           
            label1.AutoSize = true;
            label1.Location = new Point(50, 412);
            label1.Name = "label1";
            label1.Size = new Size(124, 20);
            label1.TabIndex = 3;
            label1.Text = "Aantal spelers (1-5):";

    
            btnGeefKaarten.Location = new Point(490, 450);
            btnGeefKaarten.Name = "btnGeefKaarten";
            btnGeefKaarten.Size = new Size(140, 35);
            btnGeefKaarten.TabIndex = 4;
            btnGeefKaarten.Text = "Geef Volgende Kaart";
            btnGeefKaarten.UseVisualStyleBackColor = true;
            btnGeefKaarten.Click += BtnGeefKaarten_Click;

     
            spelersPanel.Location = new Point(50, 70);
            spelersPanel.Size = new Size(700, 300);
            spelersPanel.AutoScroll = true;

           
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(824, 522);
            Controls.Add(spelersPanel);
            Controls.Add(btnGeefKaarten);
            Controls.Add(label1);
            Controls.Add(numericAantalSpelers);
            Controls.Add(listBoxResultaat);
            Controls.Add(btnStartSpel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "BlackJack";
            ((System.ComponentModel.ISupportInitialize)(numericAantalSpelers)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
            public void ToonSpelers(int aantalSpelers)
        {
            spelerPanels.Clear();
            spelersPanel.Controls.Clear(); 

            for (int i = 0; i < aantalSpelers; i++)
            {
               
                var spelerPanel = new Panel
                {
                    Location = new Point(0, i * 110),
                    Size = new Size(650, 100),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.FromArgb(30, 30, 30)
                };

                var spelerLabel = new Label
                {
                    Text = $"Speler {i + 1}",
                    Location = new Point(10, 10),
                    Size = new Size(100, 25),
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(30, 30, 30)
                };

                var spelerListBox = new ListBox
                {
                    Location = new Point(10, 40),
                    Size = new Size(600, 50),
                    Name = $"listBoxSpeler{i}",
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.FromArgb(45, 45, 45),
                    ForeColor = Color.White
                };

                spelerPanel.Controls.Add(spelerLabel);
                spelerPanel.Controls.Add(spelerListBox);
                spelersPanel.Controls.Add(spelerPanel);
                spelerPanels.Add(spelerPanel);
            }
        }

    }
}

      
        