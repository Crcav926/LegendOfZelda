using LegendOfZelda;
using Microsoft.Xna.Framework;

public class StopCollision : ICommand
{
    private CollisionContext context;

    // DO I realy need game1 here - no effect on global state
    public StopCollision(CollisionContext context)
    {
        this.context = context;
    }

    public void Execute()
    {
        if (context.Obj1 is BlockSprite block1)
        {
            block1.Velocity = Vector2.Zero;
        }

        if (context.Obj2 is BlockSprite block2)
        {
            block2.Velocity = Vector2.Zero;
        }
    }
}