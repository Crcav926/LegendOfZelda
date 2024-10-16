using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendOfZelda;
using Microsoft.Xna.Framework;

public class PushbackCollision : ICommand
{
    // default push back distance
    private const float pushbackDistance = 5f;
    private readonly CollisionContext context;

    public PushbackCollision(CollisionContext context)
    {
        this.context = context;
    }

    private Vector2 CalculatePushbackDirection(Vector2 objectPosition, Rectangle collisionRect)
    {
        Vector2 pushDirection = new Vector2();

        if (objectPosition.X < collisionRect.Left)
            pushDirection.X = -1;
        else if (objectPosition.X > collisionRect.Right)
            pushDirection.X = 1;

        if (objectPosition.Y < collisionRect.Top)
            pushDirection.Y = -1;
        else if (objectPosition.Y > collisionRect.Bottom)
            pushDirection.Y = 1;

        return pushDirection;
    }

    public void Execute()
    {
        if (context.Obj1 is BlockSprite block1)
        {
            Vector2 pushDirection = CalculatePushbackDirection(block1.Position, context.CollisionRect);
            block1.Position += pushDirection * pushbackDistance;
        }

        if (context.Obj2 is BlockSprite block2)
        {
            Vector2 pushDirection = CalculatePushbackDirection(block2.Position, context.CollisionRect);
            block2.Position += pushDirection * pushbackDistance;
        }
    }
}
