using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class Sword : ILinkItem
    {
        Texture2D itemTexture;
        //list of rectangles that contains the frames
        List<Rectangle> spriteFrames;
        int currentFrame;
        int totalFrames;
        double timeOnScreen = 0.40; // Adjustable data
        double timeElapsed = 0;
        private int width;
        private int height;
        private Vector2 itemPosition;
        private Vector2 direction;
        private Vector2 origin;
        // Adjustable speed vector
        private Vector2 offSet = new Vector2(24, 24);
        // Adjustable Distance vector
        private Vector2 maxDistance = new Vector2(150, 150);
        private Rectangle destination;
        private Boolean exists;
        // private ISprite itemSprite;

        public Sword(Texture2D texture, Vector2 swordDirection, Vector2 linkPosition, Boolean appear)
        {
            exists = appear;
            maxDistance *= swordDirection;
            maxDistance += linkPosition;
            itemPosition = linkPosition;
            origin = linkPosition;
            itemTexture = texture;
            spriteFrames = LinkItemDictionary.GetRectangleData("Sword");
            totalFrames = spriteFrames.Count;
            direction = swordDirection;
            currentFrame = SpriteDirectionData.GetDirection(direction);
            itemPosition += direction * offSet;

        }

        public void Use()
        {
            exists = true;
        }

        public void Update(GameTime gameTime)
        {
            width = spriteFrames[currentFrame].Width * 4;
            height = spriteFrames[currentFrame].Height * 4;
            destination = new Rectangle((int)itemPosition.X, (int)itemPosition.Y, width, height);
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > timeOnScreen)
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
