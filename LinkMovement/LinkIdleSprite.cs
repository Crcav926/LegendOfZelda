using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.LinkMovement
{
    internal class LinkIdleSprite : ISprite
    {
        Texture2D linkTexture;
        List<Rectangle> spriteFrames;
        int currentFrame = 0;
        int totalFrames;
        double timePerFrame = 0.35; // Adjustable data
        double timeElapsed = 0;
        Vector2 currentDirection;

        public LinkIdleSprite(Texture2D texture, Vector2 direction)
        {
            linkTexture = texture;
            currentDirection = direction;
            spriteFrames = SpriteRectangleData.GetRectangleData(currentDirection);
            totalFrames = spriteFrames.Count;
        }

        public void Update(GameTime gameTime)
        {

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
