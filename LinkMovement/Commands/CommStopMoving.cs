﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.LinkMovement
{
    internal class CommStopMoving : ICommand
    {
        Game1 myGame;

        public CommStopMoving(Game1 game, Vector2 direction)
        {
            myGame = game;

        }
        public void Execute()
        {
            myGame.LinkCharacter.Idle();
        }

    }
}
