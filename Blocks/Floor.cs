using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    //unlike the walls, i actually think this is the best way to do floors.
    internal class Floor : ICollideable
    {
         private ISprite sprite;
        private Rectangle destinationRectangle;
        private Vector2 position;
        public Floor(Vector2 position, String blockName)
        {
            sprite = BlockSpriteFactory.Instance.CreateSprite(blockName);
            this.position = position;
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Constants.FloorWidth, Constants.FloorHeight);
        }
        public void Update(GameTime gameTime)
        {
            //floors dont update for now.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, destinationRectangle, Color.White); 
        }

        public Rectangle getHitbox()
        {
            return new Rectangle(0,0,0,0);
        }

        public string getCollisionType()
        {
            throw new NotImplementedException();
        }
  }
}