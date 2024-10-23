using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;
using System.Reflection;

namespace LegendOfZelda
{
    public class ClassItems :ICollideable, IItems
    {
        double timePerFrame = 0.05; // Adjustable data
        double timeElapsed = 0;

        private Vector2 itemPosition;
        private Rectangle destination;

        ItemSpriteFactory itemSpriteFactory;
        ISprite itemSprite;
        Boolean collided = false;
        public bool exists { get; set; }

        String itemType;


        public ClassItems(Vector2 pos, String _itemType)
        {
            itemPosition = pos;
            itemSpriteFactory = ItemSpriteFactory.Instance;
            itemType = _itemType;
            MethodInfo methodInfo = typeof(ItemSpriteFactory).GetMethod(itemType);
            itemSprite = (ISprite)methodInfo?.Invoke(itemSpriteFactory, null);


            exists = true;
        }
        public String getItemType()
        {
            return itemType;
        }
        public void Update(GameTime gameTime)
        {

            if (collided)
            {
                exists = false;
            }

            destination = new Rectangle((int)itemPosition.X, (int)itemPosition.Y, 20, 20);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (exists)
            {
                itemSprite.Draw(spriteBatch, destination, Color.White);
            }

        }
        public Rectangle getHitbox()
        {
            if (exists)
            {
                return destination;
            }
            else
            {
                return new Rectangle(0, 0, 0, 0);
            }
        }

        public String getCollisionType()
        {
            return "statItem";
        }

        //unused methods
        public void Use(Vector2 v, Vector2 v2) { }

        public void makeContact() {
            exists = false;
        }

    }
}
