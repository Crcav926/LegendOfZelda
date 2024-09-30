using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ObjectManagementExamples;
using System.Collections.Generic;
using System;
using System.IO;


namespace LegendOfZelda.LinkMovement
{
    internal class LinkSprite : ISprite
    {
        private  Texture2D texture;
        private List<Rectangle> framesList;
        private double timePerFrame = 1; // fix later
        private Rectangle destinationRectangle;
        private Animation animation;
        public Vector2 position;
        private int currentFrameIndex;
        private double timeElapsed;
        int currentFrame = 0;
        int totalFrames;
        public LinkSprite(Texture2D texture, List<Rectangle> sourceRectangleList, Vector2 postion)
        {
            this.texture = texture;
            this.position = postion; // update position
            framesList = sourceRectangleList;
            // Don't think it should be here, but it's on the backlog.
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64); // Fix magic num later
            totalFrames = framesList.Count;
            animation = new Animation(currentFrame, totalFrames, timePerFrame);
            File.AppendAllText("debug_log.txt", currentFrame.ToString() + "\n");
            File.AppendAllText("debug_log.txt", currentFrame.ToString() + "\n");
            File.AppendAllText("debug_log.txt", currentFrame.ToString());

            currentFrameIndex = animation.GetCurrentFrame();
            totalFrames = framesList.Count;

        }

        public Texture2D GetTexture()
        {
            return texture;
        }

        public Rectangle GetCurrentSourceRectangle()
        {
            return framesList[currentFrame];
        }
        public Rectangle GetDestinationRectangle(Vector2 newPosition)
        {
            destinationRectangle = new Rectangle((int)newPosition.X, (int)newPosition.Y, 64, 64);
            return destinationRectangle;
        }


        public void SetPosition(Vector2 position)
        {
            this.position = position;  // Update internal position

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destinationRectangle, framesList[animation.GetCurrentFrame()], Color.White);
        }

        public void Update(GameTime gameTime)
        {
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
            
            animation.Update(gameTime);
         
            animation.animationLogic();
            currentFrameIndex = animation.GetCurrentFrame();
        }
    }
}
