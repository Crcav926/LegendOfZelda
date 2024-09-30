using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.LinkMovement
{
    public class Animation
    {
        private int currentFrame;
        private double timePerFrame;
        private int totalFrames;
        private double timeElapsed;

        public Animation( int currentFrame, int totalFrames, double timePerFrame)
        {
            this.currentFrame = currentFrame;
            this.totalFrames = totalFrames;
            this.timePerFrame = timePerFrame;

        }

        public void Update(GameTime gameTime)
        {
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            animationLogic();
        }
        public void animationLogic()
        {
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
        public int GetCurrentFrame()
        {
            return currentFrame;
        }

    }
}
