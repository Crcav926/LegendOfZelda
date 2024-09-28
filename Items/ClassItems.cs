using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class ClassItems
    {
        public ISprite sprite;
        public int spriteIndex;
        public Rectangle destinationRectangle;
        public int xCord;
        public int yCord;


        Texture2D itemTex;

        public int direction;

        public ClassItems(Texture2D ItemTexture, int x, int y) //fix this
        {
            itemTex = ItemTexture;
            spriteIndex = 0;
            // when first initialized get a new animated sprite object from itemTex sprite sheet with index 0.
            sprite = new SpriteItemAnimated(itemTex, spriteIndex);
            // set starting position
            // 0 is stationary 1 is vertical 2 is horizontal
            direction = 0;
            xCord = x;
            yCord = y;
        }
        public void Update(GameTime gameTime)
        {
            // this move section should probably be separated out.
            // only move the arrow when we're in bounds.
            if (xCord < 800 || xCord>0 ||yCord < 400 || yCord >0 )
            {
                // this moves the arrow/boomerang sprite across the screen.
                if (direction == 1)
                {
                    yCord--;
                }
                else if (direction == 2)
                {
                   xCord++;
                }
                destinationRectangle = new Rectangle(xCord, yCord, 60, 60);
            }

            sprite.Update(gameTime);
            
            
        }
        public void SetSprite(int i) { spriteIndex = i;  sprite = new SpriteItemAnimated(itemTex, spriteIndex); }

        public int GetSprite() { return spriteIndex; }


        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, destinationRectangle, Color.White);
        }
    }
}
