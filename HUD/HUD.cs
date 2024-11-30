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

        private ISprite HUDSprite;
        private InventoryCounter invenCount;
        private Health hp;
        private HUDMap hudMap;
        private IItems key1Item;
        private IItems key2Item;
        private Inventory inven;
        private ISprite sprite1;
        private ISprite sprite2;
        private HUDSpriteFactory hudSF;
        int pausedOffset;
        private bool paused;
        private Game1 myGame;
        private PausedHUD pausedHUD;
        public HUDManager(Game1 game)
        {
            pausedHUD = PausedHUD.Instance;
            hudSF = HUDSpriteFactory.Instance;
            HUDSprite = hudSF.CreateHUD();
            invenCount = new InventoryCounter();
            hp = new Health();
            hudMap = HUDMap.Instance;
            inven = Inventory.Instance;
            // Pull item value from inven.key1Item
            // Grab sprite data from given key1Item value
            // Use sprite data to draw on HUD
            myGame = game;
            key1Item = inven.key1Item;

            if (key1Item != null)
            {
                //Debug.WriteLine(key1Item.ToString());
                sprite1 = hudSF.CreateHUDWeaponSprite(key1Item.ToString());
            }
            
                
            
        }


        public void Update(GameTime gameTime)
        {
            paused = myGame.paused;
            pausedOffset = paused ? Constants.OriginalHeight : 0;

            key1Item = inven.key1Item;
            key2Item = inven.key2Item;
            sprite2 = hudSF.CreateHUDWeaponSprite(key2Item.ToString());
            if (sprite1 != null && key1Item != null)
            {
                sprite1 = hudSF.CreateHUDWeaponSprite(key1Item.ToString());
            }
            HUDSprite.Update(gameTime);
            hp.Update(gameTime);
            hudMap.Update(gameTime);
            pausedHUD.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // solid black blackground to avoid flickering peeking into another room.

            if (paused)
            {
                pausedHUD.Draw(spriteBatch);
            }

            HUDSprite.Draw(spriteBatch, new Rectangle(0, -Constants.HUDHeight, Constants.OriginalWidth, Constants.OriginalHeight / 4), Color.Black);
            HUDSprite.Draw(spriteBatch, new Rectangle(0, -Constants.HUDHeight + pausedOffset, Constants.OriginalWidth, Constants.OriginalHeight / 4), Color.White);
            invenCount.Draw(spriteBatch, pausedOffset);
            hp.Draw(spriteBatch, pausedOffset);
            hudMap.Draw(spriteBatch, pausedOffset);
            if (sprite1 != null)
            {
                sprite1 = hudSF.CreateHUDWeaponSprite(key1Item.ToString());
                sprite1.Draw(spriteBatch, new Rectangle(Constants.HUDSprite1X, Constants.HUDSprite1Y + pausedOffset, Constants.HUDSpriteWidth, Constants.HUDSpriteHeight), Color.White);
            }
            if (sprite2 != null)
            {
                sprite2.Draw(spriteBatch, new Rectangle(Constants.HUDSprite2X, Constants.HUDSprite2Y + pausedOffset, Constants.HUDSpriteWidth, Constants.HUDSpriteHeight), Color.White);
            }

        }
    }
}
