using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public interface ISprite
    {
        /*
         * Update the given sprite based on game commands
         */
        void Update(GameTime gameTime);
        /*
         * Draws the given sprite onto the screen
         */
        void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color);

    }
}
