using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.LinkMovement
{
    internal class LinkIdleState : ILinkState
    {
        private Link link;
        public LinkIdleState(Link link)
        {
            this.link = link;
        }

        public void Idle()
        {
            // Does nothing while idle.
        }
        public void TakeDamage()
        {
            link.linkState = new LinkDamagedState(link);
        }
        public void Move(Vector2 newDirection)
        {
            link.linkState = new LinkMoveState(link);
        }
        public void Attack()
        {
            link.linkState = new LinkAttackingState(link);
        }

        public void Update(GameTime gameTime)
        {
            // No update required, were standing still.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            link.linkSprite.Draw(spriteBatch);
        }
    }
}
