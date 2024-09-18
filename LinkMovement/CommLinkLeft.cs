using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class CommLinkLeft : ICommand
    {
        Game1 myGame;
        public CommLinkLeft(Game1 game)
        {
            myGame = game;
            sprite = myGame.LinkCharacter.sprite;
            myGame.LinkCharacter.sprite = new LinkBasicMovement(myGame.linkTexture, 0);
            
            
        }
        public void Execute()
        {
            myGame.LinkCharacter.xCord -= 2;
            
        }
    }
}
