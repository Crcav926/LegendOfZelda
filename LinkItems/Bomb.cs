using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class Bomb : IItems, ICollideable
    {
        private bool isLingering;
        double bombStillTime = 2;
        double timeElapsed = 0;
        double lingerTime = 0.5;
        private Vector2 itemPosition;
        private Vector2 direction;
        // Adjustable speed vector
        private Vector2 offSet = new Vector2(Constants.BombOffsetX, Constants.BombOffsetY);
        private Rectangle destination;
        private ItemSpriteFactory itemSpriteFactory;
        public bool exists { get; set; }
        ISprite bombSprite;
        ISprite explosionSprite;
        public Bomb(Vector2 bombDirection, Vector2 linkPosition)
        {
            itemSpriteFactory = ItemSpriteFactory.Instance;
            bombSprite = itemSpriteFactory.CreateBombSprite();
            explosionSprite = itemSpriteFactory.CreateExplosionSprite();
            exists = false;
        }

        public void Use(Vector2 newDirection, Vector2 newPosition)
        {
            bombSprite = itemSpriteFactory.CreateBombSprite();
            explosionSprite = itemSpriteFactory.CreateExplosionSprite();
            itemPosition = newPosition;
            direction = newDirection;
            itemPosition += newDirection * offSet;
            isLingering = false;
            exists = true;
            destination = new Rectangle((int)itemPosition.X, (int)itemPosition.Y, Constants.MikuWidth, Constants.MikuHeight);
        }
        public void makeContact()
        {
            exists = false;
        }
        public void Update(GameTime gameTime)
        {

            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            bombSprite.Update(gameTime);
            explosionSprite.Update(gameTime);
            if (!isLingering)
            {
                if (timeElapsed > bombStillTime)
                {
                    isLingering = true ;
                    timeElapsed = 0;
                }
            }

            if (isLingering)
            {
                if (timeElapsed >= lingerTime)
                {
                    isLingering = false;
                    timeElapsed = 0;
                    exists = false;
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            if (exists)
            {
                if (!isLingering)
                {
                    bombSprite.Draw(spriteBatch, destination, Color.White);
                }
                else
                {
                    explosionSprite.Draw(spriteBatch, destination, Color.White);
                }
                
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
