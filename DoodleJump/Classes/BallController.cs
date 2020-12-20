using Platformer.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ball.Classes
{
   public static class BallController
    {

        public static List<Ball> ball;
        public static int startPlatformPosY = 600;
        public static int score = 0;

        public static void AddPlatform(PointF position)
        {
            Ball enem = new Ball(position);
            ball.Add(enem);
        }

     
        public static async void GenerateRandomBall()
        {
            Random r = new Random();

           
                 ClearBall();
               // ClearStopBull();
                await Task.Run(() =>
                {



                    int i2 = 0;
                    for (; i2 < BallController.ball.Count; i2++) { }


                        if (i2 > 0)
                        {
                          
                        }
                        else
                        {
                            PointF position = new PointF(StaticData.xALL + 2, StaticData.yALL - 30);
                            Ball platform2 = new Ball(position);
                            ball.Add(platform2);
                        }
                    Saund.PlaySaundBall();

                });


           
        }

        public static async void ClearStopBull()
        {


            await Task.Run(() =>
            {


                for (int i = 0; i < ball.Count; i++)
                {
                    float hes = ball[i].transform.position.Y;

                    if (ball[i].transform.position.Y == hes)
                    {
                        ball.RemoveAt(i);
                    }
                }
            });
            }
       
   



        public  static void ClearBall()
        {



            if (BallController.ball.Count > 0 && BallController.ball[0] != null)
            {
                if (ball[0].transform.position.Y < 10)
                {
                    ball.RemoveAt(0);


                }
            }
        }





    }
}
