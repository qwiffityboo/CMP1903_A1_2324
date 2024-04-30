using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Die
    {
        //the objects i will use 
        
        private Random _roll = new Random();

        public int DiceRoll()
        {
            Testing tester = new Testing();

            //rolls the dice  and returns the value 
            int heldval = _roll.Next(1, 7);
            string roll = "roll";
            tester.DieTest(heldval, roll);
            return heldval;
        }

    }

}