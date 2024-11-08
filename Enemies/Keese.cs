using LegendOfZelda.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace LegendOfZelda;
public class Keese : IEnemy, ICollideable

{
    private Vector2 targetPosition;  // Target position for the sprite to jump to
    private Vector2 velocity;  // direction and speed
    //private float speed = 100f;
    private Random random = new Random();
    private ISprite sprite;
    private Rectangle destinationRectangle;
    private Boolean alive;
    public Vector2 position { get; set; }
    private int hp;
    public Boolean canTakeDamage { get; private set; }
    private double invincibilityTimer = 1.5;
    private double timeElapsed = 0;

    public bool HasDroppedItem { get; set; } = false;
    private ClassItems droppedItem;
  
    //songyu's version
    //private ClassItems droppedKey;

    private bool keyStatus;


    public Keese(Vector2 position, bool hasKey)
    {
        // Set the initial target position (I dont know so I randomize it here
        this.position = position;
        targetPosition = position;
        velocity = new Vector2(
            (float)(random.NextDouble() * 2 - 1),
            (float)(random.NextDouble() * 2 - 1)
        );
        // Normalize to ensure consistent speed in all directions
        velocity.Normalize();
        velocity *= Constants.KeeseSpeed;
        sprite = EnemySpriteFactory.Instance.CreateKeeseSprite();
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Constants.KeeseWidth, Constants.KeeseHeight);
        alive = true;
        hp = 1;
        canTakeDamage = true;
        if (hasKey == null)
        {
            keyStatus = false;
        }else if (hasKey)
        {
            keyStatus = true;
        }
        else
        {
            keyStatus = false;
        }
    }
    public void ChangeDirection()
    {
        // Choose a random direction (up, down, left, right)
        int direction = random.Next(0, 4);

        switch (direction)
        {
            case 0:
                velocity = new Vector2(Constants.KeeseSpeed, -Constants.KeeseSpeed);
                break;
            case 1:
                velocity = new Vector2(-Constants.KeeseSpeed, Constants.KeeseSpeed);
                break;
            case 2:
                velocity = new Vector2(-Constants.KeeseSpeed, -Constants.KeeseSpeed);
                break;
            case 3:
                velocity = new Vector2(Constants.KeeseSpeed, Constants.KeeseSpeed);
                break;
        }
    }
    public void invulnerable()
    {
        if (canTakeDamage)
        {
            canTakeDamage = false;
        }
    }
    public void Update(GameTime gameTime)
    {
        // Update position based on velocity
        position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

        timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
        if (timeElapsed > invincibilityTimer)
        {
            canTakeDamage = true;
            timeElapsed = 0;
        }

        // Check for collisions with screen edges and reflect velocity
        if (position.X <= 0 || position.X >= Constants.OriginalWidth - destinationRectangle.Width)
        {
            velocity.X *= -1; // Reverse X direction
        }

        if (position.Y <= 0 || position.Y >= Constants.OriginalHeight - destinationRectangle.Height)
        {
            velocity.Y *= -1; // Reverse Y direction
        }
        sprite.Update(gameTime);
    }

    public void Draw(SpriteBatch s)
    {
        if (alive)
        {
            // Use the current position for the destination rectangle, and size it appropriately
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Constants.KeeseWidth, Constants.KeeseHeight);

            sprite.Draw(s, destinationRectangle, Color.White);
        }
    }
    public Rectangle getHitbox()
    {
        Rectangle hitbox = new Rectangle(0, 0, 0, 0);
        //put data in the the hitbox
        if (alive)
        {
            hitbox = new Rectangle((int)position.X, (int)position.Y, Constants.KeeseHitboxWidth, Constants.KeeseHitboxHeight);
        }
        //Debug.WriteLine("Hitbox of block retrieved!");
        //Debug.WriteLine($"Rectangle hitbox:{destinationRectangle.X} {destinationRectangle.Y} {destinationRectangle.Width} {destinationRectangle.Height}");
        //return it
        return hitbox;
    }
    public String getCollisionType()
    {
        return "Enemy";
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
      
        SoundMachine.Instance.GetSound("enemyHurt").Play();

        if (hp <= 0)
        {
            alive = false;
        }
    }
    public void Attack() { }
    public Boolean isAlive() { return alive; }

    public void DropItem()
    {
        if (!alive)
        {
            Debug.WriteLine("DropItem called: Item drop initialized");
            
            //songyu vers
            //String Key = RoomObjectManager.Instance.GetKey();
            //droppedKey = new ClassItems(position, Key);
            //RoomObjectManager.Instance.staticItems.Add(droppedKey);

            if (keyStatus)
            {
                Debug.WriteLine("Key dropped!");
                droppedItem = new ClassItems(position, "Key");
                RoomObjectManager.Instance.staticItems.Add(droppedItem);
            }else
            {
                Debug.WriteLine("DropItem called: Item drop initialized");
                //for now I'm using Rupees to test drops
                String ItemTobeDroped = RoomObjectManager.Instance.GetItemName('C');
                //Debug.WriteLine(ItemTobeDroped);
                droppedItem = new ClassItems(position, ItemTobeDroped);
                HasDroppedItem = true;
                RoomObjectManager.Instance.staticItems.Add(droppedItem);
            }

        }
    }
}
