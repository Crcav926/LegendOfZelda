using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Collision
{
    public class hitbox
    {
        //for now store stationary as 0 and moving as 1
        int type;
        
        // initialize hitboxes
        public hitbox(detectionManager manager, int type)
        {
            //the constructor is how the hitbox knows where to get the position and size.
            //this will be added after the refactor since we would have to change it anyway.

            //add it to the list
            manager.addHitbox(this,type);
        }

        public Rectangle getHitbox()
        {
            //call this method to get the position and size of a hitbox at a certain time, hitbox does not store this data
            // this is just to prevent errors, it will be changed after refactor done
            // for example position= enetity.position and size = entity.sprite.size
            Rectangle box = new Rectangle(0, 0, 0, 0);
            return box;
        }
    }
}
