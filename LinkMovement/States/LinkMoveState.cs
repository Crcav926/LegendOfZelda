using LegendOfZelda.LinkMovement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

namespace LegendOfZelda
{
    public class LinkMoveState : ILinkState
    {

        private Link link;
        Vector2 newDirection;
        private string name = "Move";
        public LinkMoveState(Link linkCharacter)
        {
            this.link = linkCharacter;
            newDirection = link.direction;
            this.link.linkSprite = link.spriteFactory.CreateLinkAnimatedSprite(newDirection);
            DamageAnimation damageAnimation = link.damageAnimation;
        }
        public string getState() { return name; }

        public void Idle()
        {
            link.linkState = new LinkIdleState(link);
        }
        public void TakeDamage()
        {
            link.linkState = new LinkDamagedState(link); 
            link.linkState.TakeDamage();
        }   
        public void Move(Vector2 newDirection)
        {
            // Updates links position and direction.
            if (link.direction != newDirection)
            {
                link.linkSprite = link.spriteFactory.CreateLinkAnimatedSprite(newDirection);
                link.direction = newDirection;
            }
            link.position += link.direction;
            
        }
        public void Attack()
        {
            link.linkState = new LinkAttackingState(link);
        }

        public void Update(GameTime gameTime)
        {
            link.linkSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Color color = link.damageAnimation.GetCurrentColor();
            Rectangle destination = new Rectangle((int)link.position.X, (int)link.position.Y, Constants.MikuHeight, Constants.MikuHeight);
            link.linkSprite.Draw(spriteBatch, destination, color);
        }
    }
}
