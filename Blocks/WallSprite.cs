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
    //this is incredibly inefficient, but this is the easiest way I can think of to draw the walls without interfering with the hitboxes.
    internal class WallSprite : ICollideable
    {
         private ISprite sprite;
        private Rectangle destinationRectangle;
        private Vector2 position;
        public WallSprite(Vector2 position, String blockName)
        {
            sprite = BlockSpriteFactory.Instance.CreateSprite(blockName);
            this.position = position;
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Constants.WallsWidth, Constants.WallsHeight);
        }
        public void Update(GameTime gameTime)
        {
            //walls dont update for now.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, destinationRectangle, Color.White); 
        }

        public Rectangle getHitbox()
        {
            //this shouldn't be used
            return new Rectangle(0,0,0,0);
        }

        public string getCollisionType()
        {
            //this shouldn't be used
            throw new NotImplementedException();
        }
    }
}
