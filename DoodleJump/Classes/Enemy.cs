using Platformer.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enemy.Classes
{
    public class Enemy
    {
        Image sprite;
        public Transform transform;
        public int sizeX;
        public int sizeY;
        public bool isTouchedByPlayer;





        public Enemy(PointF pos)
        {
            sprite = Platformer.Properties.Resources.Enemy;
            sizeX = 45;
            sizeY = 45;
            transform = new Transform(pos, new Size(sizeX, sizeY));
            isTouchedByPlayer = false;



        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(sprite, transform.position.X, transform.position.Y, transform.size.Width, transform.size.Height);

        }

    }
}
