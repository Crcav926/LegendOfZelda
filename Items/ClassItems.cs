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
        // keep track of your own sprite and which one from the dictionary we want
        // this is more or less a get set property see SetSprite and GetSprite
        public ISprite sprite;
        //this should be the authoratitive source on what sprite we're on.
        public int spriteIndex;


        public int xCord;
        public int yCord;


        Texture2D itemTex;

        public int direction;
       public ClassItems(Texture2D ItemTexture, int x, int y)
        {
            // get the texture sheet
            itemTex = ItemTexture;
            //index 0 is an invisible sprite
            spriteIndex = 0;
            // when first initialized get a new animated sprite object from itemTex sprite sheet with index 0.
            sprite = new SpriteItemAnimated(itemTex, spriteIndex);
            
            // 0 is stationary 1 is vertical 2 is horizontal
            direction = 0;


            // set starting position
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
                // this section was largely for testing purposes and will be removed later
                if (direction == 1)
                {
                    yCord--;
                }
                else if (direction == 2)
                {
                   xCord++;
                }
                // the 60 60 here doesn'
                
            }

            sprite.Update(gameTime);
            
            
        }
        public void SetSprite(int i) { spriteIndex = i;  sprite = new SpriteItemAnimated(itemTex, spriteIndex); }

        public int GetSprite() { return spriteIndex; }


        public void Draw(SpriteBatch spriteBatch)
        {
            // just initialize a rectangle, sprite Draw we call here actually figures out correct dimensions
            Rectangle destinationRectangle = new Rectangle(xCord, yCord, 60, 60);
            sprite.Draw(spriteBatch, destinationRectangle, Color.White);
        }
    }
}
