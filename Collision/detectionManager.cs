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
                //Debug.WriteLine("First Hitbox retrieved");
                //check collision with all other moving hitboxes
                for (int j=i+1; j<movingHitboxes.Count; j++)
                {
                    //get second box
                    Rectangle secondHitbox = movingHitboxes[j].getHitbox();
                    //Debug.WriteLine("Second Hitbox retrieved");
                    //only collide with "bottom triangle"
                    // if first hitbox collides with the second hitbox
                    // i got this math from stack overflow ill fix later.
                    if (doIntersect(firstHitbox, secondHitbox))
                    {
                        //calculate where they collide and add that rectangle to the collides list
                        //this is temporary ill fix it later
                        Debug.WriteLine("Collision Detected");
                        Rectangle overlap = getOverlap(firstHitbox, secondHitbox);
                        collObject info = new collObject(movingHitboxes[i], movingHitboxes[j], overlap);

                        collisionList.Add(info);
                    }
                }
                //check collision with all stationary hitboxes
                for (int j = 0 ; j < stationaryHitboxes.Count; j++)
                {
                    Rectangle stationaryHitbox = stationaryHitboxes[j].getHitbox();
                    //Debug.WriteLine("Stationary Hitbox retrieved");
                    //only collide with "bottom triangle"
                    // if first hitbox collides with the second hitbox
                    if (doIntersect(firstHitbox, stationaryHitbox))
                    {
                        //calculate where they collide and add that rectangle to the collides list
                        //this is temporary ill fix it later
                        Debug.WriteLine("Collision Detected");
                        Rectangle overlap = getOverlap(firstHitbox, stationaryHitbox);
                        collObject info = new collObject(movingHitboxes[i], stationaryHitboxes[j], overlap);
                        collisionList.Add(info);
                    }
                
               }
            }
            var className = movingHitboxes[0].GetType().Name;
            var className2 = stationaryHitboxes[0].GetType().Name;
            //Debug.WriteLine($"In Collideable list: {className} {className2}");
        }
        private Boolean doIntersect(Rectangle rect1, Rectangle rect2)
        {
            // Check if one rectangle is to the left or right of the other
            if (rect1.X + rect1.Width < rect2.X || rect2.X + rect2.Width < rect1.X)
            {
                return false; // No horizontal overlap
            }

            // Check if one rectangle is above or below the other
            if (rect1.Y + rect1.Height < rect2.Y || rect2.Y + rect2.Height < rect1.Y)
            {
                return false; // No vertical overlap
            }

            // If there is no horizontal or vertical separation, the rectangles intersect
            return true;
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
