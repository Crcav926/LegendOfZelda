using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.LinkMovement
{
    internal class LinkUseWeaponSprite : ISprite
    {
        Texture2D linkTexture;
        List<Rectangle> spriteFrames;
        int currentFrame = 0;
        int totalFrames;
        double timePerFrame = 0.35; // Adjustable data
        double timeElapsed = 0;
        Vector2 currentDirection;

        public LinkUseWeaponSprite(Texture2D texture, Vector2 direction)
        {
            linkTexture = texture;
            currentDirection = direction;
            spriteFrames = AttackRectangleData.GetRectangleData(currentDirection);
            totalFrames = spriteFrames.Count;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destination)
        {
            spriteBatch.Draw(linkTexture, destination, spriteFrames[currentFrame], Color.White);
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
