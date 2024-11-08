using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
public class BlockSprite : ISprite
{
    private Texture2D blockTexture;
    private int index;
    private Rectangle sourceRectangle;
    public Vector2 position;

        public Rectangle hitboxPosition;

    public BlockSprite(Texture2D texture, int spriteIndex)
    {
        blockTexture = texture;
        index = spriteIndex;
        sourceRectangle = SpriteBlockData.GetRectangleData(spriteIndex);
            // I added position so I can get its hitbox.
            hitboxPosition = new Rectangle(0, 0, 0, 0);
    }

    public Vector2 Velocity { get; internal set; }
    public Vector2 Position { get; internal set; }

    public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color)
    {
            hitboxPosition = destinationRectangle;
        spriteBatch.Draw(blockTexture, destinationRectangle, sourceRectangle, Color.White);
    }
    public Rectangle getHitbox()
    {
        //put data in the the hitbox
        Rectangle hitbox = new Rectangle((int)hitboxPosition.X, (int)hitboxPosition.Y,hitboxPosition.Width, hitboxPosition.Height);
        //return it
        return hitbox;
    }
    public int GetSprite()
    {
        //as of now, should never be called.
        throw new NotImplementedException();
    }

    public void SetSprite(int i)
    {
        //as of now, should never be called.
        throw new NotImplementedException();
    }

    public void Update(GameTime gameTime)
    {
        //I'm not updating hitboxes right now b/c this is only for the stationary blocks
        //the moving block will probably have it's own class
        //I don't think anything needs to be here?
        //Blocks don't really move so nothing should update.
    }

}
}
