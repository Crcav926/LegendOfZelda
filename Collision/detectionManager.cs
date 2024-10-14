using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ObjectManagementExamples;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Collision
{
    public class detectionManager
    {
        private List<ICollideable> stationaryHitboxes;
        private List<ICollideable> movingHitboxes;
        public List<collObject> collisionList;


        public detectionManager()
        {
            stationaryHitboxes = new List<ICollideable>();
            movingHitboxes = new List<ICollideable>();
            collisionList = new List<collObject> ();
        }

        //this is used by other classes to add their hitbox to the list that we're checking for collisions.
        public void addHitbox(ICollideable collideable, int type)
        {
            // 1 is moving otherwise is stationary
            if (type == 1)
            {
                movingHitboxes.Add(collideable);
            }
            else
            {
                stationaryHitboxes.Add(collideable);
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
                    // if first hitbox collides with the second hitbox
                    // i got this math from stack overflow ill fix later.
                    if (firstHitbox.X < (secondHitbox.X+secondHitbox.Width) && (firstHitbox.X+firstHitbox.Width) > secondHitbox.X &&
    firstHitbox.Y < (secondHitbox.Y +secondHitbox.Height) && (firstHitbox.Y+firstHitbox.Height) > secondHitbox.Y)
                    {
                        //calculate where they collide and add that rectangle to the collides list
                        //this is temporary ill fix it later
                        Rectangle overlap = getOverlap(firstHitbox, secondHitbox);
                        collObject info = new collObject(movingHitboxes[i], movingHitboxes[j], overlap);

                        collisionList.Add(info);
                    }
                }
                //check collision with all stationary hitboxes
                for (int j = i + 1; j < stationaryHitboxes.Count; j++)
                {
                    Rectangle stationaryHitbox = stationaryHitboxes[j].getHitbox();
                    //only collide with "bottom triangle"
                    // if first hitbox collides with the second hitbox
                    if (firstHitbox.X < (stationaryHitbox.X + stationaryHitbox.Width) && (firstHitbox.X + firstHitbox.Width) > stationaryHitbox.X &&
    firstHitbox.Y < (stationaryHitbox.Y + stationaryHitbox.Height) && (firstHitbox.Y + firstHitbox.Height) > stationaryHitbox.Y)
                    {
                        //calculate where they collide and add that rectangle to the collides list
                        //this is temporary ill fix it later
                        Rectangle overlap = getOverlap(firstHitbox, stationaryHitbox);
                        collObject info = new collObject(movingHitboxes[i], stationaryHitboxes[j], overlap);
                        collisionList.Add(info);
                    }
                
               }
            }
        }
        private Rectangle getOverlap(Rectangle rect1, Rectangle rect2)
        {
            // Find the maximum of the left edges (x)
            int x1 = Math.Max(rect1.Left, rect2.Left);
            // Find the minimum of the right edges (x + width)
            int x2 = Math.Min(rect1.Right, rect2.Right);
            // Find the maximum of the top edges (y)
            int y1 = Math.Max(rect1.Top, rect2.Top);
            // Find the minimum of the bottom edges (y + height)
            int y2 = Math.Min(rect1.Bottom, rect2.Bottom);

            // Check if the calculated rectangle is valid (non-empty)
            if (x1 < x2 && y1 < y2)
            {
                // Return the intersection rectangle
                return new Rectangle(x1, y1, x2 - x1, y2 - y1);
            }

            // No intersection, return empty rectangle
            return new Rectangle(0, 0, 0, 0);
        }
        public List<collObject> getCollisions()
        {
            return collisionList;
        }
    }
}
