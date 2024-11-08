using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendOfZelda.LinkMovement;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.LinkItems
{
    internal class CommUseSword : ICommand
    {
            Game1 myGame;
            public CommUseSword(Game1 game)
            {
                myGame = game;
            }
            public void Execute()
            {
                myGame.LinkCharacter.SwordAttack();
                myGame.LinkCharacter.SwordAttack();
            }
    }
}
