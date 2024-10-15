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

    public void Execute()
    {
       
        if (context.Obj1 is Block1 block1)
        {
            Rectangle obj1Rec = block1.getHitbox();
            Rectangle collisionRect = context.CollisionRect;

            if (collisionRect.Height >= collisionRect.Width)
            {
                // Horizontal collision
                if (obj1Rec.X < collisionRect.Left)
                {
                    // Collided from left, push left
                    obj1Rec.X = obj1Rec.X - collisionRect.Width;
                }
                else
                {
                    // Collided from right, push right
                    obj1Rec.X = obj1Rec.X + collisionRect.Width;
                }
            }
            else
            {
                // Vertical collision
                if (obj1Rec.Y < collisionRect.Top)
                {
                    // Collided from top, push upward
                    obj1Rec.Y = obj1Rec.Y - collisionRect.Height;
                }
                else
                {
                    // Collided from bottom, push downward
                    obj1Rec.Y = obj1Rec.Y + collisionRect.Height;
                }
            }
        }
    }
}
