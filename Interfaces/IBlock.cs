using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    // honestly have no idea why this is separate from ISprite, but at least it's consistent with IItems.
    public interface IBlock
    {
        public void Update(GameTime gametime) { }

        public void Draw(SpriteBatch spriteBatch) { }
    }
}
