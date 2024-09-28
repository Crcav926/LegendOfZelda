﻿using LegendOfZelda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LegendOfZelda
{
    internal class NextSpriteCommand : ICommand
    {
        private Game1 game;

        public NextSpriteCommand(Game1 gameIn)
        {
            game = gameIn;
        }

        public void Execute()
        {
            game.currentSprite++;
            if (game.currentSprite >= game.sprites.Count)
            {
                game.currentSprite = 0; // Loop back to the first sprite
            }
        }
    }
}