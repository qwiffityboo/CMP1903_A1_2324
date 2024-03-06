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
        private int _heldval;
        private Random _roll = new Random();

        public int DiceRoll()
        {
            //rolls the dice  and returns the value 
            heldval = roll.Next(1, 7);
            return heldval;
        }


        public int FetchValue()
        {
            //fetches the held value when it is needed 
            
            return heldval;
        }





      



    }

}