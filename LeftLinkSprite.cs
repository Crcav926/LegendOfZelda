﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendOfZelda;

namespace LegendOfZelda
{
    public class LeftLinkSprite: ISprite
    {
        Texture2D linkTexture;
        SpriteBatch spriteBatch;
        Rectangle sourceRectangle;
        Rectangle destinationRectangle;


        public LeftLinkSprite(Texture2D texture)
        {
            linkTexture = texture;
            sourceRectangle = new Rectangle(103, 11, 16, 16);
        }
        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destination)
        {
            spriteBatch.Draw(linkTexture, destination, sourceRectangle, Color.White);
        }
        public void SetSprite(int i) { }
        public int GetSprite() { return 0; }
    }
}
