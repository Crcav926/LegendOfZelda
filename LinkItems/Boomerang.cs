using LegendOfZelda.LinkItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class Boomerang : IItems, ICollideable
    {
        
        private double timeElapsed;
        private Vector2 itemPosition;
        private Vector2 direction;
        private Vector2 origin;
        // Adjustable Distance vector
        private Vector2 maxDistance;
        private Rectangle destination;
        public bool exists { get; set; }
        ItemSpriteFactory itemSpriteFactory;
        ISprite boomerangSprite;
        Boolean collided = false;
        public Boomerang(Vector2 boomerangDirection, Vector2 linkPosition)
        {
            itemSpriteFactory = ItemSpriteFactory.Instance;
            boomerangSprite = itemSpriteFactory.CreateBoomerangSprite();
            Debug.WriteLine("I exist!");
            exists = false;
        }
        public void Use(Vector2 newDirection, Vector2 newPosition)
        {
            maxDistance = Constants.BoomerangMaxDistance;
            boomerangSprite = itemSpriteFactory.CreateBoomerangSprite();
            maxDistance *= newDirection;
            maxDistance += newPosition;
            itemPosition = newPosition;
            origin = newPosition;
            direction = newDirection;
            exists = true;
            collided = false;
        }
        public void makeContact()
        {
            boomerangSprite = itemSpriteFactory.CreateImpactSprite();
            collided = true;
        }
        public void Update(GameTime gameTime)
        {
            boomerangSprite.Update(gameTime);
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > Constants.BoomerangTimePerFrame)
            {
                itemPosition += direction * Constants.BoomerangSpeed;
                if(itemPosition == maxDistance)
                {

                    direction *= new Vector2(-1, -1);
                }
                if (itemPosition == origin)
                {
                    // If the Boomerang reached its max distance, get rid of it
                    exists = false;
                }
                if (collided)
                {
                    exists = false;
                }
                timeElapsed = 0;
            }
        }
        public void updatePosition(Vector2 linkPosition)
        {
            this.origin = linkPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (exists)
            {
                destination = new Rectangle((int)itemPosition.X, (int)itemPosition.Y, Constants.BoomerangWidth, Constants.BoomerangHeight);
                boomerangSprite.Draw(spriteBatch,destination,Color.White);
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
            // idk damage numbers right now
            return 1;
        }
        public String getCollisionType()
        {
            return "Item";
        }
    }
}
