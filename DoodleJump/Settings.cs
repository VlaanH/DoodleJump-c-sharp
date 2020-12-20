using Platformer.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Platformer
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (StaticData.SaundOn == true)
            {
                StaticData.SaundOn = false;

            }
            else
            {
                StaticData.SaundOn = true;
            }
            lableUpdate();
        }

        void lableUpdate() 
        {

            if (StaticData.SaundOn == true)
            {
                label1.Text = "Звук Вкл";

            }
            else
            {
                label1.Text = "Звук выкл";
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            lableUpdate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            History.Dell();
            
            System.Media.SystemSounds.Asterisk.Play();
            System.Media.SystemSounds.Beep.Play();
            System.Media.SystemSounds.Exclamation.Play();
            System.Media.SystemSounds.Hand.Play();
            System.Media.SystemSounds.Question.Play();
        }
    }
}
