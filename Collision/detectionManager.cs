﻿using Microsoft.Xna.Framework;
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
                    if (movingHitboxes[i] is IEnemy && movingHitboxes[j] is IEnemy)
                    {
                        continue;
                    }
                    //get second box
                    Microsoft.Xna.Framework.Rectangle secondHitbox = movingHitboxes[j].getHitbox();
                    //Debug.WriteLine("Second Hitbox retrieved");
                    //only collide with "bottom triangle"
                    // if first hitbox collides with the second hitbox

                    
                    
                        //calculate where they collide and add that rectangle to the collides list
                        //this is temporary ill fix it later
                        //Debug.WriteLine("Collision Detected");
                    Microsoft.Xna.Framework.Rectangle overlap = getOverlap(firstHitbox, secondHitbox);

                    //this version got rid of doIntersect while the stationary one hasn't
                    //if there's overlap we collided so add to collision list.
                    if (overlap.X > 0 || overlap.Y > 0)
                    {
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
                        //Debug.WriteLine("Collision Detected");
                        Microsoft.Xna.Framework.Rectangle overlap = getOverlap(firstHitbox, stationaryHitbox);
                        collObject info = new collObject(movingHitboxes[i], stationaryHitboxes[j], overlap);
                        collisionList.Add(info);
                    }
                
               }
            }
            var className = movingHitboxes[0].GetType().Name;
            var className2 = stationaryHitboxes[0].GetType().Name;
            //Debug.WriteLine($"In Collideable list: {className} {className2}");
        }
        //this isn't being used anymore
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
        //this has replcaed do intersect by always calculating overlap idk if the overhead is worse or better though, needs testing
        private Microsoft.Xna.Framework.Rectangle getOverlap(Microsoft.Xna.Framework. Rectangle rect1, Microsoft.Xna.Framework. Rectangle rect2)
        {
            //This is alot messier than the old version, but the old version was lowkey pirated so...
            // convert to system.drawing rectangle and just call intersect lol.

            Microsoft.Xna.Framework.Rectangle overlap;
            System.Drawing.Rectangle r1 = new System.Drawing.Rectangle(rect1.X, rect1.Y, rect1.Width, rect1.Height);
            System.Drawing.Rectangle r2 = new System.Drawing.Rectangle(rect2.X, rect2.Y, rect2.Width, rect2.Height);

            System.Drawing.Rectangle rO;
            if (r1.IntersectsWith(r2))
            {
                rO =System.Drawing.Rectangle.Intersect(r1,r2);
                overlap =  new Microsoft.Xna.Framework.Rectangle(rO.X, rO.Y, rO.Width, rO.Height);
            }
            else
            {
                overlap = new Microsoft.Xna.Framework.Rectangle(0,0,0,0);
            }

            return overlap;
           
        }

        public List<collObject> getCollisions()
        {
            return collisionList;
        }
    }
}
