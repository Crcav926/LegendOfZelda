using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class BoomerangComm : ICommand
    {
        Game1 myGame;
        public BoomerangComm(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.items.SetSprite(3);
            
        }
    }
}
