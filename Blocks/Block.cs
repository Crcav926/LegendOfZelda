using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace LegendOfZelda;
//as a quick note, the base of this code was taken from Link.cs, to maintain general code structure.
public class Block : IBlock , ICollideable //IBlock currently does nothing, but depending on what we do with collision, it may be necessary.
{
    private ISprite sprite;
    private Texture2D blockTexture;
    private Rectangle destinationRectangle;
    private int spriteIndex;
    private Vector2 position;
    public Block(Vector2 position, String blockName)
    {
        spriteIndex = 0;
        sprite = BlockSpriteFactory.Instance.CreateSprite(blockName);
        this.position = position;
        //arbitrary numbers, can change to where we want to put it.

        //spawn point of rectangle
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 50, 42);
    }
    public Rectangle getHitbox()
    {
        //put data in the the hitbox
        Rectangle hitbox = destinationRectangle;
        //Debug.WriteLine("Hitbox of block retrieved!");
        //Debug.WriteLine($"Rectangle hitbox:{destinationRectangle.X} {destinationRectangle.Y} {destinationRectangle.Width} {destinationRectangle.Height}");
        //return it
        return hitbox;
    }
    public void Draw(SpriteBatch spriteBatch)
    {

        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 50, 42);
        sprite.Draw(spriteBatch, destinationRectangle, Color.White);
    }

    public void Update(GameTime gameTime)
    {
        sprite.Update(gameTime); //this function currently does nothing. Do blocks even need to update?
    }
    public String getCollisionType()
    {
        return "Obstacle";
    }
}
