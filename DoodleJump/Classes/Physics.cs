
using Ball.Classes;
using Enemy.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Platformer.Classes
{
    public class Physics
    {
        public Transform transform;
        public static float gravity;
      public static float a;

        public float dx;

        public Physics(PointF position, Size size)
        {
            transform = new Transform(position, size);
            gravity = 0;
            a = 0.4f;
            dx = 0;
        }

        public async void ApplyPhysics()
        {
            await Task.Run(() =>
            {
                CalculatePhysics();

            });
        }

        public async void CalculatePhysics()
        {
            if (dx != 0)
            {
                transform.position.X += dx;
                // StaticData.xALL = transform.position.X;
            }
            if (transform.position.Y < 700)
            {
                transform.position.Y += gravity;
                gravity += a;
                await Task.Run(() =>
                {
                    CollidePlatforms();
                });

                //  StaticData.yALL = transform.position.Y;
                await Task.Run(() =>
                {
                    CollideEnemy();
                });

                await Task.Run(() =>
                {
                  
                Collide_BallAtackEnemy();
                });

              
        }
        }

        public async void CollidePlatforms()
        {
            await Task.Run(async () =>
            {
                for (int i = 0; i < PlatformController.platforms.Count; i++)
                {
                    var platform = PlatformController.platforms[i];

                    StaticData.xALL = transform.position.X;
                    StaticData.yALL = transform.position.Y;
                    BallController.ClearBall();


                    if (PlatformController.platforms.Count > 0 && PlatformController.platforms[0] != null)
                        if (transform.position.X + transform.size.Width / 2 >= platform.transform.position.X && transform.position.X + transform.size.Width / 2 <= platform.transform.position.X + platform.transform.size.Width)
                        {

                        if (transform.position.Y + transform.size.Height >= platform.transform.position.Y && transform.position.Y + transform.size.Height <= platform.transform.position.Y + platform.transform.size.Height)
                        {
                            if (gravity > 0)
                            {

                                AddForce();
                                if (!platform.isTouchedByPlayer)
                                {
                                    
                                    EnemyController.GenerateRandomEnemy();

                                        if (PlatformController.platforms.Count > 0 && PlatformController.platforms[0] != null)
                                        {
                                            PlatformController.platforms.RemoveAt(i); 
                                        
                                        } 
                   


                                    PlatformController.score += 10;
                                    PlatformController.GenerateRandomPlatform();
                                    platform.isTouchedByPlayer = true;



                                }
                            }
                        }
                    }
                }
            });

        }


        public async void Collide_BallAtackEnemy()
        {


            for (int i = 0; i < EnemyController.enemy.Count; i++)
            {
                var enemy_ = EnemyController.enemy[i];



                if (BallController.ball.Count > 0 && BallController.ball[0] != null)
                {
                    var ball = BallController.ball[0];

                    if (transform.position.X + ball.transform.size.Width / 2 >= enemy_.transform.position.X && ball.transform.position.X + ball.transform.size.Width / 2 <= enemy_.transform.position.X + enemy_.transform.size.Width)
                    {
                        if (ball.transform.position.Y + ball.transform.size.Height >= enemy_.transform.position.Y && ball.transform.position.Y + ball.transform.size.Height <= enemy_.transform.position.Y + enemy_.transform.size.Height)
                        {
                            EnemyController.enemy.RemoveAt(i);
                            Saund.PlaySaundEnemyDead();


                            PlatformController.score += 250;
                        }
                    }
                }


            }


        }


       
        public async void CollideEnemy()
        {

           
            for (int i = 0; i < EnemyController.enemy.Count; i++)
            {
                var enemy_ = EnemyController.enemy[i];
               



                if (EnemyController.enemy.Count > i && EnemyController.enemy[i] != null)
                {

                    int x = 0;

                    await Task.Run(() =>
                    {
                        Random r = new Random();
                        x = r.Next(0, 80);
                    });


                    if (x > 20)
                        if (EnemyController.enemy.Count > 0 && EnemyController.enemy[0] != null)
                            if (EnemyController.enemy[0].transform.position.X < 500 & StaticData.EnemyPaus == false)
                                EnemyController.enemy[0].transform.position.X += 10 + x;





                    if (x > 30)
                        if (EnemyController.enemy.Count > StaticData.EnemyI && EnemyController.enemy[StaticData.EnemyI] != null)
                            if (EnemyController.enemy[0].transform.position.X > 100 & StaticData.EnemyPaus == false)
                                EnemyController.enemy[0].transform.position.X -= 10 + x;




                    if (transform.position.X + transform.size.Width / 2 >= enemy_.transform.position.X && transform.position.X + transform.size.Width / 2 <= enemy_.transform.position.X + enemy_.transform.size.Width)
                    {
                        if (transform.position.Y + transform.size.Height >= enemy_.transform.position.Y && transform.position.Y + transform.size.Height <= enemy_.transform.position.Y + enemy_.transform.size.Height)
                        {
                            gravity = 1000;
                        }
                    }
                }


            }





        }








        public void AddForce()
        {
           Saund.PlaySaundJump();
            gravity = -19;
          
        }

       

    }
}
