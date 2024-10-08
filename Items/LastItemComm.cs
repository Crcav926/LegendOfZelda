
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
            foreach (ClassItems item in myGame.staticItems)
            {
                int i = item.GetSprite();
                i--;
                if (i < maxIndex && i >= 0)
                {
                    item.SetSprite(i);
                }
            }
        }
    }
}
