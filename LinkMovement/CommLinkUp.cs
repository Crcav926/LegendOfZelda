using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class CommLinkUp : ICommand
    {
        Game1 myGame;
        public CommLinkUp(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.LinkCharacter.yCord -= 2;
            myGame.LinkCharacter.sprite = new LinkBasicMovement(myGame.linkTexture, 3);
        }
    }
}
