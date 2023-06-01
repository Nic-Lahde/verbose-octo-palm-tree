using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootingDice
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player();
            player1.Name = "Bob";

            Player player2 = new Player();
            player2.Name = "Sue";

            player2.Play(player1);

            Console.WriteLine("-------------------");

            Player player3 = new Player();
            player3.Name = "Wilma";

            player3.Play(player2);

            Console.WriteLine("-------------------");

            Player large = new LargeDicePlayer();
            large.Name = "Bigun Rollsalot";

            player1.Play(large);

            Console.WriteLine("-------------------");

            SmackTalkingPlayer smackTalker = new SmackTalkingPlayer();
            smackTalker.Name = "Snarkus";
            smackTalker.Taunt = "Snarkus shouts: My power is unmatched!";

            OneHigherPlayer oneHigherPlayer = new OneHigherPlayer();
            oneHigherPlayer.Name = "Sneaky Pete";

            HumanPlayer humanPlayer = new HumanPlayer();
            humanPlayer.Name = "Jimothy";

            CreativeSmackTalkingPlayer creativeSmackTalkingPlayer = new CreativeSmackTalkingPlayer();
            creativeSmackTalkingPlayer.Name = "Giggles";
            creativeSmackTalkingPlayer.Taunts = new List<string>();
            creativeSmackTalkingPlayer.Taunts.Add("You get tired just WATCHING dice.");
            creativeSmackTalkingPlayer.Taunts.Add("You are to dice what Michael Jordan is to baseball.");
            creativeSmackTalkingPlayer.Taunts.Add("You six piece chicken McNobody.");

            SoreLoserPlayer soreLoserPlayer = new SoreLoserPlayer();
            soreLoserPlayer.Name = "Tony";

            List<Player> players = new List<Player>() {
                player1, player2, player3, large, smackTalker, humanPlayer, oneHigherPlayer, creativeSmackTalkingPlayer, soreLoserPlayer
            };
            try
            {
                PlayMany(players);

            }
            catch
            {
                Console.WriteLine("A sore loser threw the dice as far as they could.");
            }
        }

        static void PlayMany(List<Player> players)
        {
            Console.WriteLine();
            Console.WriteLine("Let's play a bunch of times, shall we?");

            // We "order" the players by a random number
            // This has the effect of shuffling them randomly
            Random randomNumberGenerator = new Random();
            List<Player> shuffledPlayers = players.OrderBy(p => randomNumberGenerator.Next()).ToList();

            // We are going to match players against each other
            // This means we need an even number of players
            int maxIndex = shuffledPlayers.Count;
            if (maxIndex % 2 != 0)
            {
                maxIndex = maxIndex - 1;
            }

            // Loop over the players 2 at a time
            for (int i = 0; i < maxIndex; i += 2)
            {
                Console.WriteLine("-------------------");

                // Make adjacent players play noe another
                Player player1 = shuffledPlayers[i];
                Player player2 = shuffledPlayers[i + 1];
                player1.Play(player2);
            }
        }
    }
}