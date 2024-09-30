using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.LinkMovement
{
    internal class LinkDamagedState : ILinkState
    {
        private Link link;
        DamageAnimation damageAnimation;
        Vector2 currentDirection;
        public LinkDamagedState(Link link)
        {
            this.link = link;
            damageAnimation = new DamageAnimation();
            currentDirection = link.direction;
        }

        public void Idle()
        {
            link.linkState = new LinkIdleState(link);
        }
        public void TakeDamage()
        {

        }
        public void Move(Vector2 newDirection)
        {
            // Link does not move while idle.
        }
        public void Attack()
        {
            link.linkState = new LinkAttackingState(link);
        }

        public void Update(GameTime gameTime)
        {
            link.linkState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Color damageColor = damageAnimation.GetCurrentColor();
            spriteBatch.Draw(link.linkSprite.GetTexture(), link.linkSprite.GetDestinationRectangle(currentDirection),link.linkSprite.GetCurrentSourceRectangle(),damageColor);
        }
    }
}
