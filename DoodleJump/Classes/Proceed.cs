using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Classes
{
   public static class Proceed
    {

       public static void Start(float gravity,float a) 
        {

            Physics.gravity = gravity;
            Physics.a = a;
        }

    }
}
