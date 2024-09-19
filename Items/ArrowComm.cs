using System;
using System.Collections.Generic;
using System.Linq;
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
           myGame.items.SetSprite(1);
           myGame.items.direction = 1;
            
       
        }
    }
}
