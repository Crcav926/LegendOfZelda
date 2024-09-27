using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.LinkItems
{
    internal class CommThrowBoomerang: ICommand
    {
            Game1 myGame;
            Vector2 linkDirection;
            public CommThrowBoomerang(Game1 game)
            {
                myGame = game;
            }
            public void Execute()
            {
                linkDirection = myGame.LinkCharacter.direction;
                myGame.LinkCharacter.item = new Boomerang(myGame.itemTexture, linkDirection, myGame.LinkCharacter.position);
            }
    }
}
