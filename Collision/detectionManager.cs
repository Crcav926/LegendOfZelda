using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Security.Cryptography.X509Certificates;

namespace LegendOfZelda.Collision
{
    public class detectionManager
    {
        private List<Rectangle> stationaryHitboxes;
        private List<Rectangle> movingHitboxes;
        public List<Rectangle> collisions;

        public struct overlaps
        {
            public overlaps()
            {
                ICollideable obj1;
                ICollideable obj2;
                Rectangle overlap;
            }

        }

        public detectionManager()
        {
            stationaryHitboxes = new List<Rectangle>();
            movingHitboxes = new List<Rectangle>();
            collisions= new List<Rectangle> ();
        }

        //this is used by other classes to add their hitbox to the list that we're checking for collisions.
        public void addHitbox(Rectangle hitbox, int type)
        {
            if (type == 1)
            {
                movingHitboxes.Add(hitbox);
            }
            else
            {
                stationaryHitboxes.Add(hitbox);
            }
        }

        public void update()
        {
            //only moving items can initiate collision
            // so for all moving hitboxes
            for (int i = 0; i < movingHitboxes.Count; i++)
            {
                //get first hitbox
                Rectangle firstHitbox = movingHitboxes[i];
                //check collision with all other moving hitboxes
                for (int j=i+1; j<movingHitboxes.Count; j++)
                {
                    //get second box
                    Rectangle secondHitbox = movingHitboxes[j];
                    //only collide with "bottom triangle"
                    // if first hitbox collides with the second hitbox
                    // i got this math from stack overflow ill fix later.
                    if (firstHitbox.X < (secondHitbox.X+secondHitbox.Width) && (firstHitbox.X+firstHitbox.Width) > secondHitbox.X &&
    firstHitbox.Y < (secondHitbox.Y +secondHitbox.Height) && (firstHitbox.Y+firstHitbox.Height) > secondHitbox.Y)
                    {
                        //calculate where they collide and add that rectangle to the collides list
                        //this is temporary ill fix it later
                        Rectangle collision = new Rectangle(0, 0, 0, 0);

                        collisions.Add(collision);
                    }
                }
                //check collision with all stationary hitboxes
                for (int j = i + 1; j < stationaryHitboxes.Count; j++)
                {
                    Rectangle stationaryHitbox = stationaryHitboxes[j];
                    //only collide with "bottom triangle"
                    // if first hitbox collides with the second hitbox
                    if (firstHitbox.X < (stationaryHitbox.X + stationaryHitbox.Width) && (firstHitbox.X + firstHitbox.Width) > stationaryHitbox.X &&
    firstHitbox.Y < (stationaryHitbox.Y + stationaryHitbox.Height) && (firstHitbox.Y + firstHitbox.Height) > stationaryHitbox.Y)
                    {
                        //calculate where they collide and add that rectangle to the collides list
                        //this is temporary ill fix it later
                        Rectangle collision = new Rectangle(0, 0, 0, 0);

                        collisions.Add(collision);
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
