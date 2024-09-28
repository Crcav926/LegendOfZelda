﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class CommLinkUpM : ICommand
    {
        Game1 myGame;

        public CommLinkUpM(Game1 game)
        {
            myGame = game;
            
        }
        public void Execute()
        {
            myGame.LinkCharacter.yCord -= 1;

        }
    }
}
