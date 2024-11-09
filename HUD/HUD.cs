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
        IItems key1Item;
        IItems key2Item;
        Inventory inven;
        ISprite sprite1;
        ISprite sprite2;
        ISprite sprite3;
        ISprite sprite4;
        ISprite sprite5;
        HUDSpriteFactory hudSF;
        public HUDManager()
        {
            hudSF = HUDSpriteFactory.Instance;
            HUDSprite = hudSF.CreateHUD();
            invenCount = new InventoryCounter();
            hp = new Health();
            hudMap = new HUDMap();

            inven = Inventory.Instance;
            // Pull item value from inven.key1Item
            // Grab sprite data from given key1Item value
            // Use sprite data to draw on HUD

            key1Item = inven.key1Item;
            key2Item = inven.key2Item;
            if (key1Item != null)
            {
                sprite1 = hudSF.CreateHUDWeaponSprite(key1Item.ToString());
            }
            if (key2Item != null)
            {
                sprite2 = hudSF.CreateHUDWeaponSprite(key2Item.ToString());
            }
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
            key1Item = inven.key1Item;
            key2Item = inven.key2Item;
            sprite1 = hudSF.CreateHUDWeaponSprite(key1Item.ToString());
            if (sprite2 != null)
            {
                sprite2 = sprite2 = hudSF.CreateHUDWeaponSprite(key2Item.ToString());
            }
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
            if (sprite1 != null)
            {
                sprite1.Draw(spriteBatch, new Rectangle(400, -69, 25, 40), Color.White);
            }
            if (sprite2 != null)
            {
                sprite2.Draw(spriteBatch, new Rectangle(475, -69, 25, 40), Color.White);
            }

        }
    }
}
