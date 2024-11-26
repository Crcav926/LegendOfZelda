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

namespace LegendOfZelda.LinkMovement
{
    internal class LinkDeathState : ILinkState
    {
        private Link link;
        private string name = "Death";
        public LinkDeathState(Link link)
        {
            this.link = link;
            this.link.linkSprite = link.spriteFactory.CreateLinkDeathSprite();
            SoundMachine.Instance.PlaySound("death");
            link.test1 = true;
        }
        //not sure if these need implemented since there's no coming back from this state
        //unless we add revives or something idk
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
            //we'll figure something out
            //throw new NotImplementedException();
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

        public void Update(GameTime gameTime)
        {
            link.linkSprite.Update(gameTime);
        }
    }
}
