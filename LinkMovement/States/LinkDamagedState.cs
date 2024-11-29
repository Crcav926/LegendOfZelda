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
        private string name = "Damaged";

        public LinkDamagedState(Link link)
        {
            this.link = link;
            damageAnimation = link.damageAnimation;
        }

        public string getState() { return name; }

        public void Idle()
        {
            link.linkState = new LinkIdleState(link);
        }
        public void Pickup()
        {
            link.linkState = new LinkPickUpState(link);
        }
        public void TakeDamage()
        {
            if (link.canTakeDamage)
            {
                damageAnimation.StartDamageEffect();
                link.invulnerable();

            }
        }
        public void Death()
        {
            link.linkState = new LinkDeathState(link);
        }
        public void Move(Vector2 newDirection)
        {
            link.linkState = new LinkMoveState(link);
        }
        public void BoomerangAttack()
        {
            link.linkState = new LinkBoomerangAttackState(link);
        }
        public void SwordAttack()
        {
            link.linkState = new LinkSwordAttackState(link);
        }
        public void FireAttack()
        {
            link.linkState = new LinkFireAttackState(link);
        }
        public void ArrowAttack()
        {
            link.linkState = new LinkArrowAttackState(link);
        }
        public void BombAttack()
        {
            link.linkState = new LinkBombAttackState(link);
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
