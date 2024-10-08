﻿using Microsoft.Xna.Framework.Graphics;
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
        private double timePerFrame = 0.1; // fix later
        public Rectangle destinationRectangle;
        public Vector2 position;
        private int currentFrameIndex;
        private double timeElapsed;
        int currentFrame = 0;
        int totalFrames;

        // to scale up the sprites so they aren't tiny
        float scaleFactor = 3.5F;
        public Sprite(Texture2D texture, List<Rectangle> frames)
        {
            this.texture = texture;
            framesList = frames;
            totalFrames = framesList.Count;

        }
        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color)
        {
            float width = framesList[currentFrame].Width * scaleFactor;
            float height = framesList[currentFrame].Height * scaleFactor;
            destinationRectangle = new Rectangle(destinationRectangle.X, destinationRectangle.Y, (int)width, (int)height);
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
