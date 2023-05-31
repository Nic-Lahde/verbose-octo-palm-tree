using System;
namespace ShootingDice
{
    // TODO: Complete this class

    // A player the prompts the user to enter a number for a roll
    public class HumanPlayer : Player
    {
        public override int Roll()
        {
            Console.WriteLine($"What did {this.Name} roll?");
            int myRoll = 0;

            bool validInput = false;
            while (!validInput)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int parsedValue))
                {
                    myRoll = parsedValue;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer value.");
                }
            }

            return myRoll;
        }
    }
}