using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda;
//as a quick note, the base of this code was taken from Link.cs, to maintain general code structure.
public class Block
{
        public ISprite sprite;
        public Rectangle destinationRectangle;
        public int xCord;
        public int yCord;
        public Block(ISprite BlockSprite)
        {
            sprite = BlockSprite;
            xCord = 100;
            yCord = 300;
            //arbitrary numbers, can change to where we want to put it.
        }
    
    public void Draw(SpriteBatch spriteBatch)
    {
       sprite.Draw(spriteBatch, destinationRectangle);
    }

    public void Update(GameTime gameTime) //directly taken from Link.cs
    {
        sprite.Update(gameTime);
        destinationRectangle = new Rectangle(xCord, yCord, 32, 32);
    }
}
