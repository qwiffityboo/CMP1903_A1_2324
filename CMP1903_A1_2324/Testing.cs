﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Testing
    {
        public static void Testings()
        {
            GameTest();
            DieTest();
        }

        public static void DieTest()
        {
            //test the reult of the dice roll to see of it is in range 
            Die die = new Die();
            die.DiceRoll();
            int total = die.FetchValue();
            Debug.Assert(total >= 1 && total <= 6, "the die that was rolled did not fall within range and did not work as intended");
        }
        public static void GameTest()
        {
            //test the reult of the game to see of it is in range 
            Game game = new Game();
            int total = game.Sum();
            Debug.Assert(total >= 3 && total <= 18, "the dice did not add up correctly and did not function as intended");
        }

       
    }
}
