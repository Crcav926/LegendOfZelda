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
        Link link;
        Vector2 linkDirection;
        Vector2 directionHold;
        public CommMoveHeldDown(Link link, Vector2 direction)
        {
            this.link = link;
            linkDirection = direction;

        }
        public void Execute()
        {
            directionHold = this.link.direction;
            /*
             * Checks if Link is moving, if he is not moving, make him move
             */
            if (this.link.linkState.getState() != "Move")
            {
                this.link.Move(directionHold);
                directionHold = linkDirection;
            }
            /*
             * Checks if the key press being executed is the key press we actually care about
             */
            if (linkDirection == directionHold)
            {
                this.link.Move(directionHold);
            }
        }
    }
}
