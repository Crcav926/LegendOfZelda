using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class LinkBasicAnimation: ISprite
    {
        Texture2D linkTexture;
        List<Rectangle> spriteFrames;
        int currentFrame = 0;
        int totalFrames;
        double timePerFrame = 0.35; // Adjustable data
        double timeElapsed = 0;
        Vector2 currentDirection;

        public LinkBasicAnimation(Texture2D texture, Vector2 direction)
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

        public void Draw(SpriteBatch spriteBatch, Rectangle destination, Color color)
        { 
            spriteBatch.Draw(linkTexture, destination, spriteFrames[currentFrame], color);
        }

        public void SetSprite(int i)
        {

        }
        public int GetSprite()
        {
            return 0;
        }
    }
}
