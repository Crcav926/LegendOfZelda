using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Diagnostics;

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
            currentDirection = link.direction;
            damageAnimation = link.damageAnimation;
        }
        public string getState() { return name; }

        public void Idle()
        {
            link.linkState = new LinkIdleState(link);
        }
        public void TakeDamage()
        {
            Debug.WriteLine("TAKING DAMAGEE IN THE DAMAGED STATE");
            damageAnimation.StartDamageEffect();
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
