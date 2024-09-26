using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class SpriteItemAnimated: ISprite
    {
        Texture2D itemTexture;
        //list of rectangles that contains the frames
        List<Rectangle> spriteFrames;
        int currentFrame = 0;
        int totalFrames;
        double timePerFrame = 0.3; // Adjustable data
        double timeElapsed = 0;
        int index;
        private int width;
        private int height;

        public SpriteItemAnimated(Texture2D texture,int sIndex)
        {
            itemTexture = texture;
            index = sIndex;
            spriteFrames = SpriteItemData.GetRectangleData(index);
            totalFrames = spriteFrames.Count;
        }

        public void Update(GameTime gameTime)
        {
            // change the destination rectangle size if needed.
            width = spriteFrames[currentFrame].Width * 4;
            height = spriteFrames[currentFrame].Height * 4;
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
            //create a new destination rectangle of the appropriate size
            Rectangle dest = new Rectangle(destination.X, destination.Y, width, height);
            spriteBatch.Draw(itemTexture, dest, spriteFrames[currentFrame], Color.White);
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
