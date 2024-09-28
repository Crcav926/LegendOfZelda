using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class Arrow : ILinkItem
    {
        Texture2D itemTexture;
        //list of rectangles that contains the frames
        List<Rectangle> spriteFrames;
        int currentFrame;
        int totalFrames;
        double timePerFrame = 0.05; // Adjustable data
        double timeElapsed = 0;
        private int width;
        private int height;
        private Vector2 itemPosition;
        private Vector2 direction;
        private Vector2 origin;
        // Adjustable speed vector
        private Vector2 speed = new Vector2(5, 5);
        // Adjustable Distance vector
        private Vector2 maxDistance = new Vector2(150, 150);
        private Rectangle destination;
        private Boolean exists;
        // private ISprite itemSprite;

        public Arrow(Texture2D texture, Vector2 arrowDirection, Vector2 linkPosition, Boolean appear)
        {
            exists = appear;
            maxDistance *= arrowDirection;
            maxDistance += linkPosition;
            itemPosition = linkPosition;
            origin = linkPosition;
            itemTexture = texture;
            spriteFrames = LinkItemDictionary.GetRectangleData("Arrow");
            totalFrames = spriteFrames.Count;
            direction = arrowDirection;
            currentFrame = SpriteDirectionData.GetDirection(direction);
        }

        public void Use()
        {
            exists = true;
        }

        public void Update(GameTime gameTime)
        {
            width = spriteFrames[currentFrame].Width * 4;
            height = spriteFrames[currentFrame].Height * 4;
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            itemPosition += direction * speed;
            destination = new Rectangle((int)itemPosition.X, (int)itemPosition.Y, width, height);
            if(direction == new Vector2(0, 0))
            {
                // Get rid of impact frame
                exists = false;
            }
            if (itemPosition == maxDistance)
            {
                // Once arrow reaches its destination, switch to impact frame
                currentFrame = totalFrames-1;
                direction = new Vector2(0, 0);
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
