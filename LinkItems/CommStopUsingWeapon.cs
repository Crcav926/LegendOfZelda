using LegendOfZelda.LinkMovement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.LinkItems
{
    internal class CommStopUsingWeapon: ICommand
    {
        Game1 myGame;
        Vector2 linkDirection;

        public CommStopUsingWeapon(Game1 game)
        {
            myGame = game;

        }
        public void Execute()
        {
            
        }
    }
}
