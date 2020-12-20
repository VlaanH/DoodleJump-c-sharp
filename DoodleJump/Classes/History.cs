using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Classes
{
   public static class History
    {
        public async static void Save(String text)
        {
            await Task.Run(() =>
            {
                string histxt = File.ReadAllText("HistoryData");

                File.WriteAllText("HistoryData", histxt + text+"\n",Encoding.UTF8);
            });
        }

        public static string Read()
        {


            if (File.Exists("HistoryData"))
            {
                string histxt = File.ReadAllText("HistoryData");
                return histxt;
            }
            else
            {
                return "";
            }
             
           
        }

        public static void Dell()
        {



            File.WriteAllText("HistoryData",default);
        

        }


    }
}
