using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class CommMoveHeldDown : ICommand
    {
        Game1 myGame;
        Vector2 linkDirection;
        Vector2 directionHold;
        public CommMoveHeldDown(Game1 game, Vector2 direction)
        {
            myGame = game;
            linkDirection = direction;

        }
        public void Execute()
        {
            directionHold = myGame.LinkCharacter.direction;
            /*
             * Checks if Link is moving, if he is not moving, make him move
             */
            if (myGame.LinkCharacter.linkState.getState() != "Move")
            {
                myGame.LinkCharacter.Move(directionHold);
                directionHold = linkDirection;
            }
            /*
             * Checks if the key press being executed is the key press we actually care about
             */
            if (linkDirection == directionHold)
            {
                myGame.LinkCharacter.Move(directionHold);
            }
        }
    }
}
