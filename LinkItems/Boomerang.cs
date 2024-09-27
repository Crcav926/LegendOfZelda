using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class Boomerang : ILinkItem
    {
        Texture2D itemTexture;
        //list of rectangles that contains the frames
        List<Rectangle> spriteFrames;
        int currentFrame = 0;
        int totalFrames;
        double timePerFrame = 0.1; // Adjustable data
        double timeElapsed = 0;
        private int width;
        private int height;
        private Vector2 itemPosition;
        private Vector2 direction;
        private Vector2 origin;
        private Vector2 speed = new Vector2(10, 10);
        private Vector2 maxDistance = new Vector2(100, 100);
        private Rectangle destination;

        public Boomerang(Texture2D texture, Vector2 boomerangDirection, Vector2 linkPosition)
        {
            maxDistance *= boomerangDirection;
            maxDistance += linkPosition;
            itemPosition = linkPosition;
            origin = linkPosition;
            itemTexture = texture;
            spriteFrames = LinkItemDictionary.GetRectangleData("Boomerang2");
            totalFrames = spriteFrames.Count;
            direction = boomerangDirection;
        }

        public void Use(SpriteBatch spriteBatch, GameTime gameTime)
        {
        }

        public void Update(GameTime gameTime)
        {
            width = spriteFrames[currentFrame].Width * 4;
            height = spriteFrames[currentFrame].Height * 4;
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > timePerFrame)
            {
                currentFrame++;
                itemPosition += direction * speed;
                if(itemPosition == maxDistance)
                {
                    direction *= new Vector2(-1, -1);
                }
                destination = new Rectangle((int)itemPosition.X, (int)itemPosition.Y, width, height);
                if (itemPosition == origin)
                {
                    direction = new Vector2(0, 0);
                    destination = new Rectangle(0, 0, 0, 0);
                }
                if (currentFrame >= totalFrames)
                {
                    currentFrame = 0;
                }
                timeElapsed = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //create a new destination rectangle of the appropriate size
            spriteBatch.Draw(itemTexture, destination, spriteFrames[currentFrame], Color.White);
        }
    }
}
