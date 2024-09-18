using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class ArrowComm : ICommand
    {
        Game1 myGame;
        public ArrowComm(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            // later i need to make this based on what direction link is facing
            if (myGame.LinkCharacter.direction == 0)
            {
                // create an arrow moving up
                int i = 1;
                // sets sprite 
                myGame.items.SetSprite(i);
                //sets movement direction to vertical
                myGame.items.direction = 1;
            }
        }
    }
}
