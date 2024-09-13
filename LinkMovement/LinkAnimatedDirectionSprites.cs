using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class LinkBasicMovement: ISprite
    {
        Texture2D linkTexture;
        List<Rectangle> spriteFrames;
        int currentFrame = 0;
        int totalFrames;
        double timePerFrame = 0.5; // Adjustable data
        double timeElapsed = 0;
        int currentDirection;

        public LinkBasicMovement(Texture2D texture,int direction)
        {
            linkTexture = texture;
            currentDirection = direction;
            spriteFrames = SpriteRectangleData.GetRectangleData(currentDirection);
            totalFrames = spriteFrames.Count;
        }
        public void Update(GameTime gameTime)
        {

            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > timePerFrame)
            {
                currentFrame++;

                if (currentFrame >= totalFrames)
                {
                    currentFrame = 0;
                }
                timeElapsed = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destination)
        { 
            spriteBatch.Draw(linkTexture, destination, spriteFrames[currentFrame], Color.White);
        }
    }
}
