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
        //double timePerFrame = 0.05; // Adjustable data
        double timeElapsed = 0;
        private int width;
        private int height;
        private Vector2 itemPosition;
        private Vector2 direction;
        private Vector2 origin;
        // Adjustable speed vector
        private Vector2 speed = new Vector2(Constants.BoomerangSpeedX, Constants.BoomerangSpeedY);
        // Adjustable Distance vector
        private Vector2 maxDistance = new Vector2(Constants.BoomerangMaxDistanceX, Constants.BoomerangMaxDistanceY);
        private Rectangle destination;
        private Boolean exists;

        public Boomerang(Texture2D texture, Vector2 boomerangDirection, Vector2 linkPosition, Boolean appear)
        {
            exists = appear;
            maxDistance *= boomerangDirection;
            maxDistance += linkPosition;
            itemPosition = linkPosition;
            origin = linkPosition;
            itemTexture = texture;
            spriteFrames = LinkItemDictionary.GetRectangleData("Boomerang2");
            totalFrames = spriteFrames.Count;
            direction = boomerangDirection;
        }

        public void Use()
        {
            exists = true;
        }

        public void Update(GameTime gameTime)
        {
            //same as bombs, i might've made these really small. - TJ
            width = spriteFrames[currentFrame].Width;
            height = spriteFrames[currentFrame].Height;
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > Constants.BoomerangTimePerFrame)
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
                    // If the Boomerang reached its max distance, get rid of it
                    exists = false;
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
            if (exists)
            {
                spriteBatch.Draw(itemTexture, destination, spriteFrames[currentFrame], Color.White);
            }
            //create a new destination rectangle of the appropriate size
        }
    }
}
