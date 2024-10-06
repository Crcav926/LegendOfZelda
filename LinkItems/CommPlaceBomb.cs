using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendOfZelda.LinkMovement;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.LinkItems
{
    internal class CommPlaceBomb : ICommand
    {
            Game1 myGame;
            Vector2 linkDirection;
            public CommPlaceBomb(Game1 game)
            {
                myGame = game;
            }
            public void Execute()
            {
                linkDirection = myGame.LinkCharacter.direction;
                myGame.LinkCharacter.linkSprite = new LinkUseWeaponSprite(myGame.linkTexture, linkDirection);
                myGame.LinkCharacter.bomb = new Bomb(myGame.itemTexture, linkDirection, myGame.LinkCharacter.position, true);
            }
    }
}
