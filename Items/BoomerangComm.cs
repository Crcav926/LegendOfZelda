using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class BoomerangComm : ICommand
    {
        Game1 myGame;
        public BoomerangComm(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            // later i need to make this based on what direction link is facing
            if (myGame.LinkCharacter.direction == 0)
            {
                // create boomering moving sideways
                int i = 3;
                // sets sprite 
                myGame.items.SetSprite(i);
                //sets movement direction to horizontal
                myGame.items.direction = 2;
            }
        }
    }
}
