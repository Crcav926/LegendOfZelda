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
        if (context.Obj1 is Block block1)
        {
            // Block movement for Obj1 (no further code is needed, as we simply want it to stop here)
            // No velocity or direction provided
        }
    }
}