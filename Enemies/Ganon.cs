using LegendOfZelda.LinkMovement;
using LegendOfZelda.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Ganon : IEnemy, ICollideable
    {
        public Vector2 position { get; set; }
        private Vector2 velocity;
        private List<GanonFireball> fireballs;
        private float fireballCooldown = 2f;
        private float fireballTimer = 0f;
        private ISprite normalSprite;
        private ISprite vulnerableSprite;
        private bool isVisible;
        private bool isVulnerable;
        private double blinkInterval = 3.0; // Ganon blinks every 3 seconds
        private double blinkDuration = 0.001; // Ganon is visible for 1 millisecond
        private double blinkElapsed = 0; // Tracks time elapsed since the last blink
        private double visibleTimeElapsed = 0;
        private double invincibilityTimer = 2.0;
        private double invincibilityElapsed = 0;
        private double vulnerableTimer = 5.0;
        private double vulnerableTimeElapsed = 0;

        private int hitsTaken;
        private int hp;
        private bool alive;
        private Rectangle destinationRectangle;
        public bool canTakeDamage { get; private set; }
        public bool HasDroppedItem { get; set; } = false;
        private ClassItems droppedItem;
        DamageAnimation damageAnimation;

        public Ganon(Vector2 startPosition)
        {
            damageAnimation = new DamageAnimation();
            position = startPosition;
            fireballs = new List<GanonFireball>();
            normalSprite = EnemySpriteFactory.Instance.CreateGanonSprite();
            vulnerableSprite = EnemySpriteFactory.Instance.CreateGanonVulnerableSprite();
            velocity = new Vector2(50f, 50f);
            hitsTaken = 0;
            hp = 4;
            isVisible = false;
            isVulnerable = false;
            alive = true;
            canTakeDamage = true;
        }

        public void Update(GameTime gameTime)
        {
            damageAnimation.Update(gameTime);

            blinkElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (blinkElapsed >= blinkInterval)
            {
                isVisible = true; // Make Ganon visible for the blink duration
                visibleTimeElapsed += gameTime.ElapsedGameTime.TotalSeconds;

                if (visibleTimeElapsed >= blinkDuration)
                {
                    isVisible = false; // Make Ganon invisible again
                    blinkElapsed = 0; // Reset blink timer
                    visibleTimeElapsed = 0; // Reset visibility duration timer
                }
            }

            // Fireball throwing
            fireballTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (fireballTimer >= fireballCooldown)
            {
                ThrowFireballs();
                fireballTimer = 0f;
            }

            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (position.X <= 0 || position.X + Constants.GanonWidth >= Constants.ScreenWidth)
            {
                velocity.X = -velocity.X; // Reverse horizontal direction
            }
            if (position.Y <= 0 || position.Y + Constants.GanonHeight >= Constants.ScreenHeight)
            {
                velocity.Y = -velocity.Y; // Reverse vertical direction
            }

            // Handle vulnerability
            if (isVulnerable)
            {
                vulnerableTimeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
                if (vulnerableTimeElapsed >= vulnerableTimer)
                {
                    ResetState(); // Reset to full strength
                }
            }

            // Handle invincibility
            if (!canTakeDamage)
            {
                invincibilityElapsed += gameTime.ElapsedGameTime.TotalSeconds;
                if (invincibilityElapsed >= invincibilityTimer)
                {
                    canTakeDamage = true;
                    invincibilityElapsed = 0;
                }
            }

            fireballs.RemoveAll(f => !f.IsActive);
            foreach (GanonFireball fireball in fireballs)
            {
                fireball.Update(gameTime);
            }
        }

        private void ThrowFireballs()
        {
            Vector2 fireballStartPosition = new Vector2(
                position.X + Constants.GanonFireballXOffset,
                position.Y + Constants.GanonFireballYOffset
            );

            RoomObjectManager.Instance.addProjectile(new GanonFireball(fireballStartPosition, new Vector2(0, -1)));  // Up
            RoomObjectManager.Instance.addProjectile(new GanonFireball(fireballStartPosition, new Vector2(1, -1))); // Up-Right
            RoomObjectManager.Instance.addProjectile(new GanonFireball(fireballStartPosition, new Vector2(1, 0)));  // Right
            RoomObjectManager.Instance.addProjectile(new GanonFireball(fireballStartPosition, new Vector2(1, 1)));  // Down-Right
            RoomObjectManager.Instance.addProjectile(new GanonFireball(fireballStartPosition, new Vector2(0, 1)));  // Down
        }

        public void TakeDamage(int damage)
        {
            if (canTakeDamage && !isVulnerable)
            {
                SoundMachine.Instance.GetSound("enemyHurt").Play();
                damageAnimation.StartDamageEffect();
                hitsTaken++;

                if (hitsTaken >= 3)
                {
                    isVulnerable = true;
                    isVisible = true; // Becomes visible when vulnerable
                }
                else
                {
                    isVisible = true; // Briefly visible when hit
                }

                canTakeDamage = false; // Trigger invincibility
            }
            else if (isVulnerable)
            {
                hp -= damage;

                if (hp <= 0)
                {
                    alive = false;
                    isVisible = true; // Stays visible after defeat
                }
            }
        }

        private void ResetState() // Reset to full strength
        {
            hitsTaken = 0;
            hp = 4;
            isVisible = false;
            isVulnerable = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ISprite currentSprite = isVulnerable ? vulnerableSprite : normalSprite;

            if (isVisible)
            {
                Color color = damageAnimation.GetCurrentColor();
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Constants.GanonWidth, Constants.GanonHeight);
                currentSprite.Draw(spriteBatch, destinationRectangle, color);
            }

            foreach (GanonFireball fireball in fireballs)
            {
                fireball.Draw(spriteBatch);
            }
        }

        public Rectangle getHitbox()
        {
            if (alive && isVisible)
            {
                return new Rectangle((int)position.X, (int)position.Y, Constants.GanonHitboxWidth, Constants.GanonHitboxHeight);
            }
            return new Rectangle(0, 0, 0, 0);
        }

        public bool isAlive() => alive;
        public string getCollisionType() => "Enemy";
        public void Attack() { }
        public void ChangeDirection() { }
        public void DropItem() { }
    }
}