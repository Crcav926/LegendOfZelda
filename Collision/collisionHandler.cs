using LegendOfZelda;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using LegendOfZelda.Command;
using System.Runtime.InteropServices;


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
                // Debug.WriteLine($"Handling {o1.GetType().Name} and {o2.GetType().Name} {direction} {c.overlap}");
            }
            Tuple<string,string, string> key = new Tuple<string, string, string>(o1.getCollisionType(), o2.getCollisionType(), direction);

            if (collisionDictionary.TryGetValue(key, out Type commandType))
            {
                // Reflection to instantiate the command and invoke its Execute method
                MethodInfo executeMethod = commandType.GetMethod("Execute");
                if (executeMethod != null)
                {
                    object commandInstance;
                    //Refactor this so I'm not calling getCOllisionType every time.
                    // we need to be able to pass in the correct object for the command we're trying to make...
                    // this is less messy but is a lot of decision making code need to ask if there's a way to 
                    //make it so that order doesn't matter?
                    if (o1 is Link)
                    {
                        if (o2 is Door || o2 is ClassItems || (o2 is Block) || o2 is PushableBlock)
                        {
                            //convoluted way of seeing if its pushable block
                            if (o2.getCollisionType() == "Obstacle")
                            {
                                    //if we can't push it treat as normal block
                                    commandInstance = Activator.CreateInstance(commandType, o1);
                            }
                            else if (o2.getCollisionType() == "Pushable")
                            {
                                //HAS TO BE o2 IN THE SECOND SLOT; The command doesn't care about link, only the block.
                                commandInstance = Activator.CreateInstance(commandType, o2);
                            }
                            else
                            {
                                ICollideable[] p = { o1, o2 };
                                commandInstance = Activator.CreateInstance(commandType, p);
                            }
                        }
                        else //Link and enemy link only passed in, Link and wall link only passed in
                        {
                        normBlock:
                            commandInstance = Activator.CreateInstance(commandType, o1);
                        }
                    } else if (o1 is IEnemy)
                    {
                        //enemy and item pass in both
                        if (o2.getCollisionType() == "Item")
                        {
                            ICollideable[] p = { o1, o2 };
                            commandInstance = Activator.CreateInstance(commandType, p);
                        } else if (o2 is Link) //enemy and link pass in link
                        {
                            commandInstance = Activator.CreateInstance(commandType, o2);
                        }
                        else { //only remaining is Enemy and wall?
                            commandInstance = Activator.CreateInstance(commandType, o1);
                        }

                    } else if (o1.getCollisionType() == "Projectile") {
                        //projectiles are movers
                        if (o2.getCollisionType() == "Player")
                        {
                            commandInstance = Activator.CreateInstance(commandType, o2);
                        }
                        else
                        {
                            commandInstance = Activator.CreateInstance(commandType, o1);
                        }
                    } else if (o1.getCollisionType() == "Item")
                    {
                        //item
                        //item and wall pass in item
                        if (o2.getCollisionType() == "Obstacle")
                        {
                            commandInstance = Activator.CreateInstance(commandType, o1);
                        }else if (o2 is IEnemy) //if enemy pass in enemy then item
                        {
                            ICollideable[] p = { o2, o1 };
                            commandInstance = Activator.CreateInstance(commandType, p);
                        }else {
                            Debug.WriteLine("Somehow Item collided with something that wasn't a wall or an enemy?");
                            commandInstance = Activator.CreateInstance(commandType, o1);
                        }
                    }else
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
               // Debug.WriteLine($"Couldn't Find {o1.GetType().Name} and {o2.GetType().Name} and {direction}");
               // Debug.WriteLine("No collision action found for the given types and direction.");
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
            Type[] obstacleTypes = { typeof(Block), typeof(collideWall) }; // add wall and door?

            // new dictionary that is more compact but im also ignoring items
            RegisterCollision("Player", "Enemy", "left", typeof(PlayerTakeDamage));
            RegisterCollision("Player", "Enemy", "right", typeof(PlayerTakeDamage));
            RegisterCollision("Player", "Enemy", "top", typeof(PlayerTakeDamage));
            RegisterCollision("Player", "Enemy", "bottom", typeof(PlayerTakeDamage));

            RegisterCollision("Enemy","Player", "left", typeof(PlayerTakeDamage));
            RegisterCollision("Enemy", "Player", "right", typeof(PlayerTakeDamage));
            RegisterCollision("Enemy", "Player", "top", typeof(PlayerTakeDamage));
            RegisterCollision("Enemy", "Player", "bottom", typeof(PlayerTakeDamage));

            RegisterCollision("Player", "Obstacle", "left", typeof(PlayerBlockLeft));
            RegisterCollision("Player", "Obstacle", "right", typeof(PlayerBlockRight));
            RegisterCollision("Player", "Obstacle", "top", typeof(PlayerBlockTop));
            RegisterCollision("Player", "Obstacle", "bottom", typeof(PlayerBlockBottom));

            RegisterCollision("Player", "Pushable", "left", typeof(PlayerPushableLeft));
            RegisterCollision("Player", "Pushable", "right", typeof(PlayerPushableRight));
            RegisterCollision("Player", "Pushable", "top", typeof(PlayerPushableDown));
            RegisterCollision("Player", "Pushable", "bottom", typeof(PlayerPushableUp));


            RegisterCollision("Enemy", "Obstacle", "left", typeof(EnemyBlockLeft));
            RegisterCollision("Enemy", "Obstacle", "right", typeof(EnemyBlockRight));
            RegisterCollision("Enemy", "Obstacle", "top", typeof(EnemyBlockTop));
            RegisterCollision("Enemy", "Obstacle", "bottom", typeof(EnemyBlockBottom));

            //link-door
            RegisterCollision("Player", "Door", "left", typeof(PlayerDoor));
            RegisterCollision("Player", "Door", "right", typeof(PlayerDoor));
            RegisterCollision("Player", "Door", "top", typeof(PlayerDoor));
            RegisterCollision("Player", "Door", "bottom", typeof(PlayerDoor));


            //item collisions
            RegisterCollision("Enemy", "Item", "left", typeof(EnemyItem));
            RegisterCollision("Enemy", "Item", "right", typeof(EnemyItem));
            RegisterCollision("Enemy", "Item", "top", typeof(EnemyItem));
            RegisterCollision("Enemy", "Item", "bottom", typeof(EnemyItem));

            RegisterCollision("Item","Enemy", "left", typeof(EnemyItem));
            RegisterCollision("Item", "Enemy", "right", typeof(EnemyItem));
            RegisterCollision("Item", "Enemy", "top", typeof(EnemyItem));
            RegisterCollision("Item", "Enemy", "bottom", typeof(EnemyItem));


            RegisterCollision("Item", "Obstacle", "left", typeof(ItemObstacle));
            RegisterCollision("Item", "Obstacle", "right", typeof(ItemObstacle));
            RegisterCollision("Item", "Obstacle", "top", typeof(ItemObstacle));
            RegisterCollision("Item", "Obstacle", "bottom", typeof(ItemObstacle));
            
            //when the player collides with static items add them to the their inventory
            RegisterCollision("Player", "statItem", "left", typeof(PlayerStatItem));
            RegisterCollision("Player", "statItem", "right", typeof(PlayerStatItem));
            RegisterCollision("Player", "statItem", "top", typeof(PlayerStatItem));
            RegisterCollision("Player", "statItem", "bottom", typeof(PlayerStatItem));


            //projectiles
            RegisterCollision("Projectile", "Player", "left", typeof(PlayerTakeDamage));
            RegisterCollision("Projectile", "Player", "right", typeof(PlayerTakeDamage));
            RegisterCollision("Projectile", "Player", "top", typeof(PlayerTakeDamage));
            RegisterCollision("Projectile", "Player", "bottom", typeof(PlayerTakeDamage));

            RegisterCollision("Projectile", "Obstacle", "left", typeof(ProjectileObstacle));
            RegisterCollision("Projectile", "Obstacle", "right", typeof(ProjectileObstacle));
            RegisterCollision("Projectile", "Obstacle", "top", typeof(ProjectileObstacle));
            RegisterCollision("Projectile", "Obstacle", "bottom", typeof(ProjectileObstacle));

        }
        private void RegisterCollision(string obj1, string obj2, string direction, Type command)
        {
            var key = new Tuple<string,string, string>(obj1, obj2, direction);
            collisionDictionary[key] = command;
        }

        
    }
}