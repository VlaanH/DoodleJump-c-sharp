using Platformer.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ball.Classes
{
   public class Ball
    {

        Image sprite;
        public Transform transform;
        public int sizeX;
        public int sizeY;
        public bool isTouchedByPlayer;





        public Ball(PointF pos)
        {
            sprite = Platformer.Properties.Resources.Ball1;
            sizeX = 30;
            sizeY = 30;
            transform = new Transform(pos, new Size(sizeX, sizeY));
            isTouchedByPlayer = false;



        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(sprite, transform.position.X, transform.position.Y, transform.size.Width, transform.size.Height);

        }


    }
}
