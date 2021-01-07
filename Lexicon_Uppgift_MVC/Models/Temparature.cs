using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lexicon_Uppgift_MVC.Models
{
    public class Temparature
    {
        public static double HumanTemparature = 98.3;

        public static string MyProperty { get; set; }

        //static double x = HumanTemparature;

        public static string Check(double number)
        {
            if (number > HumanTemparature)
            {
                MyProperty = "You have fever";
            }
            else
            {
                MyProperty = "You have no fever";
            }

            return MyProperty;
        }
        
    }
}
