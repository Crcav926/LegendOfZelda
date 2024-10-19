using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ObjectManagementExamples;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class Arrow : ILinkItem
    {
        private bool isLingering;
        private double lingerTime = .5;
        double timePerFrame = 0.05; // Adjustable data
        double timeElapsed = 0;
        private Vector2 itemPosition;
        private Vector2 direction;
        private Vector2 origin;
        // Adjustable speed vector
        // Adjustable Distance vector
        private Vector2 maxDistance;
        private Rectangle destination;
        private int vectorToInt;
        ItemSpriteFactory itemSpriteFactory;
        ISprite arrowSprite;
        public bool exists { get;  set; }


        public Arrow(Vector2 arrowDirection, Vector2 linkPosition)
        {
            itemSpriteFactory = ItemSpriteFactory.Instance;
            vectorToInt = SpriteDirectionData.GetDirection(arrowDirection);
            arrowSprite = itemSpriteFactory.CreateArrowSprite(vectorToInt);
            exists = false;
        }
        public void Use(Vector2 newDirection, Vector2 newPosition)
        {
            vectorToInt = SpriteDirectionData.GetDirection(newDirection);
            arrowSprite = itemSpriteFactory.CreateArrowSprite(vectorToInt);
            maxDistance = Constants.ArrowMaxDistance;
            maxDistance *= newDirection;
            maxDistance += newPosition;
            itemPosition = newPosition;
            origin = newPosition;
            direction = newDirection;
            isLingering = false;
            exists = true;
        }
        public void Update(GameTime gameTime)
        {
            arrowSprite.Update(gameTime);
            itemPosition += direction * Constants.ArrowSpeed;
               
            if (!isLingering && itemPosition == maxDistance)
            {
                
                arrowSprite = itemSpriteFactory.CreateArrowSprite(vectorToInt);
                if (Vector2.Distance(itemPosition, maxDistance) <= 0)
                {
                    isLingering = true;
                    direction = Vector2.Zero;

                }
            }

            if (isLingering)
            {
                timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
                arrowSprite = itemSpriteFactory.CreateImpactSprite();
                if (timeElapsed >= lingerTime)
                {
                    exists = false;
                    isLingering = false;
                    timeElapsed = 0;
                }
            }

            destination = new Rectangle((int)itemPosition.X, (int)itemPosition.Y, 20, 20);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (exists)
            {
                arrowSprite.Draw(spriteBatch, destination, Color.White);
            }

        }
    }
}
