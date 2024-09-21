using LegendOfZelda.LinkMovement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
      public class Link : ILink
    {
        public ISprite linkSprite;
        public ILink linkState;
        public Rectangle destinationRectangle;
        public int xCord;
        public int yCord;
        public Vector2 position;
        public Vector2 direction;
        public Boolean animated;
        // public int direction; // 0 = left ; 1 = right ; 2 = up ; 3 = down
        public Link(Texture2D linkTexture)
        {
            animated = false;
            xCord = 400;
            yCord = 200;
            position = new Vector2(400, 200);
            direction = new Vector2(0, -1);
            linkSprite = new LinkIdleSprite(linkTexture, direction);
        }
        public void Move(Vector2 newDirection)
        {
            position += newDirection;

        }
        public void Update(GameTime gameTime)
        {
            linkSprite.Update(gameTime);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 60, 60);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            linkSprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}
