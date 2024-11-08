using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendOfZelda.LinkMovement;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class CommShootFire : ICommand
    {
            Link link;
            public CommShootFire(Link link)
            {
                this.link = link;
            }
            public void Execute()
            {
            this.link.FireAttack();
            this.link.FireAttack();
        }
    }
}
