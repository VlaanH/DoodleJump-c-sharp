using Platformer.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;
using Enemy.Classes;
using System.Threading.Tasks;
using Ball.Classes;
using OpenTK.Input;

namespace Platformer
{
    public partial class Game : Form
    {
        

        bool iMesBox;
        Player player;
        Timer timer1;

       

        public Game()
        {


            InitializeComponent();
            Init();
            timer1 = new Timer();
            timer1.Interval = 15;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();
            this.KeyDown += new KeyEventHandler(OnKeyboardPressed);
            this.KeyUp += new KeyEventHandler(OnKeyboardUp);
            this.BackgroundImage = Platformer.Properties.Resources.Back;
            this.Height = 900;
            this.Width = 700;
            this.Paint += new PaintEventHandler(OnRepaint);


           



        }

        public void Init()
        {
            
      
            PlatformController.platforms = new System.Collections.Generic.List<Platform>();
            PlatformController.AddPlatform(new System.Drawing.PointF(100, 400));
            PlatformController.startPlatformPosY = 600;
            PlatformController.score = 0;
        



            EnemyController.enemy = new System.Collections.Generic.List<Enemy.Classes.Enemy>();
            EnemyController.startEnemyPosY = 400;
        

            BallController.ball = new System.Collections.Generic.List<Ball.Classes.Ball>();
            BallController.startPlatformPosY = 400;
          


            iMesBox = default;
            player = new Player();
         
        }

        private void OnKeyboardUp(object sender,KeyEventArgs e)
        {
            player.physics.dx = 0;
        }


        KeyboardState keyboardState, lastKeyboardState;

     

   




        




        private void OnKeyboardPressed(object sender,KeyEventArgs e)
        {
          







            switch (e.KeyCode.ToString())
            {
                case "D":
                    if (StaticData.xALL < 600)
                        player.physics.dx = 12;
                   
                    break;
                case "A":
                    if (StaticData.xALL>5)
                    player.physics.dx = -12;

                  
                    break;
                case "F":
                   
                    BallController.GenerateRandomBall();
                    
                    break;

                case "Escape":

                    StaticData.SaveA = Physics.a;
                    StaticData.SaveGravity = Physics.gravity;
                    StaticData.EnemyPaus = true;


                    Physics.gravity = 0;
                    Physics.a = 0;

                    Form form = new Paus();
                    form.ShowDialog();

                    
                    break;

            }
       
        }


        private void Update(object sender,EventArgs e)
        {
           







            this.Text = "Платформер  "+StaticData.NamePlayer+" Счёт: "  + PlatformController.score;

            if (StaticData.KILLgame==true)
            {
                StaticData.KILLgame = false;
                this.Close();
            }

            if (PlatformController.platforms.Count > 0 && PlatformController.platforms[0] != null)
                if (player.physics.transform.position.Y >= PlatformController.platforms[0].transform.position.Y + 1000)
                {



                    if (iMesBox == false)
                    {


                        Saund.PlaySaundDead();

    
                        iMesBox = true;

                        History.Save(StaticData.NamePlayer + " Счёт: " + PlatformController.score);

                        Form form = new GAME_OVER();
                        form.ShowDialog();



                    }

                }

            if (StaticData.InitStart == true)
            {
                StaticData.InitStart = false;
                Init();
            }

            
            player.physics.ApplyPhysics();
            FollowPlayer();
           
            Invalidate();
        }

        public async void FollowPlayer()
        {
       
              
            await Task.Run(() =>
            {
                    int offset = 400 - (int)player.physics.transform.position.Y;
                player.physics.transform.position.Y += offset;
                for(int i = 0; i < PlatformController.platforms.Count; i++)
                {
                    var platform = PlatformController.platforms[i];
                    platform.transform.position.Y += offset;
                    if (i < EnemyController.enemy.Count)
                    {
                        var platform2 = EnemyController.enemy[i];
                        platform2.transform.position.Y += offset;

                        
                    }
                    if (i < BallController.ball.Count)
                    {
                        var platform3 = BallController.ball[i];
                        platform3.transform.position.Y += offset-20;
                    }

                }

                
                


            });


        }

        private async void OnRepaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (PlatformController.platforms.Count > 0)
            {   
                     for (int i = 0; i < PlatformController.platforms.Count; i++)
                         PlatformController.platforms[i].DrawSprite(g);
             
                    for (int i = 0; i < EnemyController.enemy.Count; i++)
                        EnemyController.enemy[i].DrawSprite(g);

                    for (int i = 0; i < BallController.ball.Count; i++)
                        BallController.ball[i].DrawSprite(g);
               
               

               

            }
            player.DrawSprite(g);



        }

     

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
