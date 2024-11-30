using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Diagnostics;
using LegendOfZelda.Sounds;
using System.Threading;
using System.ComponentModel;

namespace LegendOfZelda.LinkMovement
{
    internal class LinkPickUpState : ILinkState
    {
        private Link link;
        private string name = "Pickup";
        public LinkPickUpState(Link link)
        {
            this.link = link;
            this.link.linkSprite = link.spriteFactory.CreateLinkPickupSprite();
            link.pause = true;
        }
        //this is a little jank but it works i guess
        public void ArrowAttack()
        {
            //link.linkState = new LinkArrowAttackState(link);
        }

        public void BombAttack()
        {
            //link.linkState = new LinkBombAttackState(link);
        }

        public void BoomerangAttack()
        {
            //link.linkState = new LinkBoomerangAttackState(link);
        }

        public void Death()
        {
            //link.linkState = new LinkDeathState(link);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Color color = link.damageAnimation.GetCurrentColor();
            Rectangle destination = new Rectangle((int)link.position.X, (int)link.position.Y, Constants.MikuHeight, Constants.MikuHeight);
            link.linkSprite.Draw(spriteBatch, destination, color);
        }

        public void FireAttack()
        {
            //link.linkState = new LinkFireAttackState(link);
        }

        public string getState()
        {
            return name;
        }

        public void Idle()
        {
            //link.linkState = new LinkIdleState(link);
        }

        public void Move(Vector2 direction)
        {
            //link.linkState = new LinkMoveState(link);
        }

        public void SwordAttack()
        {
            //link.linkState = new LinkSwordAttackState(link);
        }

        public void TakeDamage()
        {
            //link.linkState = new LinkDamagedState(link);
        }
        public void Pickup()
        {
            link.linkState = new LinkPickUpState(link);
        }
        public void Update(GameTime gameTime)
        {
            link.linkSprite.Update(gameTime);
        }
    }
}
