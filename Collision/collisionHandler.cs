using LegendOfZelda;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;



namespace LegendOfZelda.Collision
{
    public class CollisionHandler
    {
        //Since each object probably has it's own position, that's how we tell which direction the collision was
        //you can either pass in the direction or have separate commands for moving link in different directions
        public enum CollisionType
        {
            PlayerBlockLeft,
            PlayerBlockRight,
            PlayerBlockTop,
            PlayerBlockBottom,

        }

        //Context is .NET stuff I'm unsure about .
       // private Dictionary<CollisionType, Context> collisionDictionary;

        private List<collObject> collisionList;
        private detectionManager collDetector;

        private Dictionary<(String, String,String), String> keyDictionary;

        public CollisionHandler(detectionManager collDet)
        {
            // Initialize the dictionary or plug in the one noelle is making

            //this is for determining the key/type of collision to plug into noelle's dictionary
            keyDictionary = new Dictionary<(String, String, String), String>();
            buildKeyDictionary();
           // collisionDictioanry = new Dictionary<CollisionType, Context>;
            //this lets any method in the class use the detector
            collDetector = collDet;
            collisionList = collDetector.getCollisions();
        }
        
        //This method will use the hitboxes of the obejcts passed to see where objects are in relation to each other
        //If the overlap rectangle has a higher Y value than X value chances are its side on and more X than Y is a top down collision  
        private String getDirection(collObject c)
        {
            string direction = "null";
            Rectangle overlap = c.overlap;
            Rectangle r1 = c.obj1.getHitbox();
            Rectangle r2 = c.obj2.getHitbox();
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
                    direction ="right";
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
            Debug.WriteLine($"{direction} collision");
            return direction;
        }

        public void update()
        {
            //Debug.WriteLine("Collision Handler updated\n");
            //get the list of collisions that needs to be handled
            collisionList = collDetector.getCollisions();
            List<collObject> removeList = new List<collObject>();
            while (collisionList.Count != 0)
            {
                //handle the collision then remove it from the list
                collObject hit = collisionList[0];
                HandleCollision(hit);

                collisionList.Remove(hit);
                
                Debug.WriteLine("Collision Handled\n");
                

            }


        }
        // this should only intake the coll object.
        //each pair of objects results in a certain type of collision
        // and from this collision type do the right command on the right objects
        private void HandleCollision(collObject c)
        {
            string direction = getDirection(c);
           
            //possible collideables are Player, Block, Weapon, Item, Enemy (and movable block but uh we aint doing that yet)
            ICollideable o1 = c.obj1;
            ICollideable o2 = c.obj2;

            //from the string and the objects make a key then reference the dctionary.
            (String, String, String) key = (o1.GetType().ToString(), o2.GetType().ToString(), direction);
            string finalKey = keyDictionary[key];
            Debug.WriteLine($"Resulting key: {finalKey}");

                

        }

        private void buildKeyDictionary()
        {
            // link abd block are types not ICollideables here 
            keyDictionary.Add(("LegendOfZelda.Link", "LegendOfZelda.Block", "left"), "LinkBlockLeft");
            keyDictionary.Add(("LegendOfZelda.Link", "LegendOfZelda.Block", "right"), "LinkBlockRight");
            keyDictionary.Add(("LegendOfZelda.Link", "LegendOfZelda.Block", "top"), "LinkBlockUp");
            keyDictionary.Add(("LegendOfZelda.Link", "LegendOfZelda.Block", "bottom"), "LinkBlockDown");
        }

    }
}