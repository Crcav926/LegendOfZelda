using LegendOfZelda.LinkMovement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ObjectManagementExamples;
using System;
using System.Collections.Generic;
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
        Game1 myGame;
        public bool boolean = false;
        public Link(Game1 game)
        {
            myGame = game;   
            spriteFactory = LinkSpriteFactory.Instance;
            position = new Vector2(200, 200); // Fix magic num later
            direction = new Vector2(0, 1); // Fix magic num later
            linkSprite = spriteFactory.CreateLinkStillSprite(direction,position);
            linkState = new LinkIdleState(this);
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


        }
        public void Draw(SpriteBatch spriteBatch)
        {
            linkSprite.Draw(spriteBatch);
        }
    }
}
