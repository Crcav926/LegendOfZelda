using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ObjectManagementExamples;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda.HUD
{
    public class HUDManager
    {

        ISprite HUDSprite;
        InventoryCounter invenCount;
        Health hp;
        public HUDManager()
        {
            HUDSprite = HUDSpriteFactory.Instance.CreateHUD();
            invenCount = new InventoryCounter();
            hp = new Health();
        }

        public void HUDBuilding()
        {
            

        }

        public void Update(GameTime gameTime)
        {
            HUDSprite.Update(gameTime);
            hp.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
            HUDSprite.Draw(spriteBatch, new Rectangle(0, -Constants.HUDHeight, Constants.OriginalWidth, Constants.OriginalHeight / 4), Color.White);
            invenCount.Draw(spriteBatch);
            hp.Draw(spriteBatch);


        }
    }
}
