using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class SpriteItem : ISprite
    {
        Texture2D itemTexture;
        SpriteBatch spriteBatch;
        // I  edit the source rectangle from a command
        Rectangle sourceRectangle;
        Rectangle destinationRectangle;
        private List<Rectangle> sources = new List<Rectangle>();
        public int index;


        public void SetSprite(int i)
        {
            // the if check prevents you from trying to set to an undefined sprite
            if (i < sources.Count && i >= 0) { 
                index = i;
            }
        }
        public int GetSprite() { return index; }

        public SpriteItem(Texture2D texture)
        {
            itemTexture = texture;
            index = 0;
            //where in the texture sheet are we looking.
            // vertical arrow is at 1,185 it's 8 by 16
            // horizontal arrow is at 10, 185 it's 16 by 16
            Rectangle vertArrow = new Rectangle(1, 185, 8, 16);
            Rectangle horizArrow = new Rectangle(10, 185, 16, 16);
            Rectangle noItem = new Rectangle(0, 11, 1, 1);

            // animated frames
            Rectangle boomerang1 = new Rectangle(64, 185, 8, 16);
            Rectangle boomerang2 = new Rectangle(73, 185, 8, 16);
            Rectangle boomerang3 = new Rectangle(82, 185, 8, 16);


            sources.Add(noItem);
            sources.Add(vertArrow);
            sources.Add(horizArrow);

            sources.Add(boomerang1);
            sources.Add(boomerang2);
            sources.Add(boomerang3);

            sourceRectangle = sources[index];


        }
        public void Update(GameTime gameTime)
        {
            // this does make reset the frame every update, but that should be ok, as we can switch frames for animation this way too.
            sourceRectangle = sources[index];
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destination)
        {
            spriteBatch.Draw(itemTexture, destination, sourceRectangle, Color.White);
        }
    }
}
