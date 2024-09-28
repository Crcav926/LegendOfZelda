using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public interface ILinkItem
    {
        public void Use(SpriteBatch spriteBatch, GameTime gameTime);

        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch);

    }
}
