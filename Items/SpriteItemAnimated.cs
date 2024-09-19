using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class SpriteItemAnimated: ISprite
    {
        Texture2D itemTexture;
        List<Rectangle> spriteFrames;
        int currentFrame = 0;
        int totalFrames;
        double timePerFrame = 0.35; // Adjustable data
        double timeElapsed = 0;
        int index;

        public SpriteItemAnimated(Texture2D texture,int sIndex)
        {
            itemTexture = texture;
            index = sIndex;
            spriteFrames = SpriteItemData.GetRectangleData(index);
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
            spriteBatch.Draw(itemTexture, destination, spriteFrames[currentFrame], Color.White);
        }

        public void SetSprite(int i)
        {

        }
        public int GetSprite()
        {
            return index;
        }
    }
}
