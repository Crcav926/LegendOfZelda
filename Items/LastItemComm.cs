
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
        int maxIndex;
        public LastItemComm(Game1 game)
        {
            myGame = game;
            maxIndex = SpriteItemData.ListLength();
        }
        public void Execute()
        {
           //this is no longer needed functionality
        }
    }
}
