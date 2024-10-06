using LegendOfZelda.LinkMovement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ObjectManagementExamples;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
      public class Link
    {
        public ISprite linkSprite { get; set; }
        public ILinkState linkState { get; set; }
        public Vector2 position;
        public Vector2 direction;
        public LinkSpriteFactory spriteFactory;
        // Magic numbers to be used later
        private int maxHealth = 10;
        private int currentHealth = 10;
        public bool boolean = false;
        public Link()
        { 
            spriteFactory = LinkSpriteFactory.Instance;
            position = new Vector2(200, 200); // Fix magic num later
            direction = new Vector2(0, 1); // Fix magic num later
            // Sets link to be Idle initially
            linkSprite = spriteFactory.CreateLinkStillSprite(direction);
            linkState = new LinkIdleState(this);
        }
        public void setState(ILinkState state) 
        {
            if (state.getState() != linkState.getState())
            {
                linkState = state;
            }
        }
        public void Idle()
        {
            linkState.Idle();
        }
        // Delegates states
        public void Move(Vector2 newDirection)
        {
            linkState.Move(newDirection);
        }

        public void TakeDamage()
        {
            linkState.TakeDamage();
        }

        public void Attack()
        {
            linkState.Attack();
        }
        public void Update(GameTime gameTime)
        {
            linkState.Update(gameTime);
            linkSprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destination = new Rectangle((int)position.X, (int)position.Y, 60, 60);
            linkState.Draw(spriteBatch);
        }
    }
}
