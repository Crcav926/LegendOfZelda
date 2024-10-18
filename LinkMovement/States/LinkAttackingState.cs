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
    internal class LinkAttackingState : ILinkState
    {
        Vector2 currentDirection;
        private Link link;
        private string name = "Attack";
        private double timeElapsed;
        private double timeWait = 0.5;
        public LinkAttackingState(Link link)
        {
            this.link = link;
            currentDirection = link.direction;
            // Constructing Link sprite here.
            link.linkSprite = LinkSpriteFactory.Instance.CreateLinkAttackSprite(currentDirection);
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
            // Link should not move when he attacks
        }
        public void Attack()
        {
            // ATTACK!
        }

        public void Update(GameTime gameTime)
        {

            // No update required, were standing still.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destination = new Rectangle((int)link.position.X, (int)link.position.Y, 45, 40);
            link.linkSprite.Draw(spriteBatch, destination, Color.White);
        }
    }
}
