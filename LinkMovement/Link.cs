using LegendOfZelda.LinkMovement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Timers;

namespace LegendOfZelda
{
      public class Link : ICollideable
    {
        public ISprite linkSprite { get; set; }
        public ILinkState linkState { get; set; }
        public Vector2 position;
        public Vector2 direction;
        public LinkSpriteFactory spriteFactory;
        // Magic numbers to be used later
        private int maxHealth = 10;
        private int currentHealth = 10;
        public Boomerang boomerang;
        public IItems arrow;
        public IItems fire;
        public IItems sword;
        public IItems bomb;
        public DamageAnimation damageAnimation;
        //this gives me access to the sprite to take its info for hitboxes
        public Sprite hitInfo;
        public List<ICollideable> inventory = new List<ICollideable>();
        public Boolean canTakeDamage { get; private set; }
        private double invincibilityTimer = 1.5;
        private double timeElapsed = 0;


        public Link()
        { 
            spriteFactory = LinkSpriteFactory.Instance;
            position = new Vector2(370, 330); // Fix magic num later
            direction = new Vector2(0, 1); // Fix magic num later
            // Sets link to be Idle initially
            linkSprite = spriteFactory.CreateLinkStillSprite(direction);
            linkState = new LinkIdleState(this);
            damageAnimation = new DamageAnimation();
            canTakeDamage = true;

            boomerang = new Boomerang(direction, position);
            arrow = new Arrow(direction, position);
            fire = new Fire(direction, position);
            sword = new Sword(direction, position);
            bomb = new Bomb(direction, position);
            inventory.Add((ICollideable)boomerang);
            inventory.Add((ICollideable)arrow);
            inventory.Add((ICollideable)fire);
            inventory.Add((ICollideable)sword);
            inventory.Add((ICollideable)bomb);

            //this allows me to get the sprite into for the hitbox.
            hitInfo = (Sprite)linkSprite;
            
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
            if (canTakeDamage)
            {
                linkState.TakeDamage();
                currentHealth -= 1;
            }
        }

        public void BoomerangAttack()
        {
            linkState.BoomerangAttack();
        }
        public void SwordAttack() 
        { 
            linkState.SwordAttack();
        }
        public void FireAttack() 
        { 
            linkState.FireAttack();
        }
        public void ArrowAttack()
        {
            linkState.ArrowAttack();
        }
        public void BombAttack()
        {
            linkState.BombAttack();
        }
        public void Update(GameTime gameTime)
        {
            //This updates hitbox
            //the sprite update doesn't work for weapon slots 2 and 3 but I think that's b/c those slots aren't refactored.
            
            linkState.Update(gameTime);
            linkSprite.Update(gameTime);
            damageAnimation.Update(gameTime);
            boomerang.Update(gameTime);
            arrow.Update(gameTime);
            fire.Update(gameTime);
            sword.Update(gameTime);
            bomb.Update(gameTime);

            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > invincibilityTimer)
            {
                canTakeDamage = true;
                timeElapsed = 0;
            }
            if (currentHealth == 0)
            {
                // TODO: CHANGE LATER WHEN GAME OVER SCREEN CREATED
                LevelLoader.Instance.Load("Room1.xml");
                currentHealth = 10;
            }
        }
        public void invulnerable()
        {
            if (canTakeDamage)
            {
                canTakeDamage = false;
            }
        }
        public Rectangle getHitbox()
        {
            //for now assume that Link is 16*4 by 16*4
            //put data in the the hitbox
            Rectangle hitbox = new Rectangle((int)position.X, (int)position.Y+ Constants.MikuHeight / 2, Constants.MikuWidth, Constants.MikuHeight/2);
            //Debug.WriteLine("Hitbox of Link retrieved!");
            
            //Debug.WriteLine($"Link Hitbox:{position.X} {position.Y} {tempDimension} {tempDimension}");
            //return it
            return hitbox;
        }
        public String getCollisionType()
        {
            return "Player";
        }
        public void Draw(SpriteBatch spriteBatch)
        { 
         
            boomerang.Draw(spriteBatch);
            arrow.Draw(spriteBatch);
            fire.Draw(spriteBatch);
            sword.Draw(spriteBatch);
            bomb.Draw(spriteBatch);
            linkState.Draw(spriteBatch);
        }
    }
}
