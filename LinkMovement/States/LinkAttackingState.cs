using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.LinkMovement
{
    internal class LinkAttackingState : ILinkState
    {
        Vector2 currentDirection;
        private Link link;
        public LinkAttackingState(Link link)
        {
            this.link = link;
            currentDirection = link.direction;
            // Constructing Link sprite here.
            link.linkSprite = link.spriteFactory.CreateLinkAttackSprite(currentDirection,link.position);
        }

        public void Idle()
        {
            link.linkState = new LinkIdleState(link);
        }
        public void TakeDamage()
        {
            link.linkState = new LinkDamagedState(link);
        }
        public void Move(Vector2 newDirection)
        {
            link.direction = newDirection;
        }
        public void Attack()
        {
            // ATTACK!
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
