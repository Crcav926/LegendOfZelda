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
        public int direction; // 0 = left ; 1 = right ; 2 = up ; 3 = down
        public Link(Texture2D linkTexture)
        {
            xCord = 400;
            yCord = 200;
            direction = 0;
            linkSprite = new LinkBasicAnimation(linkTexture, direction);
        }
        public void MoveUp()
        {
            linkState.MoveUp();
        }
        public void MoveDown()
        {

        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {
        }
        public void Update(GameTime gameTime)
        {
            linkSprite.Update(gameTime);
            destinationRectangle = new Rectangle(xCord, yCord, 60, 60);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            linkSprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}
