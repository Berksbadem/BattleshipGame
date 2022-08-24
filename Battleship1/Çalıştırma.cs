using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using BattleShip;

namespace Battleship1
{
    public partial class Çalıştırma : Form
    {
        public static Gemiler HostShips;
        public static Gemiler OpponentShips;
        public Çalıştırma()
        {
            InitializeComponent();
        }
        bool turn;
        int currentbutton;
        int count = 0;
        int location = 0;
        int hostbuttonleft = 50;
        int clientbuttonleft = 50;

        private void Çalıştırma_Load(object sender, EventArgs e)
        {
            int i, j;
            if (Oyuncular.Host == true)
            {
                turn = true;
            }
            else
            {
                turn = false;
            }
            Threads();
            OpponentShips = new Gemiler();
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                {

                    Hücreler hücre1 = new Hücreler();
                    Button button = new Button();
                    button.Name = count.ToString();
                    button.BackColor = Color.White;
                    button.Size = new Size(50, 50);
                    button.Visible = true;
                    button.BackColor = Color.White;
                    button.Location = new Point(60 + (50 * j), 60 + (50 * i));
                    hücre1.button1 = button;
                    hücre1.SetOccupied(false);
                    OpponentShips.newcont[location] = hücre1;
                    OpponentShips.newcont[location].button1.Click += new EventHandler(Button_Click);
                    Controls.Add(OpponentShips.newcont[location].button1);
                    count++;
                    location++;

                }
            }
            location = 0;
            count = 0;
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                {
                    HostShips.newcont[location].button1.Name = count.ToString();
                    HostShips.newcont[location].button1.Location = new Point(630 + (50 * j), 60 + (50 * i));
                    Controls.Add(HostShips.newcont[location].button1);
                    count++;
                    location++;
                }
            }
        }
        public void Threads()
        {
            Thread thread;
            if (Oyuncular.Host == true)
            {
                thread = new Thread(new ThreadStart(HostTurn));


            }
            else
            {
                thread = new Thread(new ThreadStart(ClientTurn));
            }
            thread.Start();
        }
        private void Button_Click(object sender, EventArgs e)
        {
            if (!turn)
            {
                return;
            }
            Button button = sender as Button;
            if (Oyuncular.Host)
            {
                if (hostbuttonleft == 0 && clientbuttonleft != 0)
                {
                    Youwin youwin = new Youwin();
                    youwin.Show();
                    this.Hide();

                }
                else if (clientbuttonleft == 0)
                {
                    YouLose youLose = new YouLose();
                    youLose.Show();
                    this.Hide();

                }
            }
            if (!Oyuncular.Host)
            {
                if (clientbuttonleft == 0 && hostbuttonleft != 0)
                {
                    Youwin youwin = new Youwin();
                    youwin.Show();
                    this.Hide();

                }
                else if (hostbuttonleft == 0)
                {
                    YouLose youLose = new YouLose();
                    youLose.Show();
                    this.Hide();

                }
            }
            if (button.BackColor == Color.GreenYellow || button.BackColor == Color.Red)
            {
                Aynıyereatış_Hatası aynıyereatışHatası = new Aynıyereatış_Hatası() ;
                aynıyereatışHatası.Show();
                return;
            }
            currentbutton = Convert.ToInt32(button.Name);
            if (Oyuncular.Host)
            {
                Oyuncular.HostSendButton(button.Name);

            }
            else
            {

                Oyuncular.ClientSendButton(button.Name);

            }

            turn = false;
        }
            private void HostTurn()
            {
                while (true)
                {
                  string takenbuttonN = Oyuncular.HostReceiveButton();

                  if (takenbuttonN == "ButtonRed")
                  {
                    OpponentShips.newcont[currentbutton].button1.BackColor = Color.Red;
                    hostbuttonleft--;

                  }
                  else if (takenbuttonN == "ButtonGreenYellow")
                  {
                    OpponentShips.newcont[currentbutton].button1.BackColor = Color.GreenYellow;
                  }

                  else
                  {
                    if (HostShips.newcont[Convert.ToInt32(takenbuttonN)].IsOccupied())
                    {
                        Oyuncular.HostSendButton("ButtonRed");

                        clientbuttonleft--;


                    }
                    else if (HostShips.newcont[Convert.ToInt32(takenbuttonN)].IsOccupied())
                    {
                        Oyuncular.HostSendButton("ButtonGreenYellow");


                    }
                    HostShips.newcont[Convert.ToInt32(takenbuttonN)].button1.BackColor = Color.Black;
                    turn = true;
                  }
                }
            }
            private void ClientTurn()
            {
                while (true)
                {
                  string takenbuttonN = Oyuncular.ClientReceiveButton();

                  if (takenbuttonN == "ButtonRed")
                  {
                    OpponentShips.newcont[currentbutton].button1.BackColor = Color.Red;
                    clientbuttonleft--;


                  }
                  else if (takenbuttonN == "ButtonGreenYellow")
                  {
                    OpponentShips.newcont[currentbutton].button1.BackColor = Color.GreenYellow;
                  }


                  else
                  {
                    if (HostShips.newcont[Convert.ToInt32(takenbuttonN)].IsOccupied())
                    {
                        Oyuncular.ClientSendButton("ButtonRed");

                        hostbuttonleft--;

                    }
                    else if (!HostShips.newcont[Convert.ToInt32(takenbuttonN)].IsOccupied())
                    {
                        Oyuncular.ClientSendButton("ButtonGreenYellow");


                    }
                    HostShips.newcont[Convert.ToInt32(takenbuttonN)].button1.BackColor = Color.Black;
                    turn = true;
                  }

                }
            }
    }
}
