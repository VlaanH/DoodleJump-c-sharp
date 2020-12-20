using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ball.Classes;
using Platformer.Classes;


namespace Platformer.Classes
{
    public static class PlatformController
    {
        public static List<Platform> platforms;
        public static int startPlatformPosY = 600;
        public static int score = 0;

        public static void AddPlatform(PointF position)
        {
            Platform platform = new Platform(position);
            platforms.Add(platform);



        }

     
        
        public async static void GenerateRandomPlatform()
        {





            for (int i = 0; i < platforms.Count; i++)
            {
                if (platforms[i].transform.position.Y >= 600)
                {
                    platforms.RemoveAt(i);


                }
            }


            Random r = new Random();



           
            int x = r.Next(55, 600);
            int y = r.Next(10, 60);
            PointF position = new PointF(x, y);
            Platform platform = new Platform(position);
            platforms.Add(platform);


          


        }

        
    }
}
