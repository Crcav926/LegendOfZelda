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
        public Door(Vector2 position) 
        {
            this.position = position;
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 98, 88);
        }
        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
        public void Update(GameTime gameTime) 
        {
            // Nothing right now
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // Make later.
        }
        public String getCollisionType()
        {
            return "Door";
        }
    }
}
