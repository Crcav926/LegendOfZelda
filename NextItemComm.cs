using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class NextItemComm : ICommand
    {
        Game1 myGame;
        public NextItemComm(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            int i = myGame.items.GetSprite();
            i++;
            myGame.items.SetSprite(i);
        }
    }
}
