using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Windows.Forms;

namespace BattleShip
{
    public class Hücreler : Button
    {
        protected bool occupied;
        public Button button1;

        public Hücreler()
        {
            
            button1 = new Button();
            occupied = false;
        }
        public bool IsOccupied() { return occupied; }
        public void SetOccupied(bool occupied1) { occupied = occupied1; }
    }
    public  class Gemiler : Hücreler
    {
        public  Hücreler[][] container; 
        public  Hücreler [] newcont = new Hücreler[100]; 
        public  int carriersayısı;
        public  int battleshipsayısı;
        public  int cruisersayısı;
        public  int destroyersayısı;
        public static int[] buttons = new int[100];
        public Gemiler()
        {
            
            container = new Hücreler[10][];
            int i;
            
            for (i = 0; i < 10; i++)
            {
               
                container[i] = new Hücreler[10];
            }
            carriersayısı = 0;
            battleshipsayısı = 0;
            cruisersayısı = 0;
            destroyersayısı = 0;

        }
        

    }
}
