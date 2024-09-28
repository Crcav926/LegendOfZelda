using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal interface IItems
    {
        public void Update(GameTime gametime) { }

        public void Draw(SpriteBatch spriteBatch) { }
    }
}
