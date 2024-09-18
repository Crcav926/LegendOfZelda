using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class CommLinkDown : ICommand
    {
        Game1 myGame;
        public CommLinkDown(Game1 game)
        {
            myGame = game;
        }


        public void Execute()
        {
            myGame.LinkCharacter.yCord += 2;
            myGame.LinkCharacter.linkSprite = new LinkBasicAnimation(myGame.linkTexture, 2);
        }
    }
}
