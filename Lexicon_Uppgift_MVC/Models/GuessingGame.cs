using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lexicon_Uppgift_MVC.Models
{
    public class GuessingGame
    {
        public int MyProperty { get; set; }
        List<int> numbers = new List<int>();
        int Count = 0;
        int x = 0;
        public string message { get; set; }

        public int GenerateRandomNumber()
        {
            Random rand = new Random();
            MyProperty = rand.Next(1, 100);
            x = MyProperty;
            return MyProperty;
        }

        //Enter gessing numbers to the list

        public string EnterList(int number,int? n1)
        {
            Count++;

            if (number == n1)
            {
                message = $"You have win and you tried {Count} times";
            }
            else
            {
                numbers.Add(number);
            }
            return message;
        }
    }
}
