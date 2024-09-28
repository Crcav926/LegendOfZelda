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
            // sprites are really small so I'm scaling them up by 4x
            int scale = 4;
            width = spriteFrames[currentFrame].Width * scale;
            height = spriteFrames[currentFrame].Height * scale;

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
            //create a new destination rectangle of the appropriate size
            // thats why ClassItems created a 60x60 because it gets replaced anyway.
            Rectangle dest = new Rectangle(destination.X, destination.Y, width, height);
            spriteBatch.Draw(itemTexture, dest, spriteFrames[currentFrame], color);
        }

        public void SetSprite(int i)
        {
            // this doesn't do anything right now.
        }
        public int GetSprite()
        {
            //this is here, but no one calls it
            // this only returns index because it needs to return something for syntax reasons.
            return index;
        }
    }
}
