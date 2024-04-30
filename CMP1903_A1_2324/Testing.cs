using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp2
{
    class Testing
    {
        private int _player = 1;
        List<string> letters = [" ", "", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"];
        List<string> range = ["1", "2", "3", "4", "5", "6"];

        public void DieTest(int heldval, string type)
        {
            //test the reult of the dice roll to see of it is in range 
            if (type == "roll")
            {
                Debug.Assert(heldval >= 1 && heldval <= 6, "the die that was rolled did not fall within range and did not work as intended");
            }
            //test result of the dice rolls in sevens
            if (type == "sevens")
            {
                Debug.Assert(heldval >= 1 && heldval <= 12, "the die that was rolled did not fall within range and did not work as intended");
            }
            
        }


        public int Manual_Tests()
        {
            Console.WriteLine("here you can test the games to make sure they are correct by inputing the values manually");
            Console.WriteLine("which game would you like to play threes(1) or seven(2)");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                int player1_score = 0;
                int player2_score = 0;

                bool loop = true;
                // uses 5 dice rolls and tries to make 3 of a kind 4 of a kind or 5 of a kind if the roll has 2 of a kind they have a choice to reroll all or the other dice to make a 3,4 or 5 of a kind if none are the same nothing happens
                // 3 = 3 points  4 = 6 points  5 = 12 points 
                //pass to next player play until one reaches 20 points 
                // each roll should be saved for statistics
                while (loop == true)
                {

                    if (_player == 1)
                    {

                        Console.WriteLine("player 1's turn");
                        

                        //seperate list to store duplicates
                        List<int> duplicates = [];
                        // stores the results 
                        List<int> rolls = [];
                        while (rolls.Count < 5)
                        {
                            Console.WriteLine("input a number from 1-6");
                            string temp = Console.ReadLine();
                            bool temp2 = letters.Contains(temp);
                            bool temp3 = range.Contains(temp);
                            //error handling 
                            if (temp2 == true)
                            {
                                Console.WriteLine("not a number between 1-6 try again");
                                continue;
                            }
                            else
                            {
                                int number = int.Parse(temp);

                                if (number < 1 ^ number > 6)
                                {
                                    Console.WriteLine("number not in range try again");
                                }
                                else
                                {

                                    rolls.Add(number);
                                }
                            }
                           
                        }
                        
                        
                        
                        int count = rolls.Count - 1;
                        // check if there are duplicates 
                        for (int i = 0; i <= rolls.Count - 1; i++)
                        {
                            //hold the first number in a seperate variable if duplicate in the list put it back if not remove it 



                            int heldval = rolls[i];
                            rolls.Remove(rolls[i]);
                            //checks if the value has a duplicate
                            bool Number_In_List = rolls.Contains(heldval);
                            if (Number_In_List == true)
                            {
                                //insert value into the duplicates list
                                duplicates.Add(heldval);
                            }
                            rolls.Insert(i, heldval);

                        }
                        duplicates.Sort();

                        for (int i = 0; i <= duplicates.Count - 1; i++)
                        {
                            // outputs each item in the list of duplicate numbers 

                            Console.Write(duplicates[i]);

                        }
                        Console.Write("\n");

                        for (int o = 0; o <= 1; o++)
                        {


                            //checks if the duplicates list has a double or 2 sets of doubles
                            if (duplicates.Count == 2)
                            {
                                //stops only after 1 rerroll
                                if (o == 0)
                                {

                                    //ask user which number in the duplicate list they would like to reroll for if there is 2 doubles's
                                    Console.WriteLine("would you like to reroll for your number or would you like to reroll all (input the number or -1 to reroll all)");
                                    string answer2 = Console.ReadLine();
                                    if (int.Parse(answer) == duplicates[0])
                                    {
                                        //removes the last 2 nnumbers

                                        rolls = [];
                                        while (rolls.Count < 3)
                                        {
                                            Console.WriteLine("input a number from 1-6");
                                            string temp = Console.ReadLine();
                                            bool temp2 = letters.Contains(temp);
                                            bool temp3 = range.Contains(temp);
                                            //error handling 
                                            if (temp2 == true)
                                            {
                                                Console.WriteLine("not a number between 1-6 try again");
                                                continue;
                                            }
                                            else
                                            {
                                                int number = int.Parse(temp);

                                                if (number < 1 ^ number > 6)
                                                {
                                                    Console.WriteLine("number not in range try again");
                                                }
                                                else
                                                {

                                                    rolls.Add(number);
                                                }
                                            }

                                        }

                                        count = rolls.Count - 1;
                                        // check if there are duplicates 
                                        for (int i = 0; i <= rolls.Count - 1; i++)
                                        {
                                            //hold the first number in a seperate variable if duplicate in the list put it back if not remove it 



                                            int heldval = rolls[i];
                                            rolls.Remove(rolls[i]);
                                            //checks if the value is in the duplicate list

                                            bool Number_In_Duplicates = duplicates.Contains(heldval);

                                            if (Number_In_Duplicates == true)
                                            {
                                                //adds to duplicate list
                                                duplicates.Add(heldval);
                                            }


                                        }
                                        for (int i = 0; i <= duplicates.Count - 1; i++)
                                        {
                                            // outputs each item in the list of duplicate numbers 

                                            Console.Write(duplicates[i]);

                                        }
                                        Console.Write("\n");
                                    }



                                    else if (answer == "-1")
                                    {
                                        duplicates.RemoveRange(0, 2);
                                        rolls = [];
                                        while (rolls.Count < 5)
                                        {
                                            Console.WriteLine("input a number from 1-6");
                                            string temp = Console.ReadLine();
                                            bool temp2 = letters.Contains(temp);
                                            bool temp3 = range.Contains(temp);
                                            //error handling 
                                            if (temp2 == true)
                                            {
                                                Console.WriteLine("not a number between 1-6 try again");
                                                continue;
                                            }
                                            else
                                            {
                                                int number = int.Parse(temp);

                                                if (number < 1 ^ number > 6)
                                                {
                                                    Console.WriteLine("number not in range try again");
                                                }
                                                else
                                                {

                                                    rolls.Add(number);
                                                }
                                            }

                                        }
                                        count = rolls.Count - 1;
                                        // check if there are duplicates 
                                        for (int i = 0; i <= rolls.Count - 1; i++)
                                        {
                                            //hold the first number in a seperate variable if duplicate in the list put it back if not remove it 



                                            int heldval = rolls[i];
                                            rolls.Remove(rolls[i]);
                                            //checks if the value has a duplicate
                                            bool Number_In_List = rolls.Contains(heldval);
                                            if (Number_In_List == true)
                                            {
                                                //insert value into the duplicates list
                                                duplicates.Add(heldval);
                                            }
                                            rolls.Insert(i, heldval);


                                        }
                                        for (int i = 0; i <= duplicates.Count - 1; i++)
                                        {
                                            // outputs each item in the list of duplicate numbers 

                                            Console.Write(duplicates[i]);

                                        }
                                        Console.Write("\n");
                                    }


                                }
                            }
                            else if (duplicates.Count == 4 && duplicates[0] != duplicates[2])
                            {
                                //stops only after 1 rerroll
                                if (o == 0)
                                {
                                    if (duplicates.Count == 4)
                                    {
                                        //ask user which number in the duplicate list they would like to reroll for if there is 2 doubles's
                                        Console.WriteLine("which number in these doubles would you like to reroll for or would you like to reroll all (input which number or -1 to reroll all)");
                                        string answer2 = Console.ReadLine();
                                        if (int.Parse(answer) == duplicates[0])
                                        {
                                            //removes the last 2 nnumbers
                                            duplicates.RemoveRange(2, 2);
                                            rolls = [];
                                            while (rolls.Count < 3)
                                            {
                                                Console.WriteLine("input a number from 1-6");
                                                string temp = Console.ReadLine();
                                                bool temp2 = letters.Contains(temp);
                                                bool temp3 = range.Contains(temp);
                                                //error handling 
                                                if (temp2 == true)
                                                {
                                                    Console.WriteLine("not a number between 1-6 try again");
                                                    continue;
                                                }
                                                else
                                                {
                                                    int number = int.Parse(temp);

                                                    if (number < 1 ^ number > 6)
                                                    {
                                                        Console.WriteLine("number not in range try again");
                                                    }
                                                    else
                                                    {

                                                        rolls.Add(number);
                                                    }
                                                }

                                            }
                                            count = rolls.Count - 1;
                                            // check if there are duplicates 
                                            for (int i = 0; i <= rolls.Count - 1; i++)
                                            {
                                                //hold the first number in a seperate variable if duplicate in the list put it back if not remove it 



                                                int heldval = rolls[i];
                                                rolls.Remove(rolls[i]);
                                                //checks if the value is in the duplicate list

                                                bool Number_In_Duplicates = duplicates.Contains(heldval);

                                                if (Number_In_Duplicates == true)
                                                {
                                                    //adds to duplicate list
                                                    duplicates.Add(heldval);
                                                }


                                            }
                                            for (int i = 0; i <= duplicates.Count - 1; i++)
                                            {
                                                // outputs each item in the list of duplicate numbers 

                                                Console.Write(duplicates[i]);

                                            }
                                            Console.Write("\n");
                                        }





                                        else if (int.Parse(answer) == duplicates[2])
                                        {
                                            //removes the first 2 numbers 
                                            duplicates.RemoveRange(0, 2);
                                            rolls = [];
                                            while (rolls.Count < 3)
                                            {
                                                Console.WriteLine("input a number from 1-6");
                                                string temp = Console.ReadLine();
                                                bool temp2 = letters.Contains(temp);
                                                bool temp3 = range.Contains(temp);
                                                //error handling 
                                                if (temp2 == true)
                                                {
                                                    Console.WriteLine("not a number between 1-6 try again");
                                                    continue;
                                                }
                                                else
                                                {
                                                    int number = int.Parse(temp);

                                                    if (number < 1 ^ number > 6)
                                                    {
                                                        Console.WriteLine("number not in range try again");
                                                    }
                                                    else
                                                    {

                                                        rolls.Add(number);
                                                    }
                                                }

                                            }
                                            count = rolls.Count - 1;
                                            // check if there are duplicates 
                                            for (int i = 0; i <= rolls.Count - 1; i++)
                                            {
                                                //hold the first number in a seperate variable if duplicate in the list put it back if not remove it 



                                                int heldval = rolls[i];
                                                rolls.Remove(rolls[i]);
                                                //checks if the value is in the duplicate list

                                                bool Number_In_Duplicates = duplicates.Contains(heldval);

                                                if (Number_In_Duplicates == true)
                                                {
                                                    //adds to duplicate list
                                                    duplicates.Add(heldval);
                                                }


                                            }
                                            for (int i = 0; i <= duplicates.Count - 1; i++)
                                            {
                                                // outputs each item in the list of duplicate numbers 

                                                Console.Write(duplicates[i]);

                                            }
                                            Console.Write("\n");


                                        }




                                        else if (answer == "-1")
                                        {
                                            duplicates.RemoveRange(0, 3);
                                            rolls = [];
                                            while (rolls.Count < 5)
                                            {
                                                Console.WriteLine("input a number from 1-6");
                                                string temp = Console.ReadLine();
                                                bool temp2 = letters.Contains(temp);
                                                bool temp3 = range.Contains(temp);
                                                //error handling 
                                                if (temp2 == true)
                                                {
                                                    Console.WriteLine("not a number between 1-6 try again");
                                                    continue;
                                                }
                                                else
                                                {
                                                    int number = int.Parse(temp);

                                                    if (number < 1 ^ number > 6)
                                                    {
                                                        Console.WriteLine("number not in range try again");
                                                    }
                                                    else
                                                    {

                                                        rolls.Add(number);
                                                    }
                                                }

                                            }
                                            count = rolls.Count - 1;
                                            // check if there are duplicates 
                                            for (int i = 0; i <= rolls.Count - 1; i++)
                                            {
                                                //hold the first number in a seperate variable if duplicate in the list put it back if not remove it 



                                                int heldval = rolls[i];
                                                rolls.Remove(rolls[i]);
                                                //checks if the value has a duplicate
                                                bool Number_In_List = rolls.Contains(heldval);
                                                if (Number_In_List == true)
                                                {
                                                    //insert value into the duplicates list
                                                    duplicates.Add(heldval);
                                                }
                                                rolls.Insert(i, heldval);


                                            }
                                            for (int i = 0; i <= duplicates.Count - 1; i++)
                                            {
                                                // outputs each item in the list of duplicate numbers 

                                                Console.Write(duplicates[i]);

                                            }
                                            Console.Write("\n");
                                        }

                                    }
                                }
                            }
                            //output for if they dont get 3,4 or 5 of a kind
                            if (duplicates.Count == 2)
                            {
                                Console.WriteLine("still only a double 0 points awarded");
                            }
                            else if (duplicates.Count == 4 && duplicates[0] != duplicates[2])
                            {
                                Console.WriteLine("still only a double 0 points awarded");
                            }

                            //sort the duplictaes to check
                            duplicates.Sort();
                            //check if the numbers make 3,4 or 5 of the same to make points 
                            if (duplicates.Count != 2)
                            {
                                //checks if 3 values for 3 of a kind
                                if (duplicates.Count == 3)
                                {
                                    player1_score += 3;
                                    Console.WriteLine("3 of a kind 3 points awarded");
                                }

                                //checks if 4 values for 4 of a kind
                                else if (duplicates.Count == 4 && duplicates[0] == duplicates[2])
                                {
                                    player1_score += 6;
                                    Console.WriteLine("4 of a kind 6 points awarded");

                                }
                                //checks if 5 values 
                                else if (duplicates.Count == 5)
                                {
                                    //checks if 5 of a kind
                                    if (duplicates[0] == duplicates[2] && duplicates[0] == duplicates[3])
                                    {
                                        player1_score += 12;
                                        Console.WriteLine("5 of a kind 12 points awarded");
                                    }
                                    // checks if 5 values but has only 3 of the same 
                                    if (duplicates[0] == duplicates[2] ^ duplicates[2] == duplicates[4])
                                    {

                                        player1_score += 3;
                                        Console.WriteLine("3 of a kind 3 points awarded");
                                    }


                                }
                                else if (duplicates.Count == 0)
                                {
                                    Console.WriteLine("no duplicates 0 points awarded");
                                }
                            }
                        }
                        if (player1_score >= 20)
                        {
                            //stop game if the score is more or equal to 20
                            loop = false;
                        }




                        //passes to next player 
                        _player = 2;
                        Console.WriteLine("player 1 score = " + player1_score);
                    }

                    if (_player == 2)
                    {
                        Console.WriteLine("player 2's turn");

                        

                        //seperate list to store duplicates
                        List<int> duplicates = [];
                        // stores the results 
                        List<int> rolls = [];
                        while (rolls.Count < 5)
                        {
                            Console.WriteLine("input a number from 1-6");
                            string temp = Console.ReadLine();
                            bool temp2 = letters.Contains(temp);
                            bool temp3 = range.Contains(temp);
                            //error handling 
                            if (temp2 == true)
                            {
                                Console.WriteLine("not a number between 1-6 try again");
                                continue;
                            }
                            else
                            {
                                int number = int.Parse(temp);

                                if (number < 1 ^ number > 6)
                                {
                                    Console.WriteLine("number not in range try again");
                                }
                                else
                                {

                                    rolls.Add(number);
                                }
                            }

                        }

                        int count = rolls.Count - 1;
                        // check if there are duplicates 
                        for (int i = 0; i <= rolls.Count - 1; i++)
                        {
                            //hold the first number in a seperate variable if duplicate in the list put it back if not remove it 



                            int heldval = rolls[i];
                            rolls.Remove(rolls[i]);
                            //checks if the value has a duplicate
                            bool Number_In_List = rolls.Contains(heldval);
                            if (Number_In_List == true)
                            {
                                //insert value into the duplicates list
                                duplicates.Add(heldval);
                            }
                            rolls.Insert(i, heldval);

                        }
                        duplicates.Sort();

                        for (int i = 0; i <= duplicates.Count - 1; i++)
                        {
                            // outputs each item in the list of duplicate numbers 

                            Console.Write(duplicates[i]);

                        }
                        Console.Write("\n");

                        for (int o = 0; o <= 1; o++)
                        {


                            //checks if the duplicates list has a double or 2 sets of doubles
                            if (duplicates.Count == 2)
                            {
                                //stops only after 1 rerroll
                                if (o == 0)
                                {

                                    //ask user which number in the duplicate list they would like to reroll for if there is 2 doubles's
                                    Console.WriteLine("would you like to reroll for your number or would you like to reroll all (input the number or -1 to reroll all)");
                                    string answer2 = Console.ReadLine();
                                    if (int.Parse(answer) == duplicates[0])
                                    {
                                        //removes the last 2 nnumbers

                                        rolls = [];
                                        while (rolls.Count < 3)
                                        {
                                            Console.WriteLine("input a number from 1-6");
                                            string temp = Console.ReadLine();
                                            bool temp2 = letters.Contains(temp);
                                            bool temp3 = range.Contains(temp);
                                            //error handling 
                                            if (temp2 == true)
                                            {
                                                Console.WriteLine("not a number between 1-6 try again");
                                                continue;
                                            }
                                            else
                                            {
                                                int number = int.Parse(temp);

                                                if (number < 1 ^ number > 6)
                                                {
                                                    Console.WriteLine("number not in range try again");
                                                }
                                                else
                                                {

                                                    rolls.Add(number);
                                                }
                                            }

                                        }
                                        count = rolls.Count - 1;
                                        // check if there are duplicates 
                                        for (int i = 0; i <= rolls.Count - 1; i++)
                                        {
                                            //hold the first number in a seperate variable if duplicate in the list put it back if not remove it 



                                            int heldval = rolls[i];
                                            rolls.Remove(rolls[i]);
                                            //checks if the value is in the duplicate list

                                            bool Number_In_Duplicates = duplicates.Contains(heldval);

                                            if (Number_In_Duplicates == true)
                                            {
                                                //adds to duplicate list
                                                duplicates.Add(heldval);
                                            }


                                        }
                                        for (int i = 0; i <= duplicates.Count - 1; i++)
                                        {
                                            // outputs each item in the list of duplicate numbers 

                                            Console.Write(duplicates[i]);

                                        }
                                        Console.Write("\n");
                                    }



                                    else if (answer == "-1")
                                    {
                                        duplicates.RemoveRange(0, 2);
                                        rolls = [];
                                        while (rolls.Count < 5)
                                        {
                                            Console.WriteLine("input a number from 1-6");
                                            string temp = Console.ReadLine();
                                            bool temp2 = letters.Contains(temp);
                                            bool temp3 = range.Contains(temp);
                                            //error handling 
                                            if (temp2 == true)
                                            {
                                                Console.WriteLine("not a number between 1-6 try again");
                                                continue;
                                            }
                                            else
                                            {
                                                int number = int.Parse(temp);

                                                if (number < 1 ^ number > 6)
                                                {
                                                    Console.WriteLine("number not in range try again");
                                                }
                                                else
                                                {

                                                    rolls.Add(number);
                                                }
                                            }

                                        }
                                        count = rolls.Count - 1;
                                        // check if there are duplicates 
                                        for (int i = 0; i <= rolls.Count - 1; i++)
                                        {
                                            //hold the first number in a seperate variable if duplicate in the list put it back if not remove it 



                                            int heldval = rolls[i];
                                            rolls.Remove(rolls[i]);
                                            //checks if the value has a duplicate
                                            bool Number_In_List = rolls.Contains(heldval);
                                            if (Number_In_List == true)
                                            {
                                                //insert value into the duplicates list
                                                duplicates.Add(heldval);
                                            }
                                            rolls.Insert(i, heldval);


                                        }
                                        for (int i = 0; i <= duplicates.Count - 1; i++)
                                        {
                                            // outputs each item in the list of duplicate numbers 

                                            Console.Write(duplicates[i]);

                                        }
                                        Console.Write("\n");
                                    }


                                }
                            }
                            else if (duplicates.Count == 4 && duplicates[0] != duplicates[2])
                            {
                                //stops only after 1 rerroll
                                if (o == 0)
                                {
                                    if (duplicates.Count == 4)
                                    {
                                        //ask user which number in the duplicate list they would like to reroll for if there is 2 doubles's
                                        Console.WriteLine("which number in these doubles would you like to reroll for or would you like to reroll all (input which number or -1 to reroll all)");
                                        string answer2 = Console.ReadLine();
                                        if (int.Parse(answer) == duplicates[0])
                                        {
                                            //removes the last 2 nnumbers
                                            duplicates.RemoveRange(2, 2);
                                            rolls = [];
                                            while (rolls.Count < 5)
                                            {
                                                Console.WriteLine("input a number from 1-6");
                                                string temp = Console.ReadLine();
                                                bool temp2 = letters.Contains(temp);
                                                bool temp3 = range.Contains(temp);
                                                //error handling 
                                                if (temp2 == true)
                                                {
                                                    Console.WriteLine("not a number between 1-6 try again");
                                                    continue;
                                                }
                                                else
                                                {
                                                    int number = int.Parse(temp);

                                                    if (number < 1 ^ number > 6)
                                                    {
                                                        Console.WriteLine("number not in range try again");
                                                    }
                                                    else
                                                    {

                                                        rolls.Add(number);
                                                    }
                                                }

                                            }
                                            count = rolls.Count - 1;
                                            // check if there are duplicates 
                                            for (int i = 0; i <= rolls.Count - 1; i++)
                                            {
                                                //hold the first number in a seperate variable if duplicate in the list put it back if not remove it 



                                                int heldval = rolls[i];
                                                rolls.Remove(rolls[i]);
                                                //checks if the value is in the duplicate list

                                                bool Number_In_Duplicates = duplicates.Contains(heldval);

                                                if (Number_In_Duplicates == true)
                                                {
                                                    //adds to duplicate list
                                                    duplicates.Add(heldval);
                                                }


                                            }
                                            for (int i = 0; i <= duplicates.Count - 1; i++)
                                            {
                                                // outputs each item in the list of duplicate numbers 

                                                Console.Write(duplicates[i]);

                                            }
                                            Console.Write("\n");
                                        }





                                        else if (int.Parse(answer) == duplicates[2])
                                        {
                                            //removes the first 2 numbers 
                                            duplicates.RemoveRange(0, 2);
                                            rolls = [];
                                            while (rolls.Count < 3)
                                            {
                                                Console.WriteLine("input a number from 1-6");
                                                string temp = Console.ReadLine();
                                                bool temp2 = letters.Contains(temp);
                                                bool temp3 = range.Contains(temp);
                                                //error handling 
                                                if (temp2 == true)
                                                {
                                                    Console.WriteLine("not a number between 1-6 try again");
                                                    continue;
                                                }
                                                else
                                                {
                                                    int number = int.Parse(temp);

                                                    if (number < 1 ^ number > 6)
                                                    {
                                                        Console.WriteLine("number not in range try again");
                                                    }
                                                    else
                                                    {

                                                        rolls.Add(number);
                                                    }
                                                }

                                            }
                                            count = rolls.Count - 1;
                                            // check if there are duplicates 
                                            for (int i = 0; i <= rolls.Count - 1; i++)
                                            {
                                                //hold the first number in a seperate variable if duplicate in the list put it back if not remove it 



                                                int heldval = rolls[i];
                                                rolls.Remove(rolls[i]);
                                                //checks if the value is in the duplicate list

                                                bool Number_In_Duplicates = duplicates.Contains(heldval);

                                                if (Number_In_Duplicates == true)
                                                {
                                                    //adds to duplicate list
                                                    duplicates.Add(heldval);
                                                }


                                            }
                                            for (int i = 0; i <= duplicates.Count - 1; i++)
                                            {
                                                // outputs each item in the list of duplicate numbers 

                                                Console.Write(duplicates[i]);

                                            }
                                            Console.Write("\n");


                                        }




                                        else if (answer == "-1")
                                        {
                                            duplicates.RemoveRange(0, 3);
                                            rolls = [];
                                            while (rolls.Count < 5)
                                            {
                                                Console.WriteLine("input a number from 1-6");
                                                string temp = Console.ReadLine();
                                                bool temp2 = letters.Contains(temp);
                                                bool temp3 = range.Contains(temp);
                                                //error handling 
                                                if (temp2 == true)
                                                {
                                                    Console.WriteLine("not a number between 1-6 try again");
                                                    continue;
                                                }
                                                else
                                                {
                                                    int number = int.Parse(temp);

                                                    if (number < 1 ^ number > 6)
                                                    {
                                                        Console.WriteLine("number not in range try again");
                                                    }
                                                    else
                                                    {

                                                        rolls.Add(number);
                                                    }
                                                }

                                            }
                                            count = rolls.Count - 1;
                                            // check if there are duplicates 
                                            for (int i = 0; i <= rolls.Count - 1; i++)
                                            {
                                                //hold the first number in a seperate variable if duplicate in the list put it back if not remove it 



                                                int heldval = rolls[i];
                                                rolls.Remove(rolls[i]);
                                                //checks if the value has a duplicate
                                                bool Number_In_List = rolls.Contains(heldval);
                                                if (Number_In_List == true)
                                                {
                                                    //insert value into the duplicates list
                                                    duplicates.Add(heldval);
                                                }
                                                rolls.Insert(i, heldval);


                                            }
                                            for (int i = 0; i <= duplicates.Count - 1; i++)
                                            {
                                                // outputs each item in the list of duplicate numbers 

                                                Console.Write(duplicates[i]);

                                            }
                                            Console.Write("\n");
                                        }

                                    }
                                }
                            }
                            //output for if they dont get 3,4 or 5 of a kind
                            if (duplicates.Count == 2)
                            {
                                Console.WriteLine("still only a double 0 points awarded");
                            }
                            else if (duplicates.Count == 4 && duplicates[0] != duplicates[2])
                            {
                                Console.WriteLine("still only a double 0 points awarded");
                            }

                            //sort the duplictaes to check
                            duplicates.Sort();
                            //check if the numbers make 3,4 or 5 of the same to make points 
                            if (duplicates.Count != 2)
                            {
                                //checks if 3 values for 3 of a kind
                                if (duplicates.Count == 3)
                                {
                                    player2_score += 3;
                                    Console.WriteLine("3 of a kind 3 points awarded");
                                }

                                //checks if 4 values for 4 of a kind
                                else if (duplicates.Count == 4 && duplicates[0] == duplicates[2])
                                {
                                    player2_score += 6;
                                    Console.WriteLine("4 of a kind 6 points awarded");

                                }
                                //checks if 5 values 
                                else if (duplicates.Count == 5)
                                {
                                    //checks if 5 of a kind
                                    if (duplicates[0] == duplicates[2] && duplicates[0] == duplicates[3])
                                    {
                                        player2_score += 12;
                                        Console.WriteLine("5 of a kind 12 points awarded");
                                    }
                                    // checks if 5 values but has only 3 of the same 
                                    if (duplicates[0] == duplicates[2] ^ duplicates[2] == duplicates[4])
                                    {

                                        player2_score += 3;
                                        Console.WriteLine("3 of a kind 3 points awarded");
                                    }


                                }
                                else if (duplicates.Count == 0)
                                {
                                    Console.WriteLine("no duplicates 0 points awarded");
                                }
                            }
                        }
                        if (player2_score >= 20)
                        {
                            //stop game if the score is more or equal to 20
                            loop = false;
                        }




                        //passes to next player 
                        _player = 1;

                        Console.WriteLine("player 2 score = " + player2_score);
                    }



                }
                //output result of the game
                if (player1_score > player2_score)
                {
                    Console.WriteLine("player 1 score = " + player1_score);
                    Console.WriteLine("player 2 score = " + player2_score);
                    Console.WriteLine("player 1 wins");

                    
                }
                if (player1_score < player2_score)
                {
                    Console.WriteLine("player 1 score = " + player1_score);
                    Console.WriteLine("player 2 score = " + player2_score);
                    Console.WriteLine("player 2 wins");

                    
                }
                if (player1_score == player2_score)
                {
                    Console.WriteLine("player 1 score = " + player1_score);
                    Console.WriteLine("player 2 score = " + player2_score);
                    Console.WriteLine("draw");
                }
            }
            if (answer == "2")
            {
                bool loop = true;
                int player1_score = 0;
                int player2_score = 0;
                // uses 2 dice rolls and adds them if it = 7 the game ends else adds to the score and passes to next player for their turn end game when one gets 7 and output scores 
                // each roll should be saved for statistics
                while (loop == true)
                {
                    if (_player == 1)
                    {
                        //rolls dice 
                        

                        // stores the rolls 
                        List<int> rolls = [];
                        while (rolls.Count < 2)
                        {
                            Console.WriteLine("input a number from 1-6");
                            string temp = Console.ReadLine();
                            bool temp2 = letters.Contains(temp);
                            bool temp3 = range.Contains(temp);
                            //error handling 
                            if (temp2 == true)
                            {
                                Console.WriteLine("not a number between 1-6 try again");
                                continue;
                            }
                            else
                            {
                                int number = int.Parse(temp);

                                if (number < 1 ^ number > 6)
                                {
                                    Console.WriteLine("number not in range try again");
                                }
                                else
                                {

                                    rolls.Add(number);
                                }
                            }

                        }
                        int total = rolls[0] + rolls[1];
                        //checks if the total is 7
                        if (total == 7)
                        {
                            //ouptuts results
                            Console.WriteLine("player 1 rolled " + rolls[0] + " + " + rolls[1] + " = " + total);

                            //end loop
                            loop = false;


                        }
                        else
                        {
                            //add result to score and outputs results 
                            if (rolls[0] == rolls[1])
                            {
                                total = total * 2;
                            }
                            player1_score += total;
                            Console.WriteLine("player 1 rolled " + rolls[0] + " + " + rolls[1] + " = " + total);
                        }



                        //passes to next player
                        _player = 2;
                    }


                    if (_player == 2)
                    {
                        //rolls dice 
                        

                        // stores the rolls 
                        List<int> rolls = [];
                        while (rolls.Count < 2)
                        {
                            Console.WriteLine("input a number from 1-6");
                            string temp = Console.ReadLine();
                            bool temp2 = letters.Contains(temp);
                            bool temp3 = range.Contains(temp);
                            //error handling 
                            if (temp2 == true)
                            {
                                Console.WriteLine("not a number between 1-6 try again");
                                continue;
                            }
                            else
                            {
                                int number = int.Parse(temp);

                                if (number < 1 ^ number > 6)
                                {
                                    Console.WriteLine("number not in range try again");
                                }
                                else
                                {

                                    rolls.Add(number);
                                }
                            }

                        }
                        int total = rolls[0] + rolls[1];
                        if (total == 7)
                        {
                            Console.WriteLine("player 2 rolled " + rolls[0] + " + " + rolls[1] + " = " + total);

                            loop = false;


                        }
                        else
                        {
                            if (rolls[0] == rolls[1])
                            {
                                total = total * 2;
                            }
                            player2_score += total;
                            Console.WriteLine("player 2 rolled " + rolls[0] + " + " + rolls[1] + " = " + total);

                        }
                        _player = 1;

                    }

                }
                //output results 
                Console.WriteLine("player 1 score = " + player1_score);
                Console.WriteLine("player 2 score = " + player2_score);
                if (player1_score > player2_score)
                {
                    Console.WriteLine("player 1 wins");

                    
                }
                else if (player1_score < player2_score)
                {
                    Console.WriteLine("player 2 wins");

                    
                }
                else if (player1_score == player2_score)
                {
                    Console.WriteLine("draw");
                }
            }








            return 0;
        }

       
    }
}
