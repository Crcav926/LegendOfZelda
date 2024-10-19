using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    

    internal class Door: ICollideable
    {
        private Vector2 position;
        private Rectangle destinationRectangle;
        private String room;
        public String doorType;
        private ISprite sprite;
        public Door(Vector2 position, String doorType, String room, Vector2 newPos) 
        {
            this.position = position;
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 100, 88);
            sprite = BlockSpriteFactory.Instance.CreateSprite(doorType);
            this.room = room;
        }
        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
        public void Update(GameTime gameTime) 
        {
            // Nothing right now
        }
        public String getRoom() 
        {
            return room;
        }
        public String getNewPosition()
        {
            return room;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, destinationRectangle, Color.White);
        }
        public String getCollisionType()
        {
            return "Door";
        }
       
       
    }
}
