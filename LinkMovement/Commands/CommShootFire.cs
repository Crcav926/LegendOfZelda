using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendOfZelda.LinkMovement;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class CommShootFire : ICommand
    {
            Game1 myGame;
            Vector2 linkDirection;
            public CommShootFire(Game1 game)
            {
                myGame = game;
            }
            public void Execute()
            {
            myGame.LinkCharacter.FireAttack();
            myGame.LinkCharacter.FireAttack();
        }
    }
}
