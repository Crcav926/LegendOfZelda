using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ObjectManagementExamples;
using System.Collections.Generic;
using System;
using System.IO;


namespace LegendOfZelda
{
    public class Sprite : ISprite
    {
        private Texture2D texture;
        private List<Rectangle> framesList;
        private double timePerFrame = 0.25; //TODO: Change based on desired animation speed
        public Rectangle destinationRectangle;
        public Vector2 position;
        private int currentFrameIndex;
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
