using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class CommMoveHeldDown : ICommand
    {
        Game1 myGame;
        Vector2 linkDirection;
        public CommMoveHeldDown(Game1 game, Vector2 direction)
        {
            myGame = game;
            linkDirection = direction;

        }
        public void Execute()
        {
            if(myGame.LinkCharacter.animated == false)
            {
                myGame.LinkCharacter.linkSprite = new LinkBasicAnimation(myGame.linkTexture, linkDirection);
                myGame.LinkCharacter.animated = true;
            }
            myGame.LinkCharacter.Move(linkDirection);
        }
    }
}
