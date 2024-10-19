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
                // HOTFIX - Call attack twice, one to change the state and one to throw the boomerang
                // Formerly would just change states than instantly change back
                myGame.LinkCharacter.BoomerangAttack();
                myGame.LinkCharacter.BoomerangAttack();
            }
    }
}
