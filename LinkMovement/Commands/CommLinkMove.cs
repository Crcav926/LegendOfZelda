using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.LinkMovement
{
    internal class CommLinkMove : ICommand
    {
        Link link;
        Vector2 linkDirection;
        public CommLinkMove(Link link, Vector2 direction)
        {
            this.link = link;
            linkDirection = direction;

        }
        public void Execute()
        {
            this.link.setState(new LinkMoveState(this.link));
            this.link.Move(linkDirection);
        }
    }
}
