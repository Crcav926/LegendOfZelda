﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.LinkMovement
{
    internal class LinkIdleState : ILinkState
    {
        private Link link;
        private string name = "Idle";
        public LinkIdleState(Link link)
        {
            this.link = link;
            link.linkSprite = link.spriteFactory.CreateLinkStillSprite(link.direction);
        }
        public string getState() { return name; }

        public void Idle()
        {
            // Does nothing while idle.
        }
        public void TakeDamage()
        {
            link.linkState = new LinkDamagedState(link);
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
            // No update required, were standing still.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destination = new Rectangle((int)link.position.X, (int)link.position.Y, 60, 60);
            link.linkSprite.Draw(spriteBatch, destination, Color.White);
        }
    }
}
