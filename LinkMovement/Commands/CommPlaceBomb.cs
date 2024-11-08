using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendOfZelda.LinkMovement;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.LinkItems
{
    internal class CommPlaceBomb : ICommand
    {
        Link link;
        public CommPlaceBomb(Link link)
        {
            this.link = link;
        }
        public void Execute()
        {
            this.link.BombAttack();
            this.link.BombAttack();
        }
    }
    
}
