using LegendOfZelda;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

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


    public CollisionHandler()
    {
        // Initialize the dictionary with ICommand instances as keys
        collisionCommands = new Dictionary<ICommand, CollisionType>
        {
            { new StopCollision(context), CollisionType.Stop },
            { new PushbackCollision(context), CollisionType.Pushback },
            { new ShowEffectCollision(context), CollisionType.ShowEffect }
        };
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