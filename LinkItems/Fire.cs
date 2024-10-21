using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class Fire : IItems, ICollideable
    {
        double lingerTime = 1; // Adjustable data
        private double lingerElapsed = 0; // Timer for lingering
        private bool isLingering; // State to check if it's lingering
        private Vector2 itemPosition;
        private Vector2 direction;
        private Vector2 origin;
        // Adjustable Distance vector
        private Vector2 maxDistance;
        private Rectangle destination;
        public bool exists { get; set; }
        private ItemSpriteFactory itemSpriteFactory;
        ISprite fireSprite;
        public Fire( Vector2 fireDirection, Vector2 linkPosition)
        {
            itemSpriteFactory = ItemSpriteFactory.Instance;
            fireSprite = itemSpriteFactory.CreateFireSprite();
            exists = false ;
        }

        public void Use(Vector2 newDirection, Vector2 newPosition)
        {
            maxDistance = Constants.BoomerangMaxDistance;
            maxDistance *= newDirection;
            maxDistance += newPosition;
            itemPosition = newPosition;
            origin = newPosition;
            direction = newDirection;
            exists = true;
            isLingering = false;
            lingerElapsed = 0;
        }
        public void makeContact()
        {
            exists = false;
        }
        public void Update(GameTime gameTime)
        {
            fireSprite.Update(gameTime);
            itemPosition += direction * Constants.ArrowSpeed;

            if (!isLingering)
            {
                itemPosition += direction * Constants.ArrowSpeed;
                if (Vector2.Distance(itemPosition, maxDistance) <= 0)
                {
                    isLingering = true;
                    direction = Vector2.Zero;
                    
                }
            }

            if (isLingering)
            {
                lingerElapsed += gameTime.ElapsedGameTime.TotalSeconds;
                if (lingerElapsed >= lingerTime)
                {
                    exists = false; 
                }
            }
            destination = new Rectangle((int)itemPosition.X, (int)itemPosition.Y, Constants.MikuHeight, Constants.MikuHeight);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (exists) { 

                fireSprite.Draw(spriteBatch,destination,Color.White);
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
