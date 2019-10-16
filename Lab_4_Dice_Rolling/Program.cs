// ===============================
// AUTHOR     : Jonathan Lubaway
// CREATE DATE: October 16th, 2019
// PURPOSE    : Create an application that simulates dice rolling.
// ===============================

using System;
using System.Threading;
using System.Text.RegularExpressions;

namespace Lab_4_Dice_Rolling
{
    class Program
    {
        static void Main(string[] args)
        {
            // Starting the program and calling the first method needed for the dice rolling.
            Console.Write("Welcome to the Grand Circus Casino!. ");
            int rolls = 0;
            GetContinue(rolls);
            Console.WriteLine("Have a good day.");
        }

        // This method checks whether a user wants to roll the dice or not.
        public static void GetContinue(int rolls)
        {
            Console.Write("Roll the dice? (y/n) ");
            string userAnswer = Console.ReadLine();
            Console.WriteLine("\n");
            if (userAnswer == "y")
            {
                /* If a user wants to roll the die this calls the next method in order to find
                 * the amount of sides you want */
                GetSidesOfDie(rolls);
            }
            else if (userAnswer == "n")
            {
                Console.WriteLine("It was nice playing with you.");
            }
            else
            {
                Console.WriteLine("Please enter a valid answer.");
                GetContinue(rolls);
            }
        }

        // This method determines the amount of sides a user wants on their set of die.
        public static void GetSidesOfDie(int rolls)
        {
            /* This string is Regex for determining if there is anything other
               than a number in the user's input. */
            string hasLetters = @"\D";
            Console.Write("How many sides should each dice have? ");
            string sidesString = Console.ReadLine();
            Console.WriteLine("\n");
            int sides;

            // If the input has anything other than a number this calls the method again.
            if (Regex.IsMatch(sidesString, hasLetters))
            {
                Console.WriteLine("Your response has letters or is a decimal in it please only put in whole numbers.");
                GetSidesOfDie(rolls);
            }
            else
            {
                // The dice is finally rolled once a normal number is put in.
                sides = int.Parse(sidesString);
                RollDice(sides, rolls);
            }
        }

        // This method rolls two die and gives an output under the right conditions.
        public static void RollDice(int sides, int rolls)
        {
            Random randomGen1 = new System.Random();

            // This command is meant to seperate the two random numbers even if they have the same seed.
            Thread.Sleep(1000);
            Random RandomGen2 = new System.Random();
            int value1 = randomGen1.Next(1, sides);
            int value2 = randomGen1.Next(1, sides);
            rolls++;
            int total = value1 + value2;
            Console.WriteLine($"Roll {rolls}: \n{value1} \n{value2}");

            // If the dice have 6 sides these will tell you if you have a special roll from the game craps
            if (sides == 6)
            {
                if (value1 == 1 && value2 == 1)
                {
                    Console.WriteLine("Too bad you got snake eyes.");
                }
                else if (value1 == 6 && value2 == 6)
                {
                    Console.WriteLine("You got boxcars.");
                }
                else if (total == 3)
                {
                    Console.WriteLine("You got craps.");
                }
                else if (total == 7)
                {
                    Console.WriteLine("You got a natural.");
                }
                else if (total == 11)
                {
                    Console.WriteLine("You got a natural.");
                }
            }
            GetContinue(rolls);
        }
    }
}
