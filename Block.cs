using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda;
//as a quick note, the base of this code was taken from Link.cs, to maintain general code structure.
public class Block : IBlock //IBlock currently does nothing, but depending on what we do with collision, it may be necessary.
{
        private ISprite sprite;
        private Texture2D blockTexture;
        private Rectangle destinationRectangle;
        private int spriteIndex;
        private int xCord;
        private int yCord;
        public Block(Texture2D texture)
        {
            blockTexture = texture;
            spriteIndex = 0;
            sprite = new BlockSprite(texture, spriteIndex);
            xCord = 100;
            yCord = 300;
            //arbitrary numbers, can change to where we want to put it.
        }
    
    public void Draw(SpriteBatch spriteBatch)
    {
       sprite.Draw(spriteBatch, destinationRectangle);
    }

    public void Update(GameTime gameTime)
    {
        sprite.Update(gameTime); //this function currently does nothing. Do blocks even need to update?
        destinationRectangle = new Rectangle(xCord, yCord, 32, 32);
    }

    // Perhaps a little weird to create a new BlockSprite each time we set sprite, but it works.
    public void SetSprite(int i)
    { 
        spriteIndex = i;
        sprite = new BlockSprite(blockTexture, spriteIndex);
    }

    internal int GetSprite()
    {
        return spriteIndex;
    }
}
