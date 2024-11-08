using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendOfZelda;

namespace LegendOfZelda
{
    public class RightLinkSprite: ISprite
    {
        Texture2D linkTexture;
        Rectangle sourceRectangle;


        public RightLinkSprite(Texture2D texture)
        {
            linkTexture = texture;
            sourceRectangle = new Rectangle(35, 11, 16, 16);
        }
        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destination)
        {
            spriteBatch.Draw(linkTexture, destination, sourceRectangle, Color.White);
        }
    }
}
