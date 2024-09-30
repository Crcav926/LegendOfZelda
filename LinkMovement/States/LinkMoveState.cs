using LegendOfZelda.LinkMovement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class LinkMoveState : ILinkState
    {

        private Link link;
        Vector2 newDirection;
        public LinkMoveState(Link link)
        {
            this.link = link;
            newDirection = link.direction;
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
            // Updates links position and direction.
            this.newDirection = newDirection;
            link.position += newDirection;
            link.linkSprite.SetPosition(link.position);
            link.linkSprite = link.spriteFactory.CreateLinkAnimatedSprite(link.direction, link.position);
        }
        public void Attack()
        {
            link.linkState = new LinkAttackingState(link);
        }

        public void Update(GameTime gameTime)
        {
            link.direction = newDirection;
            link.linkSprite.Update(gameTime);
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            link.linkSprite.Draw(spriteBatch);
        }
    }
}
