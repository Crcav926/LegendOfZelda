using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class CommLinkLeft : ICommand
    {
        Game1 myGame;
        public CommLinkLeft(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            int flipped = 0;
            if (flipped == 0){
                myGame.LinkCharacter.sprite = new LeftLinkSprite(myGame.linkTexture);
                flipped = 1;
            }
            myGame.LinkCharacter.xCord -= 1;
        }
    }
}
