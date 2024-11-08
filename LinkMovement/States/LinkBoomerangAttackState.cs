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
    internal class LinkBoomerangAttackState : ILinkState
    {
        private Link link;
        private string name = "BoomerangAttack";
        Vector2 position;
        Vector2 direction;
        IItems boomerang;
        public LinkBoomerangAttackState(Link link)
        {
            this.position = link.position;
            this.direction = link.direction;
            this.link = link;
            // Constructing Link sprite here.
            link.linkSprite = LinkSpriteFactory.Instance.CreateLinkAttackSprite(link.direction);
            boomerang = link.boomerang;
            Debug.WriteLine(boomerang);
        }

        public string getState() { return name; }

        public void Idle()
        {
            link.linkState = new LinkIdleState(link);
        }
        public void TakeDamage()
        {
            link.linkState = new LinkDamagedState(link);
        }
        public void Death()
        {
            link.linkState = new LinkDeathState(link);
        }
        public void Move(Vector2 newDirection)
        {
            // link.linkState = new LinkMoveState(link);
            if (!boomerang.exists)
            {
                link.linkState = new LinkBoomerangAttackState(link);
            }
        }
        public void BoomerangAttack()
        {
            Debug.WriteLine("Boomer4");
            if (!boomerang.exists)
            {
                boomerang.Use(this.direction,this.position);
            }
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

            if (!boomerang.exists)
            {
                link.linkState = new LinkIdleState(link); // Switch to idle state when boomerang is done
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Color color = link.damageAnimation.GetCurrentColor();
            Rectangle destination = new Rectangle((int)link.position.X, (int)link.position.Y, Constants.MikuHeight, Constants.MikuHeight);
            link.linkSprite.Draw(spriteBatch, destination, color);
  
        }
    }
}
