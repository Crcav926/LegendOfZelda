using LegendOfZelda.LinkMovement;
using LegendOfZelda.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda;
public class Ganon : IEnemy, ICollideable
{
    public Vector2 position { get; set; }
    private Vector2 velocity;
    private List<Fireball> fireballs;
    private float fireballCooldown = 2f;
    private float fireballTimer = 0f;
    private ISprite normalSprite;
    private ISprite vulnerableSprite;
    private bool isVisible;
    private bool isVulnerable;
    private double visibilityDuration = 1.0;
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
        fireballs = new List<Fireball>();
        normalSprite = EnemySpriteFactory.Instance.CreateGanonSprite();
        vulnerableSprite = EnemySpriteFactory.Instance.CreateGanonVulnerableSprite();
        velocity = Vector2.Zero;
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

        fireballTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (fireballTimer >= fireballCooldown)
        {
            ThrowFireballs();
            fireballTimer = 0f;
        }

        // Handle visibility
        if (!isVulnerable && !isVisible)
        {
            visibleTimeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (visibleTimeElapsed >= visibilityDuration)
            {
                visibleTimeElapsed = 0;
            }
        }

        // Handle vulnerability
        if (isVulnerable)
        {
            vulnerableTimeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (vulnerableTimeElapsed >= vulnerableTimer)
            {
                ResetState();
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

        // Update fireballs
        fireballs.RemoveAll(f => !f.IsActive);
        foreach (Fireball fireball in fireballs)
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

        //ganon fire sound ?

        RoomObjectManager.Instance.addProjectile(new Fireball(fireballStartPosition, new Vector2(0, -1)));  // Up
        RoomObjectManager.Instance.addProjectile(new Fireball(fireballStartPosition, new Vector2(1, -1))); // Up-Right
        RoomObjectManager.Instance.addProjectile(new Fireball(fireballStartPosition, new Vector2(1, 0)));  // Right
        RoomObjectManager.Instance.addProjectile(new Fireball(fireballStartPosition, new Vector2(1, 1)));  // Down-Right
        RoomObjectManager.Instance.addProjectile(new Fireball(fireballStartPosition, new Vector2(0, 1)));  // Down
    }

    public void TakeDamage(int damage)
    {
        if (canTakeDamage && !isVulnerable)
        {
            SoundMachine.Instance.GetSound("enemyHurt").Play();
            //damageAnimation.StartDamageEffect();
            hitsTaken++;

            if (hitsTaken >= 3)
            {
                isVulnerable = true;
                isVisible = true; // becomes visible when vulnerable
            }
            else
            {
                isVisible = true; // briefly becomes visible when hit
            }

            canTakeDamage = false; // Trigger invincibility
        }
        else if (isVulnerable)
        {
            hp -= damage;

            if (hp <= 0)
            {
                alive = false;
                isVisible = true; // remains visible after defeat
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
        ISprite currentSprite;
        
        if (isVulnerable)
        {
            currentSprite = vulnerableSprite;
        }
        else
        {
            currentSprite = normalSprite;
        }

        if (isVisible)
        {
            Color color = damageAnimation.GetCurrentColor();
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Constants.GanonWidth, Constants.GanonHeight);
            currentSprite.Draw(spriteBatch, destinationRectangle, color);
        }

        foreach (Fireball fireball in fireballs)
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

