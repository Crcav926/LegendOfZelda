using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class Sword : IItems, ICollideable
    {
        //double timeOnScreen = .3; // Adjustable data
        double timeElapsed = 0;
        private Vector2 itemPosition;
        private Vector2 direction;
        private Vector2 origin;
        // Adjustable speed vector
        private Vector2 offSet;
        // Adjustable Distance vector
        //private Vector2 maxDistance = new Vector2(150, 150);
        private Rectangle destination;
        private ItemSpriteFactory itemSpriteFactory;
        ISprite swordSprite;
        private int vectorToInt;
        public bool exists { get; set; }
        // private ISprite itemSprite;
        

        public Sword( Vector2 swordDirection, Vector2 linkPosition)
        {
            itemSpriteFactory = ItemSpriteFactory.Instance;
            direction = swordDirection;
            vectorToInt = SpriteDirectionData.GetDirection(swordDirection);
            swordSprite = itemSpriteFactory.CreateSwordSprite(vectorToInt);
            exists = false;
             
        }
        public void Use(Vector2 newDirection, Vector2 newPosition)
        {
            offSet = new Vector2(Constants.SwordOffsetX * newDirection.X, Constants.SwordOffsetY * newDirection.Y);
            vectorToInt = SpriteDirectionData.GetDirection(newDirection);
            swordSprite = itemSpriteFactory.CreateSwordSprite(vectorToInt);
            itemPosition = newPosition;
            origin = newPosition;
            direction = newDirection;
            exists = true;
            
        }
        public void makeContact()
        {
            exists = false;
        }
        public void Update(GameTime gameTime)
        {
            itemPosition = origin + offSet;
            swordSprite.Update(gameTime);
            destination = new Rectangle((int)itemPosition.X, (int)itemPosition.Y, Constants.SwordWidth, Constants.SwordHeight);

            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > Constants.SwordTimeOnScreen)
            {
                exists = false;
                timeElapsed = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (exists)
            {
                destination = new Rectangle((int)itemPosition.X, (int)itemPosition.Y, 40, 40);
                swordSprite.Draw(spriteBatch, destination, Color.White);
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
        public int getDamage()
        {
            // for wood for now we can do an if else depending on the sword
            return 1;
        }
        public String getCollisionType()
        {
            return "Item";
        }
    }
}
