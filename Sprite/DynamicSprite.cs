using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public abstract class DynamicSprite : IEnemy
{
    public int currentFrame;
    public int totalFrames;
    public SpriteBatch spriteBatch;
    public Vector2 position;
    public Texture2D textures;
    public List<Rectangle> sourceRectangle;
    public Rectangle destinationRectangle;
    public DynamicSprite(SpriteBatch spriteBatch, Vector2 position, Texture2D textures, List<Rectangle> sourceRectangle)
    {
        this.spriteBatch = spriteBatch;
        this.position = position;
        this.textures = textures;
        this.sourceRectangle = sourceRectangle;
        currentFrame = 0;
        totalFrames = this.sourceRectangle.Count;
    }

    public abstract void Update(GameTime gameTime);

    public abstract void Draw(SpriteBatch spriteBatch);

    public abstract void takendamage();

    public abstract void attack();


}