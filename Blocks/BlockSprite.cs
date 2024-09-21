using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda;

public class BlockSprite : ISprite
{
    Texture2D blockTexture;
    int index;
    Rectangle sourceRectangle;

    public BlockSprite(Texture2D texture, int spriteIndex)
    {
        blockTexture = texture;
        index = spriteIndex;
        sourceRectangle = SpriteBlockData.GetRectangleData(spriteIndex);
    }
    public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
    {
        spriteBatch.Draw(blockTexture, destinationRectangle, sourceRectangle, Color.White);
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

    }
}
