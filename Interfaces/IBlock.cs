using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    // Currently does effectively nothing, but may allow for collision stuff later.
    // It's already here, I'm just keeping it until we figure out what we're doing for collision.
    public interface IBlock
    {
        public void Update(GameTime gametime) { }

        public void Draw(SpriteBatch spriteBatch) { }
    }
}
