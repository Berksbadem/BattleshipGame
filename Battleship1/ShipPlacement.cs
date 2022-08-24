using BattleShip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship1
{
    public partial class ShipPlacement : Form
    {
        public Gemiler YerleştirilenGemiler;
        public static Çalıştırma OyunBoard1;

        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.ShipsReady = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(588, 143);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(588, 180);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(180, 21);
            this.comboBox2.TabIndex = 1;
            // 
            // ShipsReady
            // 
            this.ShipsReady.Location = new System.Drawing.Point(618, 338);
            this.ShipsReady.Name = "ShipsReady";
            this.ShipsReady.Size = new System.Drawing.Size(150, 69);
            this.ShipsReady.TabIndex = 2;
            this.ShipsReady.Text = "Ready";
            this.ShipsReady.UseVisualStyleBackColor = true;
            this.ShipsReady.Click += new System.EventHandler(this.ShipsReady_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(588, 24);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(195, 96);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "1x Carrier\n1x Battleship\n1x Cruiser\n2x Destroyer\nPlace total 5 ship\n";
            // 
            // ShipPlacement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(799, 436);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.ShipsReady);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Name = "ShipPlacement";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.ShipPlacement_Load);
            this.ResumeLayout(false);

        }
        
        public ShipPlacement()
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(OccupationType));
            comboBox2.DataSource = Enum.GetValues(typeof(Axis));
        }

        private void ShipPlacement_Load(object sender, EventArgs e)
        {
            int i, j;
            YerleştirilenGemiler = new Gemiler();
            ShipsReady.Enabled = false;
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                {
                    Hücreler hücre = new Hücreler();
                    Button button = new Button();
                    if (i == 0)
                    {
                        button.Name = j.ToString();
                    }
                    if (i != 0)
                    {
                        button.Name = i.ToString() + j.ToString();
                    }
                    button.BackColor = Color.White;
                    button.Size = new Size(50, 50);
                    button.Visible = true;
                    button.Location = new Point(60 + (50 * j), 60 + (50 * i));
                    hücre.button1 = button;
                    hücre.SetOccupied(false);
                    YerleştirilenGemiler.container[i][j] = hücre;
                    YerleştirilenGemiler.container[i][j].button1.Click += new EventHandler(Button_Click);
                    Controls.Add(YerleştirilenGemiler.container[i][j].button1);
                }
            }

        }
        
        private bool Yerleştirme_Hatası(int num2,int num3)
        {
            int count2, count3, i;
            count2= num2;
            count3= num3;
            YerleştirmeHatası yerleştirmeHatası = new YerleştirmeHatası();
            if (comboBox2.SelectedItem.ToString() == "Vertical")
            {
                if (comboBox1.SelectedItem.ToString() == "Carrier")
                {
                    for (i = 0; i < 5; i++)
                    {
                        if (YerleştirilenGemiler.container[count3++][count2].IsOccupied() == true)
                        {
                            yerleştirmeHatası.Show();   
                            return true;
                        }
                        if (count3 > 5)
                        {
                            count3 = 0;
                        }
                    }
                }
                if (comboBox1.SelectedItem.ToString() == "Battleship")
                {
                    for (i = 0; i < 4; i++)
                    {
                        if (YerleştirilenGemiler.container[count3++][count2].IsOccupied() == true)
                        {
                            yerleştirmeHatası.Show();
                            return true;
                        }
                        if (count3 > 6)
                        {
                            count3 = 0;
                        }
                    }
                }
                if (comboBox1.SelectedItem.ToString() == "Cruiser")
                {
                    for (i = 0; i < 3; i++)
                    {
                        if (YerleştirilenGemiler.container[count3++][count2].IsOccupied() == true)
                        {
                            yerleştirmeHatası.Show();
                            return true;
                        }
                        if (count3 > 7)
                        {
                            count3 = 0;
                        }
                    }
                }
                if (comboBox1.SelectedItem.ToString() == "Destroyer")
                {
                    for (i = 0; i < 2; i++)
                    {
                        if (YerleştirilenGemiler.container[count3++][count2].IsOccupied() == true)
                        {
                            yerleştirmeHatası.Show();
                            return true;
                        }
                        if (count3 > 8)
                        {
                            count3 = 0;
                        }
                    }
                }
            }

            if (comboBox2.SelectedItem.ToString() == "Horizontal")
            {
                if (comboBox1.SelectedItem.ToString() == "Carrier")
                {
                    for (i = 0; i < 5; i++)
                    {
                        if (YerleştirilenGemiler.container[count3][count2++].IsOccupied() == true)
                        {
                            yerleştirmeHatası.Show();
                            return true;

                        }
                        if (count2 > 5)
                        {
                            count2 = 0;
                        }
                    }
                }
                if (comboBox1.SelectedItem.ToString() == "Battleship")
                {
                    for (i = 0; i < 4; i++)
                    {
                        if (YerleştirilenGemiler.container[count3][count2++].IsOccupied() == true)
                        {
                            yerleştirmeHatası.Show();
                            return true;

                        }
                        if (count2 > 6)
                        {
                            count2 = 0;
                        }
                    }
                }
                if (comboBox1.SelectedItem.ToString() == "Cruiser")
                {
                    for (i = 0; i < 3; i++)
                    {
                        if (YerleştirilenGemiler.container[count3][count2++].IsOccupied() == true)
                        {
                            yerleştirmeHatası.Show();
                            return true;
                        }
                        if (count2 > 7)
                        {
                            count2 = 0;
                        }
                    }
                }
                if (comboBox1.SelectedItem.ToString() == "Destroyer")
                {
                    for (i = 0; i < 2; i++)
                    {
                        if (YerleştirilenGemiler.container[count3][count2++].IsOccupied() == true)
                        {
                            yerleştirmeHatası.Show();
                            return true;
                        }
                        if (count2 > 8)
                        {
                            count2 = 0;
                        }
                    }
                }
            }
            return false;
        }
        private void Add_CarrierVertical(int num2, int num3)
        {
            int i;
            if (num3 <= 5)
            {
                for (i = 0; i < 5; i++)
                {
                    YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                    YerleştirilenGemiler.container[num3++][num2].button1.BackColor = Color.Green;


                }

            }
            else if (num3 > 5)
            {
                for (i = 0; i < 5; i++)
                {
                    if (num3 <= 9)
                    {
                        YerleştirilenGemiler.container[num3][num2].SetOccupied(true);

                        YerleştirilenGemiler.container[num3++][num2].button1.BackColor = Color.Green;

                    }
                    else
                    {
                        num3 = 0;
                        YerleştirilenGemiler.container[num3][num2].SetOccupied(true);

                        YerleştirilenGemiler.container[num3++][num2].button1.BackColor = Color.Green;

                    }
                }
            }
        }


        private void Add_CarrierHorizontal(int num2, int num3)
        {
            int i;
            if (num2 <= 5)
            {
                for (i = 0; i < 5; i++)
                {
                    YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                    YerleştirilenGemiler.container[num3][num2++].button1.BackColor = Color.Green;
                }
            }
            else if (num2 > 5)
            {
                for (i = 0; i < 5; i++)
                {
                    if (num2 <= 9)
                    {
                        YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                        YerleştirilenGemiler.container[num3][num2++].button1.BackColor = Color.Green;
                    }
                    else
                    {
                        num2 = 0;
                        YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                        YerleştirilenGemiler.container[num3][num2++].button1.BackColor = Color.Green;
                    }
                }
            }
        }

        private void Add_BattleshipVertical(int num2, int num3)
        {
            int i;
            if (num3 <= 6)
            {
                for (i = 0; i < 4; i++)
                {
                    YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                    YerleştirilenGemiler.container[num3++][num2].button1.BackColor = Color.Green;
                }

            }
            else if (num3 > 6)
            {
                for (i = 0; i < 4; i++)
                {
                    if (num3 <= 9)
                    {
                        YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                        YerleştirilenGemiler.container[num3++][num2].button1.BackColor = Color.Green;
                    }
                    else
                    {
                        num3 = 0;
                        YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                        YerleştirilenGemiler.container[num3++][num2].button1.BackColor = Color.Green;
                    }
                }
            }
        }
        private void Add_BattleshipHorizontal(int num2, int num3)
        {
            int i;
            if (num2 <= 6)
            {
                for (i = 0; i < 4; i++)
                {
                    YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                    YerleştirilenGemiler.container[num3][num2++].button1.BackColor = Color.Green;
                }
            }
            else if (num2 > 6)
            {
                for (i = 0; i < 4; i++)
                {
                    if (num2 <= 9)
                    {
                        YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                        YerleştirilenGemiler.container[num3][num2++].button1.BackColor = Color.Green;
                    }
                    else
                    {
                        num2 = 0;
                        YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                        YerleştirilenGemiler.container[num3][num2++].button1.BackColor = Color.Green;
                    }
                }
            }
        }
        private void Add_CruiserHorizontal(int num2, int num3)
        {
            int i;
            if (num2 <= 7)
            {
                for (i = 0; i < 3; i++)
                {
                    YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                    YerleştirilenGemiler.container[num3][num2++].button1.BackColor = Color.Green;
                }
            }
            else if (num2 > 7)
            {
                for (i = 0; i < 3; i++)
                {
                    if (num2 <= 9)
                    {
                        YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                        YerleştirilenGemiler.container[num3][num2++].button1.BackColor = Color.Green;
                    }
                    else
                    {
                        num2 = 0;
                        YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                        YerleştirilenGemiler.container[num3][num2++].button1.BackColor = Color.Green;
                    }
                }
            }

        }

        private void Add_CruiserVertical(int num2, int num3)
        {
            int i;
            if (num3 <= 7)
            {
                for (i = 0; i < 3; i++)
                {
                    YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                    YerleştirilenGemiler.container[num3++][num2].button1.BackColor = Color.Green;
                }

            }
            else if (num3 > 7)
            {
                for (i = 0; i < 3; i++)
                {
                    if (num3 <= 9)
                    {
                        YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                        YerleştirilenGemiler.container[num3++][num2].button1.BackColor = Color.Green;
                    }
                    else
                    {
                        num3 = 0;
                        YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                        YerleştirilenGemiler.container[num3++][num2].button1.BackColor = Color.Green;
                    }
                }
            }
        }

        private void Add_DestroyerHorizontal(int num2, int num3)
        {
            int i;
            if (num2 <= 8)
            {
                for (i = 0; i < 2; i++)
                {
                    YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                    YerleştirilenGemiler.container[num3][num2++].button1.BackColor = Color.Green;
                }
            }
            else if (num2 > 8)
            {
                for (i = 0; i < 2; i++)
                {
                    if (num2 <= 9)
                    {
                        YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                        YerleştirilenGemiler.container[num3][num2++].button1.BackColor = Color.Green;
                    }
                    else
                    {
                        num2 = 0;
                        YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                        YerleştirilenGemiler.container[num3][num2++].button1.BackColor = Color.Green;
                    }
                }
            }

        }

        private void Add_DestroyerVertical(int num2, int num3)
        {
            int i;
            if (num3 <= 8)
            {
                for (i = 0; i < 2; i++)
                {
                    YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                    YerleştirilenGemiler.container[num3++][num2].button1.BackColor = Color.Green;
                }

            }
            else if (num3 > 8)
            {
                for (i = 0; i < 2; i++)
                {
                    if (num3 <= 9)
                    {
                        YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                        YerleştirilenGemiler.container[num3++][num2].button1.BackColor = Color.Green;
                    }
                    else
                    {
                        num3 = 0;
                        YerleştirilenGemiler.container[num3][num2].SetOccupied(true);
                        YerleştirilenGemiler.container[num3++][num2].button1.BackColor = Color.Green;
                    }
                }
            }
        }


        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            int num1 = Convert.ToInt32(button.Name);
            int num2 = num1 % 10;
            int num3 = num1 / 10;
            if (comboBox2.SelectedItem.ToString() == "Vertical")
            {
                if (YerleştirilenGemiler.carriersayısı < 1)
                {
                    if (comboBox1.SelectedItem.ToString() == "Carrier")
                    {
                        if ( Yerleştirme_Hatası(num2, num3) == false)
                        {
                            Add_CarrierVertical(num2, num3);
                            YerleştirilenGemiler.carriersayısı++;
                        }
                    }

                }

                if (YerleştirilenGemiler.battleshipsayısı < 1)
                {
                    if (comboBox1.SelectedItem.ToString() == "Battleship")
                    {

                        if (Yerleştirme_Hatası(num2, num3) == false)
                        {
                            Add_BattleshipVertical(num2, num3);
                            YerleştirilenGemiler.battleshipsayısı++;
                        }

                    }

                }
                if (YerleştirilenGemiler.cruisersayısı < 1)
                {
                    if (comboBox1.SelectedItem.ToString() == "Cruiser")
                    {
                        if (Yerleştirme_Hatası(num2, num3) == false)
                        {
                            Add_CruiserVertical(num2, num3);
                            YerleştirilenGemiler.cruisersayısı++;
                        }
                    }

                }
                if (YerleştirilenGemiler.destroyersayısı < 1)
                {
                    if (comboBox1.SelectedItem.ToString() == "Destroyer")
                    {
                        if (Yerleştirme_Hatası(num2, num3) == false)
                        {
                            Add_DestroyerVertical(num2, num3);
                            YerleştirilenGemiler.destroyersayısı++;
                        }
                    }

                }
            }
            if (comboBox2.SelectedItem.ToString() == "Horizontal")
            {
                if (YerleştirilenGemiler.carriersayısı < 1)
                {
                    if (comboBox1.SelectedItem.ToString() == "Carrier")
                    {
                        if (Yerleştirme_Hatası(num2, num3) == false)
                        {
                            Add_CarrierHorizontal(num2, num3);
                            YerleştirilenGemiler.carriersayısı++;
                        }
                    }
                }
                if (YerleştirilenGemiler.battleshipsayısı < 1)
                {
                    if (comboBox1.SelectedItem.ToString() == "Battleship")
                    {
                        if (Yerleştirme_Hatası(num2, num3) == false)
                        {
                            Add_BattleshipHorizontal(num2, num3);
                            YerleştirilenGemiler.battleshipsayısı++;
                        }
                    }

                }
                if (YerleştirilenGemiler.cruisersayısı < 1)
                {
                    if (comboBox1.SelectedItem.ToString() == "Cruiser")
                    {
                        if (Yerleştirme_Hatası(num2, num3) == false)
                        {
                            Add_CruiserHorizontal(num2, num3);
                            YerleştirilenGemiler.cruisersayısı++;
                        }
                    }
                }
                if (YerleştirilenGemiler.destroyersayısı <2)
                {
                    if (comboBox1.SelectedItem.ToString() == "Destroyer")
                    {
                        if (Yerleştirme_Hatası(num2, num3) == false)
                        {
                            Add_CruiserHorizontal(num2, num3);
                            YerleştirilenGemiler.destroyersayısı++;
                        }
                    }
                }
            }

            if (YerleştirilenGemiler.carriersayısı + YerleştirilenGemiler.battleshipsayısı + YerleştirilenGemiler.cruisersayısı + YerleştirilenGemiler.destroyersayısı == 5)
            {
                ShipsReady.Enabled = true;
            }
        }



        private void ShipPlacement_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public enum Axis
        {
            [Description("Empty")]
            ChooseAxis,
            [Description("Horizontal")]
            Horizontal,
            [Description("Vertical")]
            Vertical
        }

        public enum OccupationType
        {
            [Description("Empty1")]
            ChooseShip,

            [Description("5Cell 1xCarrier")]
            Carrier,

            [Description("4Cell 1xBattleship")]
            Battleship,

            [Description("3Cell 1xCruiser")]
            Cruiser,

            [Description("2Cell 2xDestroyer")]
            Destroyer


        }

        private void ShipsReady_Click(object sender, EventArgs e)
        {
            this.Hide();
            Çalıştırma.HostShips = new Gemiler();
            Çalıştırma.HostShips = YerleştirilenGemiler;
            int i, j, count1 = 0;
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                {
                    Çalıştırma.HostShips.newcont[count1] = Çalıştırma.HostShips.container[i][j];
                    count1++;
                }
            }
            OyunBoard1 = new Çalıştırma();
            OyunBoard1.Show();

        }

    }
}


         













