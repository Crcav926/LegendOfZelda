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
        private Rectangle destinationRectangle;
        public Vector2 position;
        public Vector2 direction;
        public Boolean animated;
        public ILinkItem item;
        private List<IItems> items;
        // TODO: Find a way to make items work without having to do this
        private GameTime linkGameTime;
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
            item = new Boomerang(itemTexture, direction, position);
        }
        public void Move(Vector2 newDirection)
        {
            // Sets direction to link's current movement direction
            direction = newDirection;
            // Moves link in direction based on command, allows for diagonal movement
            position += newDirection;
        }
        public void ChangeItem()
        {

        }
        public void UseItem(SpriteBatch spriteBatch)
        {

        }
        // TODO: Add "ChangeDirection" class so Link controls his own sprite data
        public void Update(GameTime gameTime)
        {
            item.Update(gameTime);
            linkGameTime = gameTime;
            // Updates / Animates link's sprite
            linkSprite.Update(gameTime);
            // Updates Links position
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 60, 60);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draws link Sprite based on where he is after update
            item.Draw(spriteBatch);
            linkSprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}
