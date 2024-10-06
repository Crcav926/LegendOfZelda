using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LegendOfZelda.LinkMovement
{
    internal class LinkDamagedState : ILinkState
    {
        private Link link;
        DamageAnimation damageAnimation;
        Vector2 currentDirection;
        private string name = "Damaged";
        public LinkDamagedState(Link link)
        {
            this.link = link;
            damageAnimation = new DamageAnimation();
            currentDirection = link.direction;
        }
        public string getState() { return name; }

        public void Idle()
        {
            link.linkState = new LinkIdleState(link);
        }
        public void TakeDamage()
        {
            
        }
        public void Move(Vector2 newDirection)
        {
            link.Move(newDirection);
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
            Color damageColor = damageAnimation.GetCurrentColor();
            Rectangle destination = new Rectangle((int)link.position.X, (int)link.position.Y, 60, 60);
            link.linkSprite.Draw(spriteBatch, destination, damageColor);
        }
    }
}
