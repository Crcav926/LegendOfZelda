using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    //largely taken from Items.
    internal class LastBlockComm : ICommand
    {
        Game1 myGame;
        public LastBlockComm(Game1 game)
        {
            myGame = game;;
        }
        public void Execute()
        {
            int i = myGame.block.GetSprite();
            i--;
            if (i < 0) i = SpriteBlockData.length - 1; //should allow blocks to loop.
            if (i < SpriteBlockData.length)
            {
                myGame.block.SetSprite(i);
            }
        }
    }
}
