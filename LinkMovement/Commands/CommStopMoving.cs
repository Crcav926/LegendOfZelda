using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.LinkMovement
{
    internal class CommStopMoving: ICommand
    {
        Game1 myGame;
        Vector2 linkDirection;

        public CommStopMoving(Game1 game, Vector2 direction)
        {
            myGame = game;
            linkDirection = direction;

        }
        public void Execute()
        {
            myGame.LinkCharacter.linkSprite = new LinkIdleSprite(myGame.linkTexture, linkDirection);
            myGame.LinkCharacter.animated = false;
        }

    }
}
