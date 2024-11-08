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
using LegendOfZelda.Sounds;

namespace LegendOfZelda
{
    public class ClassItems :ICollideable, IItems
    {
        double timePerFrame = 0.05; // Adjustable data
        double timeElapsed = 0;

        private Vector2 itemPosition;
        private Rectangle destination;

        ISprite itemSprite;
        Boolean collided = false;
        public bool exists { get; set; }

        String itemType;


        public ClassItems(Vector2 pos, String _itemType)
        {
            itemPosition = pos;
            itemType = _itemType;
            
            //itemSprite = ItemSpriteFactory.Instance.CreateFireSprite();
            MethodInfo methodInfo = typeof(ItemSpriteFactory).GetMethod(itemType);
            if (methodInfo != null)
            {
                itemSprite = (ISprite)methodInfo.Invoke(ItemSpriteFactory.Instance, null);
            }
            else
            {
                Debug.WriteLine("Failed to create sprite");
            }
          

            Debug.WriteLine($"Sucessfully created {itemType}");

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

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            destination = new Rectangle((int)itemPosition.X, (int)itemPosition.Y, 20, 20);
            if (exists)
            {
                //Debug.WriteLine("Draw in ClassItems called");
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

        //call this when link picks up the item
        public void makeContact()
        {
            Debug.WriteLine("Item made contact");
            if (itemType == "Triforce" || itemType == "TriforceBlue")
            {
                SoundMachine.Instance.GetSound("getTri").Play(); ;
            }
            else
            {
                SoundMachine.Instance.GetSound("getRupee").Play();
            }
            exists = false;
        }

        //unused methods
        public void Use(Vector2 v, Vector2 v2) { }


        //not used for stationary items
        //but if enemies do run into them they shouldn't do damage.
        public int getDamage()
        {
            return 0;
        }
    }
}
