using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendOfZelda.LinkMovement;

namespace LegendOfZelda
{
    public interface ILinkState
    {
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
        void TakeDamage();
        void Death();
        void Move(Vector2 direction);
        void BoomerangAttack();
        void SwordAttack();
        void FireAttack();
        void ArrowAttack();
        void BombAttack();
        void Idle();
        string getState();



    }
}
