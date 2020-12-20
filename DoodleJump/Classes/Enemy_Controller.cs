using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Platformer.Classes;


namespace Enemy.Classes
{
    public static class EnemyController
    {
        public static List<Enemy> enemy;
        public static int startEnemyPosY = 600;
        public static int score = 0;

        public static async void AddEnemy(PointF position)
        {
            
                Enemy enem = new Enemy(position);
                 enemy.Add(enem);

           

        }


       static Random r = new Random();
        public static async void GenerateRandomEnemy()
        {


            ClearEnemys();



            if (EnemyController.enemy.Count > 0 && EnemyController.enemy[0] != null)
            {

            }
            else
            {
                int x = r.Next(0, 600);
                int y = r.Next(10, 160);
                startEnemyPosY -= y;
                PointF position = new PointF(x, y-170);
                Enemy enemy_ = new Enemy(position);
                enemy.Add(enemy_);
            }
           



        }

        public static async void ClearEnemys()
        {
            

                for (int i = 0; i < enemy.Count; i++)
                {
                    if (enemy[i].transform.position.Y >= 600| enemy[i].transform.position.Y <= -500)
                    {
                   
                     enemy.RemoveAt(i);
                  

                    }
                }


            
        }
    }
}
