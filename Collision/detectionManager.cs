using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ObjectManagementExamples;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LegendOfZelda.Collision
{
    public class detectionManager
    {
        //these lists should be moved to the obejct manager later
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
                Microsoft.Xna.Framework.Rectangle firstHitbox = movingHitboxes[i].getHitbox();
                //Debug.WriteLine("First Hitbox retrieved");
                //check collision with all other moving hitboxes
                for (int j=i+1; j<movingHitboxes.Count; j++)
                {
                    //get second box
                    Microsoft.Xna.Framework.Rectangle secondHitbox = movingHitboxes[j].getHitbox();
                    //Debug.WriteLine("Second Hitbox retrieved");
                    //only collide with "bottom triangle"
                    // if first hitbox collides with the second hitbox
                    // i got this math from stack overflow ill fix later.
                    if (doIntersect(firstHitbox, secondHitbox))
                    {
                        //calculate where they collide and add that rectangle to the collides list
                        //this is temporary ill fix it later
                        Debug.WriteLine("Collision Detected");
                        Microsoft.Xna.Framework.Rectangle overlap = getOverlap(firstHitbox, secondHitbox);
                        collObject info = new collObject(movingHitboxes[i], movingHitboxes[j], overlap);

                        collisionList.Add(info);
                    }
                }
                //check collision with all stationary hitboxes
                for (int j = 0 ; j < stationaryHitboxes.Count; j++)
                {
                    Microsoft.Xna.Framework.Rectangle stationaryHitbox = stationaryHitboxes[j].getHitbox();
                    //Debug.WriteLine("Stationary Hitbox retrieved");
                    //only collide with "bottom triangle"
                    // if first hitbox collides with the second hitbox
                    if (doIntersect(firstHitbox, stationaryHitbox))
                    {
                        //calculate where they collide and add that rectangle to the collides list
                        //this is temporary ill fix it later
                        Debug.WriteLine("Collision Detected");
                        Microsoft.Xna.Framework.Rectangle overlap = getOverlap(firstHitbox, stationaryHitbox);
                        collObject info = new collObject(movingHitboxes[i], stationaryHitboxes[j], overlap);
                        collisionList.Add(info);
                    }
                
               }
            }
            // var className = movingHitboxes[0].GetType().Name;
            // var className2 = stationaryHitboxes[0].GetType().Name;
            //Debug.WriteLine($"In Collideable list: {className} {className2}");
        }
        private Boolean doIntersect(Microsoft.Xna.Framework.Rectangle rect1, Microsoft.Xna.Framework.Rectangle rect2)
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
        private Microsoft.Xna.Framework.Rectangle getOverlap(Microsoft.Xna.Framework. Rectangle rect1, Microsoft.Xna.Framework. Rectangle rect2)
        {
            //This is alot messier than the old version, but the old version was lowkey pirated so...
            // convert to system.drawing rectangle and just call intersect lol.
            int r1x = rect1.X;
            int r1y = rect1.Y;
            int r1w = rect1.Width;
            int r1h = rect1.Height;

            int r2x = rect2.X;  
            int r2y = rect2.Y;
            int r2w = rect2.Width;
            int r2h = rect2.Height;

            System.Drawing.Rectangle r1 = new System.Drawing.Rectangle(r1x, r1y, r1w, r1h);
            System.Drawing.Rectangle r2 = new System.Drawing.Rectangle(r2x, r2y, r2w, r2h);

            System.Drawing.Rectangle rO = new System.Drawing.Rectangle(0, 0, 0, 0);
            if (r1.IntersectsWith(r2))
            {
                rO =System.Drawing.Rectangle.Intersect(r1,r2);
            }

            int rOx = rO.X;
            int rOy = rO.Y; 
            int rOw = rO.Width;
            int rOh = rO.Height;

            Microsoft.Xna.Framework.Rectangle overlap = new Microsoft.Xna.Framework.Rectangle(rOx, rOy, rOw, rOh);

            return overlap;
           
        }
        public List<collObject> getCollisions()
        {
            return collisionList;
        }
    }
}
