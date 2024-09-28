using LegendOfZelda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class PreviousSpriteCommand : ICommand
    {
        private Game1 game;

        public PreviousSpriteCommand(Game1 gameIn)
        {
            game = gameIn;
        }

        public void Execute()
        {
            game.currentSprite--;
            if (game.currentSprite < 0)
            {
                game.currentSprite = game.sprites.Count - 1; // Loop back to the last sprite
            }
        }
    }
}
