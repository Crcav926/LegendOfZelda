using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class Bomb : ILinkItem
    {
        Texture2D itemTexture;
        //list of rectangles that contains the frames
        List<Rectangle> spriteFrames;
        int currentFrame = 0;
        int totalFrames;
        //double timePerFrame = 0.3; // Adjustable data
        double timeElapsed = 0;
        private int width;
        private int height;
        private Vector2 itemPosition;
        private Vector2 direction;
        private Vector2 origin;
        // Adjustable speed vector
        private Vector2 offSet = new Vector2(Constants.BombOffsetX, Constants.BombOffsetY);
        private Rectangle destination;
        private Boolean exists;

        public Bomb(Texture2D texture, Vector2 bombDirection, Vector2 linkPosition, Boolean appear)
        {
            exists = appear;
            itemPosition = linkPosition;
            origin = linkPosition;
            itemTexture = texture;
            spriteFrames = LinkItemDictionary.GetRectangleData("Bomb");
            totalFrames = spriteFrames.Count;
            direction = bombDirection;
            itemPosition += direction * offSet;
        }

        public void Use()
        {
            exists = true;
        }

        public void Update(GameTime gameTime)
        {
            //note: i might've made the bombs really small, these used to be multiplied by 4. - TJ
            width = spriteFrames[currentFrame].Width;
            height = spriteFrames[currentFrame].Height;
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > Constants.BombTimePerFrame)
            {
                currentFrame++;
                destination = new Rectangle((int)itemPosition.X, (int)itemPosition.Y, width, height);
                if (currentFrame >= totalFrames)
                {
                    currentFrame = 0;
                    exists = false;
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
