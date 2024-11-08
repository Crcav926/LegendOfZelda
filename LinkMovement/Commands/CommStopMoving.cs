using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.LinkMovement
{
    internal class CommStopMoving : ICommand
    {
        Link link;

        public CommStopMoving(Link link, Vector2 direction)
        {
            this.link = link;

        }
        public void Execute()
        {
            this.link.Idle();
        }

    }
}
