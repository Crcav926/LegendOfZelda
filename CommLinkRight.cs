using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class CommLinkRight : ICommand
    {
        Game1 myGame;
        public CommLinkRight(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            int flipped = 0;
            if (flipped == 0)
            {
                myGame.LinkCharacter.sprite = new RightLinkSprite(myGame.linkTexture);
                flipped = 1;
            }
            myGame.LinkCharacter.xCord += 1;
        }
    }
}
