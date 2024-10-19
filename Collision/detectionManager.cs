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

        //instead of the list just call handle
        //removable public List<collObject> collisionList;
        private CollisionHandler handler;

        //get an instance of the roomObjectManager
        

        public detectionManager(CollisionHandler collHandler)
        {
            // The object manager is currently not returning lists
            // unComment the add hitbox method and change the Lists to new lists to revert to old method.
            stationaryHitboxes = RoomObjectManager.Instance.getStandStills();
            movingHitboxes = RoomObjectManager.Instance.getMovers();
            //stationaryHitboxes = new List<ICollideable>();
            //movingHitboxes = new List<ICollideable>();
            if (RoomObjectManager.Instance.getMovers() == null)
            {
                Debug.WriteLine("Failed to retrieve moving Collideables List");
            }
            
            
            //Removable collisionList = new List<collObject> ();

            //lets other methods use the handler
            handler = collHandler;
        }

        //this is used by other classes to add their hitbox to the list that we're checking for collisions.
        public void addHitbox(ICollideable collideable, int type)
        {
            // 1 is moving otherwise is stationary
            if (type == 1)
            {
                //movingHitboxes.Add(collideable);
            }
            else
            {
                //stationaryHitboxes.Add(collideable);
            }
        }

        public void update()
        {
            if (RoomObjectManager.Instance.getStandStills().Count == 0)
            {
                Debug.WriteLine("No stationary hitboxes");
            }
            foreach (ICollideable mov in movingHitboxes)
            {
                Debug.WriteLine($"{mov.GetType().Name}");
            }
            //only moving items can initiate collision
            // so for all moving hitboxes
            for (int i = 0; i < RoomObjectManager.Instance.getMovers().Count; i++)
            {
                //get first hitbox
                Microsoft.Xna.Framework.Rectangle firstHitbox = RoomObjectManager.Instance.getMovers()[i].getHitbox();
                //Debug.WriteLine("First Hitbox retrieved");
                //check collision with all other moving hitboxes
                for (int j = i + 1; j < RoomObjectManager.Instance.getMovers().Count; j++)
                {
                    if (RoomObjectManager.Instance.getMovers()[i] is IEnemy && RoomObjectManager.Instance.getMovers()[j] is IEnemy)
                    {
                        continue;
                    }
                    //get second box
                    Microsoft.Xna.Framework.Rectangle secondHitbox = RoomObjectManager.Instance.getMovers()[j].getHitbox();
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
                        String direction = "null";
                        collObject info = new collObject(RoomObjectManager.Instance.getMovers()[i], RoomObjectManager.Instance.getMovers()[j], overlap, direction);
                        //get the direction
                        direction = getDirection(info);
                        //replace the null direction with the new direction.
                        info = new collObject(RoomObjectManager.Instance.getMovers()[i], RoomObjectManager.Instance.getMovers()[j], overlap, direction);
                        //collisionList.Add(info);
                        //directly handle instead 
                        handler.HandleCollision(info);
                    }

                }
                //check collision with all stationary hitboxes
                for (int j = 0; j < RoomObjectManager.Instance.getStandStills().Count; j++)
                {
                    Microsoft.Xna.Framework.Rectangle stationaryHitbox = RoomObjectManager.Instance.getStandStills()[j].getHitbox();
                    //Debug.WriteLine("Stationary Hitbox retrieved");
                    //only collide with "bottom triangle"
                    
                    
                        //calculate where they collide and add that rectangle to the collides list
                        //this is temporary ill fix it later
                        //Debug.WriteLine("Collision Detected");
                        Microsoft.Xna.Framework.Rectangle overlap = getOverlap(firstHitbox, stationaryHitbox);
                        if (overlap.X > 0 || overlap.Y > 0)
                        {
                            String direction = "null";
                            collObject info = new collObject(RoomObjectManager.Instance.getMovers()[i], RoomObjectManager.Instance.getStandStills()[j], overlap, direction);
                            direction = getDirection(info);
                            info = new collObject(RoomObjectManager.Instance.getMovers()[i], RoomObjectManager.Instance.getStandStills()[j], overlap, direction);
                            handler.HandleCollision(info);
                        }
                        
                }
            }
            // var className = movingHitboxes[0].GetType().Name;
            // var className2 = stationaryHitboxes[0].GetType().Name;
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
        private Microsoft.Xna.Framework.Rectangle getOverlap(Microsoft.Xna.Framework.Rectangle rect1, Microsoft.Xna.Framework.Rectangle rect2)
        {
            //This is alot messier than the old version, but the old version was lowkey pirated so...
            // convert to system.drawing rectangle and just call intersect lol.

            Microsoft.Xna.Framework.Rectangle overlap;
            System.Drawing.Rectangle r1 = new System.Drawing.Rectangle(rect1.X, rect1.Y, rect1.Width, rect1.Height);
            System.Drawing.Rectangle r2 = new System.Drawing.Rectangle(rect2.X, rect2.Y, rect2.Width, rect2.Height);

            System.Drawing.Rectangle rO;
            if (r1.IntersectsWith(r2))
            {
                rO = System.Drawing.Rectangle.Intersect(r1, r2);
                overlap = new Microsoft.Xna.Framework.Rectangle(rO.X, rO.Y, rO.Width, rO.Height);
            }
            else
            {
                overlap = new Microsoft.Xna.Framework.Rectangle(0, 0, 0, 0);
            }

            return overlap;

        }
        //This method will use the hitboxes of the obejcts passed to see where objects are in relation to each other
        //If the overlap rectangle has a higher Y value than X value chances are its side on and more X than Y is a top down collision  
        private String getDirection(collObject c)
        {
            string direction = "null";
            Microsoft.Xna.Framework.Rectangle overlap = c.overlap;
            Microsoft.Xna.Framework.Rectangle r1 = c.obj1.getHitbox();
            Microsoft.Xna.Framework.Rectangle r2 = c.obj2.getHitbox();
            if (overlap.Height > overlap.Width)
            {
                //assume side collision
                int r1X = r1.X;
                int r2X = r2.X;
                if (r2X > r1X)
                {
                    //if the first object is on the left
                    direction = "left";
                }
                else
                {
                    direction = "right";
                }
            }
            else
            {
                //assume top down collision
                int r1Y = r1.Y;
                int r2Y = r2.Y;
                if (r2Y > r1Y)
                {
                    //if the first object is above the second object
                    direction = "top";
                }
                else
                {
                    direction = "bottom";
                }
            }
            //Debug.WriteLine($"{direction} collision");
            return direction;
        }

        //not needed removed getCollision list

        private void addWalls()
        {
            // Walls are 100 pixels thick wide and 87 pixels thick tall
            // Dimensions of the rooms are 800 / 480

            Wall top = new Wall(new Microsoft.Xna.Framework.Rectangle(0, 0, 800, 87));
            Wall bot = new Wall(new Microsoft.Xna.Framework.Rectangle(0, 392, 800, 87));
            Wall left1 = new Wall(new Microsoft.Xna.Framework.Rectangle(0, 0, 100, 196));
            Wall left2 = new Wall(new Microsoft.Xna.Framework.Rectangle(0, 284, 100, 196));
            Wall right1 = new Wall(new Microsoft.Xna.Framework.Rectangle(700, 0, 100, 196));
            Wall right2 = new Wall(new Microsoft.Xna.Framework.Rectangle(700, 284, 100, 196));

            stationaryHitboxes.Add(top);
            stationaryHitboxes.Add(bot);   
            stationaryHitboxes.Add(left1);
            stationaryHitboxes.Add(left2);
            stationaryHitboxes.Add(right1);
            stationaryHitboxes.Add(right2);
           
        }
    }
}
