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
    public partial class Menu : Form
    {

        Thread trd;
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                StaticData.NamePlayer = textBox1.Text;

                this.Close();
                trd = new Thread(open);
                trd.SetApartmentState(ApartmentState.STA);
                trd.Start();
            }
            else
            {
                var result = MessageBox.Show("Введите имя игрока"

                        , "Игрок", MessageBoxButtons.OK);
                
            }
            
        }

        void open(object obj)
        {
            Application.Run(new Game());
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Игра платформер \n"
                + "Игроку, управляя главным героем, необходимо пропрыгать как можно выше и получить наибольшее кол-во очков. \n" +
                "Необходимо избегать противников и падения в пропась.\n" +
                "Управление:\n Перемещение - влево\"A\" вправо\"D\"\n Атака\"F\"\n Пауза\"Esc\" "

                , "Справка по игре платформер", MessageBoxButtons.OK);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form = new Settings();
            form.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var his = History.Read();
            if (his!="")
            {
          var result = MessageBox.Show(his

                       , "Рейтинг играков", MessageBoxButtons.OK);
            }
            else
            {
                var result = MessageBox.Show("Пусто"

                      , "Рейтинг играков", MessageBoxButtons.OK);
            }
        }
    }
}
