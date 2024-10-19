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
    internal class LinkBombAttackState : ILinkState
    {
        private Link link;
        private string name = "BombAttack";
        IItems bomb;
        Vector2 position;
        Vector2 direction;
        public LinkBombAttackState(Link link)
        {
            this.position = link.position;
            this.direction = link.direction;
            this.link = link;

            // Constructing Link sprite here.
            link.linkSprite = LinkSpriteFactory.Instance.CreateLinkAttackSprite(link.direction);
            bomb = link.bomb;
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
            if (!bomb.exists)
            {
                link.bomb.Use(this.direction, this.position);
            }
            // 
        }
        public void Update(GameTime gameTime)
        {
            bomb.Update(gameTime);

            if (!bomb.exists)
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
