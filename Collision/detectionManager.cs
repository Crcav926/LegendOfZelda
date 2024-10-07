using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace LegendOfZelda.Collision
{
    public class detectionManager
    {
        private List<hitbox> stationaryHitboxes;
        private List<hitbox> movingHitboxes;
        public List<Rectangle> collisions;

        public detectionManager()
        {
            stationaryHitboxes = new List<hitbox>();
            movingHitboxes = new List<hitbox>();
            collisions= new List<Rectangle> ();
        }

        //this is used by other classes to add their hitbox to the list that we're checking for collisions.
        public void addHitbox(hitbox box, int type)
        {
            if (type == 1)
            {
                movingHitboxes.Add(box);
            }
            else
            {
                stationaryHitboxes.Add(box);
            }
        }

        public void update()
        {
            //only moving items can initiate collision
            // so for all moving hitboxes
            for (int i = 0; i < movingHitboxes.Count; i++)
            {
                //get first hitbox
                Rectangle firstHitbox = movingHitboxes[i].getHitbox();
                //check collision with all other moving hitboxes
                for (int j=i+1; j<movingHitboxes.Count; j++)
                {
                    //get second box
                    Rectangle secondHitbox = movingHitboxes[j].getHitbox();
                    //only collide with "bottom triangle"
                    // if theres a collision
                    if (firstHitbox.IntersectsWith(secondHitbox))
                    {
                        //add it to the collides list.
                        Rectangle intersection = Rectangle.Intersect(firstHitbox, secondHitbox);
                        collisions.Add(intersection);
                    }
                }
                //check collision with all stationary hitboxes
                for (int j = i + 1; j < stationaryHitboxes.Count; j++)
                {
                    Rectangle stationaryHitbox = stationaryHitboxes[j].getHitbox();
                    //only collide with "bottom triangle"
                    // if theres a collision
                    if (firstHitbox.IntersectsWith(stationaryHitbox))
                    {
                        //add it to the collides list.
                        Rectangle intersection = Rectangle.Intersect(firstHitbox, stationaryHitbox);
                        collisions.Add(intersection);
                    }
                }
            }
        }

        public List<Rectangle> getCollisions()
        {
            return collisions;
        }
    }
}
