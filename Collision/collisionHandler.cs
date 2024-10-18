using LegendOfZelda;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using LegendOfZelda.Command;


namespace LegendOfZelda.Collision
{
    public class CollisionHandler
    {
        //Since each object probably has it's own position, that's how we tell which direction the collision was
        //you can either pass in the direction or have separate commands for moving link in different directions


        //Context is .NET stuff I'm unsure about .
        private List<collObject> collisionList;
        private detectionManager collDetector;

        private Dictionary<Tuple<Type, Type, string>, Type> collisionDictionary;

        public CollisionHandler(detectionManager collDet)
        {
            collisionDictionary = new Dictionary<Tuple<Type, Type, string>, Type>();
            BuildDictionary();  // Initialize the collision dictionary

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

                //Debug.WriteLine("Collision Handled\n");


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
            if (o1 is Link)
            {
                // Debug.WriteLine($"Handling {o1.GetType().Name} and {o2.GetType().Name}");
            }
            Tuple<Type, Type, string> key = new Tuple<Type, Type, string>(o1.GetType(), o2.GetType(), direction);

            if (collisionDictionary.TryGetValue(key, out Type commandType))
            {
                // Reflection to instantiate the command and invoke its Execute method
                MethodInfo executeMethod = commandType.GetMethod("Execute");
                if (executeMethod != null)
                {
                    object commandInstance;
                    // we need to be able to pass in the correct object for the command we're trying to make...

                    //b/c currently the first object is the one that responds
                    // this will definitely  need to be changed later

                    if (o1 is Link || o1 is IEnemy)
                    {
                        commandInstance = Activator.CreateInstance(commandType, o1);
                    }
                    else
                    {
                        Debug.WriteLine($"Object 1 is {o1.GetType().Name} o2 is {o2.GetType().Name}");
                        commandInstance = Activator.CreateInstance(commandType, o2);
                    }

                    executeMethod.Invoke(commandInstance, null);
                }
                else
                {
                    Debug.WriteLine("Execute method not found for the given command type.");
                }
            }
            else
            {
                Debug.WriteLine($"Couldn't Find {o1.GetType().Name} and {o2.GetType().Name} and {direction}");
                Debug.WriteLine("No collision action found for the given types and direction.");
            }

        }

        //all this could probably be moved to a level loader
        private void BuildDictionary()
        {
            //we need to condense this into using a getCollisionType method in the ICollideables but it works.
            Type playerType = typeof(Link);
            Type[] itemTypes = { typeof(Arrow), typeof(Bomb), typeof(Boomerang), typeof(Fire), typeof(Sword) };

            Type[] enemyTypes = { typeof(Aquamentus), typeof(BladeTrap), typeof(Gel), typeof(Goriya), typeof(Keese), typeof(Stalfol), typeof(Wallmaster), typeof(Zol) };
            Type[] projectileTypes = { typeof(Projectile), typeof(Fireball) }; // add stafol's sword?
            Type[] obstacleTypes = { typeof(Block) }; // add wall and door?

            //enemy-link collisions
            foreach (Type enemyType in enemyTypes)
            {
                //directions don't matter here
                RegisterCollision(playerType, enemyType, "left", typeof(PlayerTakeDamage));
                RegisterCollision(playerType, enemyType, "right", typeof(PlayerTakeDamage));
                RegisterCollision(playerType, enemyType, "top", typeof(PlayerTakeDamage));
                RegisterCollision(playerType, enemyType, "bottom", typeof(PlayerTakeDamage));

                //enemy-item collisions they dont do anything i think though lol
                foreach (Type itemType in itemTypes)
                {
                    //directions don't matter here
                    RegisterCollision(enemyType, itemType, "left", typeof(EnemyTakeDamage));
                    RegisterCollision(enemyType, itemType, "right", typeof(EnemyTakeDamage));
                    RegisterCollision(enemyType, itemType, "top", typeof(EnemyTakeDamage));
                    RegisterCollision(enemyType, itemType, "bottom", typeof(EnemyTakeDamage));
                }
            }

            //link-obstacle collisions
            foreach (Type obstacleType in obstacleTypes)
            {
                RegisterCollision(playerType, obstacleType, "left", typeof(PlayerBlockLeft));
                RegisterCollision(playerType, obstacleType, "right", typeof(PlayerBlockRight));
                RegisterCollision(playerType, obstacleType, "top", typeof(PlayerBlockTop));
                RegisterCollision(playerType, obstacleType, "bottom", typeof(PlayerBlockBottom));

                //enemy-obstacle collisions
                foreach (Type enemyType in enemyTypes)
                {
                    RegisterCollision(enemyType, obstacleType, "left", typeof(EnemyBlockLeft));
                    RegisterCollision(enemyType, obstacleType, "right", typeof(EnemyBlockRight));
                    RegisterCollision(enemyType, obstacleType, "top", typeof(EnemyBlockTop));
                    RegisterCollision(enemyType, obstacleType, "bottom", typeof(EnemyBlockBottom));
                }
            }

            //link-door
        }
        private void RegisterCollision(Type obj1, Type obj2, string direction, Type command)
        {
            var key = new Tuple<Type, Type, string>(obj1, obj2, direction);
            collisionDictionary[key] = command;
        }
    }
}