using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class Boomerang : ILinkItem
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
        public Boomerang(Vector2 boomerangDirection, Vector2 linkPosition)
        {
            itemSpriteFactory = ItemSpriteFactory.Instance;
            boomerangSprite = itemSpriteFactory.CreateBoomerangSprite();

            exists = false;
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
                destination = new Rectangle((int)itemPosition.X, (int)itemPosition.Y, Constants.BoomerangWidth, Constants.BoomerangHeight);
                if (itemPosition == origin)
                {
                    // If the Boomerang reached its max distance, get rid of it
                    exists = false;
                }
                timeElapsed = 0;
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (exists)
            {
                boomerangSprite.Draw(spriteBatch,destination,Color.White);
            }
        }
    }
}
