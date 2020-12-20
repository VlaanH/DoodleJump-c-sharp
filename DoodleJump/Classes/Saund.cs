using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Classes
{
   static class Saund
    {

        public static void PlaySaundDead()
        {
            
           
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Dead);

            if (StaticData.SaundOn == true)
                player.Play();
        }

        public static void PlaySaundJump()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Jump);
           
            if (StaticData.SaundOn == true)
                player.Play();
        }

        public static void PlaySaundEnemyDead()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.DeadEnemy);

            if (StaticData.SaundOn == true)
                player.Play();
        }



        public async static void PlaySaundBall()
        {
            await Task.Run(async () =>
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Ball);

                if (StaticData.SaundOn == true)
                    player.Play();
            });
        }


    }
}
