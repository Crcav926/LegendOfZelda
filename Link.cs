using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class Link
    {
        public ISprite sprite;
        public Rectangle destinationRectangle;
        public int xCord;
        public int yCord;
        public Link(ISprite LinkSprite)
        {
            sprite = LinkSprite;
            xCord = 400;
            yCord = 200;
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            destinationRectangle = new Rectangle(xCord, yCord, 60, 60);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}
