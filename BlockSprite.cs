using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda;

public class BlockSprite : ISprite
{
    Texture2D blockTexture;
    Rectangle sourceRectangle;
    Rectangle destinationRectangle;

    public BlockSprite(Texture2D texture)
    {
        blockTexture = texture;
        sourceRectangle = new Rectangle(984, 11, 16, 16);
    }
    public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
    {
        spriteBatch.Draw(blockTexture, destinationRectangle, sourceRectangle, Color.White);
    }

    public void Update(GameTime gameTime)
    {

    }
}
