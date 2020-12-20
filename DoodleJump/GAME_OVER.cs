using Platformer.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Platformer
{
    public partial class GAME_OVER : Form
    {
        Thread trd;
        public GAME_OVER()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            StaticData.InitStart = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StaticData.KILLgame = true;
            this.Close();
            trd = new Thread(open);
            trd.SetApartmentState(ApartmentState.STA);
            trd.Start();
        }

        void open(object obj)
        {
            Application.Run(new Menu());

        }

        private void GAME_OVER_Load(object sender, EventArgs e)
        {
            label2.Text = StaticData.NamePlayer + " Счёт: "+PlatformController.score.ToString();
        }
    }
}
