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

        //both not needed anymore
        //private List<collObject> collisionList;
        //private detectionManager collDetector;

        private Dictionary<Tuple<string,string, string>, Type> collisionDictionary;

        public CollisionHandler()
        {
            collisionDictionary = new Dictionary<Tuple<string,string, string>, Type>();
            BuildDictionary();  // Initialize the collision dictionary

            // collisionDictioanry = new Dictionary<CollisionType, Context>;
            //this lets any method in the class use the detector
            //collDetector = collDet;
            //collisionList = collDetector.getCollisions();
        }

        
        //this actually shouldnt be needed anymore. I removed the update method.
            

        // this should only intake the coll object.
        //each pair of objects results in a certain type of collision
        // and from this collision type do the right command on the right objects
        public void HandleCollision(collObject c)
        {

            //possible collideables are Player, Block, Weapon, Item, Enemy (and movable block but uh we aint doing that yet)
            ICollideable o1 = c.obj1;
            ICollideable o2 = c.obj2;
            String direction = c.direction;
            if (o1 is Link)
            {
                // Debug.WriteLine($"Handling {o1.GetType().Name} and {o2.GetType().Name}");
            }
            Tuple<string,string, string> key = new Tuple<string, string, string>(o1.getCollisionType(), o2.getCollisionType(), direction);

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
            //this is unused but im leaving it just in case?
            Type playerType = typeof(Link);
            Type[] itemTypes = { typeof(Arrow), typeof(Bomb), typeof(Boomerang), typeof(Fire), typeof(Sword) };

            Type[] enemyTypes = { typeof(Aquamentus), typeof(BladeTrap), typeof(Gel), typeof(Goriya), typeof(Keese), typeof(Stalfol), typeof(Wallmaster), typeof(Zol) };
            Type[] projectileTypes = { typeof(Projectile), typeof(Fireball) }; // add stafol's sword?
            Type[] obstacleTypes = { typeof(Block), typeof(Wall) }; // add wall and door?

            // new dictionary that is more compact but im also ignoring items
            RegisterCollision("Player", "Enemy", "left", typeof(PlayerTakeDamage));
            RegisterCollision("Player", "Enemy", "right", typeof(PlayerTakeDamage));
            RegisterCollision("Player", "Enemy", "top", typeof(PlayerTakeDamage));
            RegisterCollision("Player", "Enemy", "bottom", typeof(PlayerTakeDamage));

            RegisterCollision("Player", "Obstacle", "left", typeof(PlayerBlockLeft));
            RegisterCollision("Player", "Obstacle", "right", typeof(PlayerBlockRight));
            RegisterCollision("Player", "Obstacle", "top", typeof(PlayerBlockTop));
            RegisterCollision("Player", "Obstacle", "bottom", typeof(PlayerBlockBottom));

            RegisterCollision("Enemy", "Obstacle", "left", typeof(EnemyBlockLeft));
            RegisterCollision("Enemy", "Obstacle", "right", typeof(EnemyBlockRight));
            RegisterCollision("Enemy", "Obstacle", "top", typeof(EnemyBlockTop));
            RegisterCollision("Enemy", "Obstacle", "bottom", typeof(EnemyBlockBottom));

            //link-door
        }
        private void RegisterCollision(string obj1, string obj2, string direction, Type command)
        {
            var key = new Tuple<string,string, string>(obj1, obj2, direction);
            collisionDictionary[key] = command;
        }
    }
}