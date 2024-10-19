using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class Fire : ILinkItem
    {
        Texture2D itemTexture;
        //list of rectangles that contains the frames
        List<Rectangle> spriteFrames;
        int currentFrame;
        int totalFrames;
        double lingerTime = 0.50; // Adjustable data
        double timeElapsed = 0;
        private int width;
        private int height;
        private Vector2 itemPosition;
        private Vector2 direction;
        private Vector2 origin;
        // Adjustable speed vector
        private Vector2 speed = new Vector2(Constants.FireSpeedX, Constants.FireSpeedY);
        // Adjustable Distance vector
        private Vector2 maxDistance = new Vector2(Constants.FireMaxDistanceX, Constants.FireMaxDistanceY);
        private Rectangle destination;
        private Boolean exists;
        // private ISprite itemSprite;

        public Fire(Texture2D texture, Vector2 fireDirection, Vector2 linkPosition, Boolean appear)
        {
            exists = appear;
            maxDistance *= fireDirection;
            maxDistance += linkPosition;
            itemPosition = linkPosition;
            origin = linkPosition;
            itemTexture = texture;
            spriteFrames = LinkItemDictionary.GetRectangleData("Fire");
            totalFrames = spriteFrames.Count;
            direction = fireDirection;
            currentFrame = 0;
        }

        public void Use()
        {
            exists = true;
        }

        public void Update(GameTime gameTime)
        {
            //removed the * 4, may be really small now. - TJ
            width = spriteFrames[currentFrame].Width;
            height = spriteFrames[currentFrame].Height;
            itemPosition += direction * speed;
            destination = new Rectangle((int)itemPosition.X, (int)itemPosition.Y, width, height);
            if (itemPosition == maxDistance)
            {
                exists = false;
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
