using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ObjectManagementExamples;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class Arrow : IItems, ICollideable
    {
        private bool isLingering;
        private double lingerTime = .5;
        double timeElapsed = 0;
        private Vector2 itemPosition;
        private Vector2 direction;
        private Vector2 origin;
        // Adjustable speed vector
        private Vector2 speed = new Vector2(Constants.ArrowSpeedX, Constants.ArrowSpeedY);
        // Adjustable Distance vector
        private Vector2 maxDistance = new Vector2(Constants.ArrowMaxDistanceX, Constants.ArrowMaxDistanceY);
        private Rectangle destination;
        private int vectorToInt;
        ItemSpriteFactory itemSpriteFactory;
        ISprite arrowSprite;
        Boolean collided = false;
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
            collided = false;
        }
        public void makeContact()
        {
            arrowSprite = itemSpriteFactory.CreateImpactSprite();
            isLingering = true;
            direction = new Vector2(0, 0);
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

            if (collided)
            {
                exists = false;
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
        public Rectangle getHitbox()
        {
            if (exists)
            {
                return destination;
            }
            else
            {
                return new Rectangle(0, 0, 0, 0);
            }
        }

        public String getCollisionType()
        {
            return "Item";
        }
    }
}
