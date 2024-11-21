using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    

    internal class Door: ICollideable
    {
        private Vector2 position;
        private Rectangle destinationRectangle;
        private String room;
        private ISprite sprite;
        private Vector2 newPos;
        public bool lockedS;
        public bool unlockable;
        public String doorSprite;

        public Door(Vector2 position, String doorType, String room, Vector2 newPos, bool locked) 
        {
            this.position = position;
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Constants.DoorWidth, Constants.DoorHeight);
            doorSprite = doorType;
            sprite = BlockSpriteFactory.Instance.CreateSprite(doorType);
            this.room = room;
            this.newPos = newPos;

            //determines if the door is locked
            locked = lockedS;
            //determines if the door can be unlocked by a key (for example doors that lock until all enemies are killed)
            unlockable = true;
        }
        public Rectangle getHitbox()
        {
            return new Rectangle((int)position.X, (int)position.Y, Constants.DoorWidth-20, Constants.DoorHeight-20);
        }
        public void Update(GameTime gameTime) 
        {
            // Nothing right now
        }
        public String getRoom() 
        {
            return room;
        }
        public Vector2 getNewPosition()
        {
            return newPos;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Debug.WriteLine($"Door is {doorSprite}");
            sprite = BlockSpriteFactory.Instance.CreateSprite(doorSprite);
            sprite.Draw(spriteBatch, destinationRectangle, Color.White);
        }
        public String getCollisionType()
        {
               return "Door";
        }
      
       public void setLocked(bool lockState)
        {
            lockedS = lockState;
        }

    

      
    }
}
