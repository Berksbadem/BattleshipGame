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
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Battleship1
{
    public partial class Start : Form
    {
        bool connection = false;
        public Start()
        {
            InitializeComponent();
        }
        public void Thread()
        {
            Thread thread;
            thread = new Thread(Connectserver);
            thread.Start();
        }
        public void Connectserver()
        {
            if (Oyuncular.Host == true)
            {
                if (Oyuncular.HostConnect() == true)
                {
                    connection = true;


                }
            }
            else
            {
                if (Oyuncular.ClientConnect() == true)
                {
                    connection = true;

                }
            }
        }
        private void StartPage_Load(object sender, EventArgs e)
        {
            Form.CheckForIllegalCrossThreadCalls = true;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (connection == true)
            {
                ShipPlacement shipPlacement = new ShipPlacement();
                this.Hide();
                shipPlacement.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Oyuncular.Host = true;
                button2.Text = "Connected";

            }
            else
            {
                Oyuncular.Host = false;
                button2.Text = "Connected";

            }
            Thread();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
