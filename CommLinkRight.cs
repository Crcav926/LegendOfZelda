using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class CommLinkRight : ICommand
    {
        Game1 myGame;
        public CommLinkRight(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.LinkCharacter.sprite = new RightLinkSprite(myGame.linkTexture);
        }
    }
}
