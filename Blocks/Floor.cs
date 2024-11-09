using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class Floor : IBlock, ICollideable
    {
        private ISprite sprite;
        private Rectangle destinationRectangle;
        private Vector2 position;
        public Floor(Vector2 position, String floorName)
        {
            sprite = BlockSpriteFactory.Instance.CreateSprite(floorName);
            this.position = position;
            //spawn point of rectangle
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Constants.FloorSizeX, Constants.FloorSizeY);
        }
        public Rectangle getHitbox()
        {
            // Has no hitbox
            return new Rectangle(0, 0, 0, 0);
        }
        public void Update(GameTime gameTime)
        {
            // Doesn't update
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, destinationRectangle, Color.White);
        }
        public String getCollisionType()
        {
            return "Floor";
        }

    }
}
