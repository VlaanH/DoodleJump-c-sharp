using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Classes
{
    public class Player
    {
        public Physics physics;
        public Image sprite;

        public Player()
        {
            sprite = Platformer.Properties.Resources.men;
            physics = new Physics(new PointF(100, 250), new Size(30, 30));
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(sprite, physics.transform.position.X, physics.transform.position.Y, physics.transform.size.Width, physics.transform.size.Height);
        }
    }
}
