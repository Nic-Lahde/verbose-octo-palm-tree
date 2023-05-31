using System;
using System.Collections.Generic;
namespace ShootingDice
{
    // A SmackTalkingPlayer who randomly selects a taunt from a list to say to the other player
    public class CreativeSmackTalkingPlayer : Player
    {
        public List<string> Taunts { get; set; }

        public override int Roll()
        {

            Random random = new Random();

            Console.WriteLine($"{this.Name} shouts: {Taunts[random.Next(Taunts.Count)]}");


            return random.Next(DiceSize) + 1;
        }


    }
}

