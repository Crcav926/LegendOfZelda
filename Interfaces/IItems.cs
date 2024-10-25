using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public interface IItems
    {
        public bool exists { get; set; }
        public void Update(GameTime gameTime);
        public void makeContact();
        public void Draw(SpriteBatch spriteBatch);
        public void Use(Vector2 newDirection, Vector2 newPosition);
        public int getDamage();
    }
}
