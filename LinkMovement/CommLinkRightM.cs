using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class CommLinkRightM : ICommand
    {
        Game1 myGame;
        public CommLinkRightM(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.LinkCharacter.xCord += 1;
            
           
        }
    }
}
