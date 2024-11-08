using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ObjectManagementExamples;
using System.Collections.Generic;
using System;
using System.IO;
using System.Diagnostics;


namespace LegendOfZelda
{
    public class Sprite : ISprite
    {
        private Texture2D texture;
        private List<Rectangle> framesList;
        private double timePerFrame = 0.25; //TODO: Change based on desired animation speed
        public Rectangle destinationRectangle;
        public Vector2 position;
        private double timeElapsed;
        int currentFrame = 0;
        int totalFrames;
        public Sprite(Texture2D texture, List<Rectangle> frames)
        {
            this.texture = texture;
            framesList = frames;
            totalFrames = framesList.Count;

        }
        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color)
        {
            //This will draw stuff proportionally to the source rectangles just needs the scale factor.
            //Rectangle destinationRectangle2 = new Rectangle(destinationRectangle.X, destinationRectangle.Y, framesList[currentFrame].Width, framesList[currentFrame].Height);
            spriteBatch.Draw(texture, destinationRectangle, framesList[currentFrame], color);
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
    }
}
