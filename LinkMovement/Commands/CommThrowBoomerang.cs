using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendOfZelda.LinkMovement;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.LinkItems
{
    internal class CommThrowBoomerang: ICommand
    {
            Game1 myGame;
            public CommThrowBoomerang(Game1 game)
            {
                myGame = game;
            }
            public void Execute()
            {
                myGame.LinkCharacter.Attack();
            }
    }
}
