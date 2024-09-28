using LegendOfZelda.LinkMovement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
      public class Link : ILink
    {
        public ISprite linkSprite;
        public ILink linkState;
        public Vector2 position;
        public Vector2 direction;
        public Boolean animated;
        // Changeable magic number, adjusts Link's movement speed
        private Vector2 speed = new Vector2(2, 2);
        public ILinkItem item;
        public Boomerang boomerang;
        public Arrow arrow;
        public Fire fire;
        public Sword sword;
        public Bomb bomb;
        private List<ILinkItem> inventory;
        // public int direction; // 0 = left ; 1 = right ; 2 = up ; 3 = down
        public Link(Texture2D linkTexture, Texture2D itemTexture)
        {
            // Set up boolean to check if Link's sprite is moving and needs to animate
            animated = false;
            // Sets up link's starting position
            position = new Vector2(400, 200);
            // Sets up the direction Link will face when spawned in
            direction = new Vector2(0, -1);
            // Sets link's sprite for when he is spawned in
            linkSprite = new LinkIdleSprite(linkTexture, direction);
            boomerang = new Boomerang(itemTexture, direction, position, false);
            arrow = new Arrow(itemTexture, direction, position, false);
            fire = new Fire(itemTexture, direction, position, false);
            sword = new Sword(itemTexture, direction, position, false);
            bomb = new Bomb(itemTexture, direction, position, false);
        }
        public void Move(Vector2 newDirection)
        {
            // Sets direction to link's current movement direction
            direction = newDirection;
            // Moves link in direction based on command, allows for diagonal movement
            position += newDirection*speed;
        }
        public void ChangeItem()
        {

        }
        public void UseItem()
        {
            
        }
        public void ChangeDirection(Vector2 newDirection)
        {

        }
        // TODO: Add "ChangeDirection" class so Link controls his own sprite data
        public void Update(GameTime gameTime)
        {
            arrow.Update(gameTime);
            boomerang.Update(gameTime);
            fire.Update(gameTime);
            sword.Update(gameTime);
            bomb.Update(gameTime);
            // Updates / Animates link's sprite
            linkSprite.Update(gameTime);
            // Updates Links position
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            arrow.Draw(spriteBatch);
            fire.Draw(spriteBatch);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 60, 60);
            // Draws link Sprite based on where he is after update
            boomerang.Draw(spriteBatch);
            sword.Draw(spriteBatch);
            bomb.Draw(spriteBatch);
            linkSprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}
