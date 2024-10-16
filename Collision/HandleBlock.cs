using LegendOfZelda;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;



namespace LegendOfZelda.Collision
{
    public class CollisionHandler
    {

        public enum CollisionType
        {
            Stop,
            Pushback,
            ShowEffect

        }

        private readonly CollisionContext context;
        private readonly Dictionary<ICommand, CollisionType> collisionCommands;

        private List<collObject> collisionList;
        private detectionManager collDetector;

        public CollisionHandler(detectionManager collDet)
        {
            // Initialize the dictionary with ICommand instances as keys
            collisionCommands = new Dictionary<ICommand, CollisionType>
        {
            { new StopCollision(context), CollisionType.Stop },
            { new PushbackCollision(context), CollisionType.Pushback },
            { new ShowEffectCollision(context), CollisionType.ShowEffect }
        };
            //this lets any method in the class use the detector
            collDetector = collDet;
            collisionList = collDetector.getCollisions();
        }
        public void update()
        {
            //Debug.WriteLine("Collision Handler updated\n");
            //get the list of collisions that needs to be handled
            collisionList = collDetector.getCollisions();
            List<collObject> removeList = new List<collObject>();
            foreach (collObject hit in collisionList)
            {
                //handle the collision then remove it from the list
                ICollideable o1 = hit.obj1;
                ICollideable o2 = hit.obj2;
                Rectangle collisionRect = hit.overlap;
                HandleCollision(o1, o2, collisionRect, CollisionType.Stop);
                removeList.Add(hit);
                
                Debug.WriteLine("Collision Handled\n");
                

            }
            foreach (collObject finished in removeList)
            {
                collisionList.Remove(finished);
            }

        }
        public void HandleCollision(object obj1, object obj2, Rectangle collisionRect, CollisionType collisionType)
        {
            // Update the context with the current collision data
            context.Obj1 = obj1;
            context.Obj2 = obj2;
            context.CollisionRect = collisionRect;

            // Find the command associated with the specified CollisionType and execute it
            foreach (var kvp in collisionCommands)
            {
                if (kvp.Value == collisionType)
                {
                    kvp.Key.Execute();
                    // should I break here?
                    break;
                }
            }
        }


    }
}