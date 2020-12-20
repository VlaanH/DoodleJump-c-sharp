using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Classes
{
    public static class StaticData
    {
        static public float SaveGravity { get; set; }

        static public bool InitStart = false;
        
        static public float SaveA { get; set; }

        static public bool EnemyPaus = false;

        static public bool KILLgame = false;

        static public bool SaundOn = true;





        static public string NamePlayer { get; set; }




        static public int EnemyI { get; set; }
        static public float xALL { get; set; }
         static public float yALL { get; set; }
    }
}
