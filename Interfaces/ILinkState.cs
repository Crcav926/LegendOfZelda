using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public interface ILinkState
    {
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
        void TakeDamage();
        void Move(Vector2 direction);
        void Attack();
        void Idle();
        string getState();



    }
}
