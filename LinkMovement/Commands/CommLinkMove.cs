using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.LinkMovement
{
    internal class CommLinkMove: ICommand
    {
        Game1 myGame;
        Vector2 linkDirection;
        public CommLinkMove(Game1 game, Vector2 direction)
        {
            myGame = game;
            linkDirection = direction;

        }
        public void Execute()
        {
            myGame.LinkCharacter.Move(linkDirection);
            myGame.LinkCharacter.linkSprite = new LinkBasicAnimation(myGame.linkTexture, linkDirection);
        }
    }
}
