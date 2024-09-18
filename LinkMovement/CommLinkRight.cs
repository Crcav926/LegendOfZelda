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
            myGame.LinkCharacter.xCord += 2;
            myGame.LinkCharacter.linkSprite = new LinkBasicAnimation(myGame.linkTexture, 1);
            
            // Left commented in case of need.
            //int flipped = 0;
            //if (flipped == 0)
            //{
            //    myGame.LinkCharacter.sprite = new LeftLinkSprite(myGame.linkTexture);
            //    flipped = 1;
            //}
            //myGame.LinkCharacter.xCord -= 1;
        }
    }
}
