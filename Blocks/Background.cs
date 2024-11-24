using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace LegendOfZelda;
//as a quick note, the base of this code was taken from Link.cs, to maintain general code structure.
public class Background : ICollideable 
{
    private ISprite sprite;
    private Rectangle destinationRectangle;
    private Vector2 position;

    public Background(Vector2 position, String blockName)
    {
        sprite = BlockSpriteFactory.Instance.CreateSprite(blockName);
        this.position = position;
        //arbitrary numbers, can change to where we want to put it.
        //spawn point of rectangle
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Constants.BlockWidth, Constants.BlockHeight);
    }
    public Rectangle getHitbox()
    {
        //put data in the the hitbox
        Rectangle hitbox = new Rectangle(0,0,0,0);
        //Debug.WriteLine("Hitbox of block retrieved!");
        //Debug.WriteLine($"Rectangle hitbox:{destinationRectangle.X} {destinationRectangle.Y} {destinationRectangle.Width} {destinationRectangle.Height}");
        //return it
        return hitbox;
    }
    public void Draw(SpriteBatch spriteBatch)
    {

        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Constants.BlockWidth, Constants.BlockHeight);
        sprite.Draw(spriteBatch, destinationRectangle, Color.White);
    }
    public void Update(GameTime gameTime)
    {
        sprite.Update(gameTime); //still does nothing most likely, but keeping it here. - TJ
    }
    public String getCollisionType()
    {
        return "Background";
    }
}
