using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class LastItemComm : ICommand
    {
        Game1 myGame;
        public LastItemComm(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            int i = myGame.items.GetSprite();
            i--;
            myGame.items.SetSprite(i);
        }
    }
}
