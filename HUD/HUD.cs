using LegendOfZelda.LinkItems;
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
        HUDMap hudMap;
        public HUDManager()
        {
            HUDSprite = HUDSpriteFactory.Instance.CreateHUD();
            invenCount = new InventoryCounter();
            hp = new Health();
            hudMap = new HUDMap();
            Debug.WriteLine("Weapons List: ");
            for (int i = 0; i < Inventory.Instance.weapons.Count; i++)
            {
                Debug.WriteLine(Inventory.Instance.weapons[i]);
            }
        }

        public void HUDBuilding()
        {
            

        }

        public void Update(GameTime gameTime)
        {
            HUDSprite.Update(gameTime);
            hp.Update(gameTime);
            hudMap.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            HUDSprite.Draw(spriteBatch, new Rectangle((int)Camera2D.Instance.getPosition().X, (int)Camera2D.Instance.getPosition().Y - Constants.HUDHeight*2, Constants.OriginalWidth, Constants.OriginalHeight / 4), Color.White);
            invenCount.Draw(spriteBatch);
            hp.Draw(spriteBatch);
            hudMap.Draw(spriteBatch);

        }
    }
}
