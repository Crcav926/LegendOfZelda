using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Collision
{
    internal class hitbox
    {
        public Rectangle box;
        
        // initialize hitboxes
        public hitbox(string boxName)
        {
            // we should probably data drive this
            // later we this will say\
            // box = HitboxData.getRectangleData(boxName);
            box = new Rectangle();
        }

        public void update()
        {
            //I think we can put the position updates in here
            //we should ask Kirby about coupling problems with interrogating entities where they are.
            //alternatively command/methods that move items will also move their hitbox.
        }
    }
}
