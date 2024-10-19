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
        public bool exists { get; set; }
        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch);
        public void Use(Vector2 newDirection, Vector2 newPosition);
        

        
    }
}
