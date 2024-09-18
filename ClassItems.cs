using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class ClassItems
    {
        public ISprite sprite;
        public Rectangle destinationRectangle;
        public int xCord;
        public int yCord;

        public int direction;
        public ClassItems(ISprite ItemSprite)
        {
            sprite = ItemSprite;
            // set starting position
            // 0 is stationary 1 is vertical 2 is horizontal
            direction = 0;
            xCord = 600;
            yCord = 200;
        }
        public void Update(GameTime gameTime)
        {
            // only move the arrow when we're in bounds.
            if (xCord < 800 || xCord>0 ||yCord < 400 || yCord >0 )
            {
                // this moves the arrow sprite across the screen.
                if (direction == 1)
                {
                    //yCord--;
                }
                else if (direction == 2)
                {
                   // xCord++;
                }
                destinationRectangle = new Rectangle(xCord, yCord, 60, 60);
            }
            // animate the sprite if needed this is temporary b/c this is a bad way to do it.
            int fr = 3;
            int loop = 0;
            // if we're at the boomerang
           
            sprite.Update(gameTime);
            
            
        }
        public void SetSprite(int i) { sprite.SetSprite(i); }
        public int GetSprite() { return sprite.GetSprite(); }


        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}
