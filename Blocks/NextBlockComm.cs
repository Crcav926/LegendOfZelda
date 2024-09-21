using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    //largely taken from Items.
    internal class NextBlockComm : ICommand
    {
        Game1 myGame;
        public NextBlockComm(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            int i = myGame.block.GetSprite();
            i++;
            if (i >= SpriteBlockData.length) i=0; //should allow the blocks to loop.
            if (i < SpriteBlockData.length)
            {
                myGame.block.SetSprite(i);
            }    
        }
    }
}
