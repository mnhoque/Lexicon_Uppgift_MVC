using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lexicon_Uppgift_MVC.Models
{
    public class GuessingGame
    {
        public int MyProperty { get; set; }
        
        //static int Count = 0;
        public int count { get; set; }
        public string message { get; set; }

        public int GenerateRandomNumber()
        {
            Random rand = new Random();
            MyProperty = rand.Next(1, 100);
            //x = MyProperty;
            
            return MyProperty;
        }

        //Enter gessing numbers to the list
        

        public string EnterList(int number,int? n1)
        {

            if (number == n1)
            {
                message = $"You have win ";
            }
            else
            {
                //numbers.Add(number);
                message = $"You have not win because submitted number did not match with random number ";
            }
            return message;
        }
        
    }
}
