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

namespace Platformer.Classes
{
    public partial class Paus : Form
    {
        Thread trd;
        public Paus()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StaticData.KILLgame = true;
            this.Close();
            trd = new Thread(open);
            trd.SetApartmentState(ApartmentState.STA);
            trd.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Proceed.Start(StaticData.SaveGravity, StaticData.SaveA);
            StaticData.EnemyPaus = false;
        }


        void open(object obj)
        {
            Application.Run(new Menu());

        }


    }
}
