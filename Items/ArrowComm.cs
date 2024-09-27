using System;
using System.Collections.Generic;
using System.Linq;

using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class ArrowComm : ICommand
    {
        Game1 myGame;
        public ArrowComm(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            // creates moving item
            foreach (ClassItems item in myGame.items)
            {
                item.SetSprite(1);
                item.direction = 1;
            }
            //creates stationary item, maybe temporary since it's mostly for sprint 2
            foreach (ClassItems item in myGame.staticItems)
            {
                item.SetSprite(1);
            }
        }
    }
}
