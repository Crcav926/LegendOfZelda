using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ObjectManagementExamples;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda.HUD
{
    public class PausedHUD
    {

        private static PausedHUD instance = new PausedHUD();

        public static PausedHUD Instance
        {
            get
            {
                return instance;
            }
        }
       
        ISprite pausedInventory;
        private HUDSpriteFactory hudSF;
        private Inventory inven;
        private IItems key1Item;
        private ISprite sprite1;
        private Dictionary<String, Rectangle> pauseMap;
        private String inventoryItemName;
        private ISprite inventorySprites;
        private Rectangle destinationRectangle;
        private String weaponName;
        private ISprite selectionSprite;
        private Vector2 selectionPosition;
        public int weaponIndex;
        public PausedHUD()
        {
            inven = Inventory.Instance;
            hudSF = HUDSpriteFactory.Instance;
            weaponIndex = 0;
            pausedInventory = hudSF.CreatePauseInventory();
            key1Item = inven.key1Item;
            if (key1Item != null)
            {
                sprite1 = hudSF.CreateHUDWeaponSprite(key1Item.ToString());
            }
                inventoryItemName = "";
            selectionSprite = hudSF.CreateSelectionBorder();
            selectionPosition = new Vector2(399, -34);
            pauseMap = new Dictionary<String, Rectangle>
        {
           { "LegendOfZelda.Boomerang", new Rectangle(412, -34,26,31)}
          ,{ "LegendOfZelda.Bomb", new Rectangle(487,-34,26,31)}
          ,{ "LegendOfZelda.Arrow", new Rectangle(562, -34, 26, 31)}
          ,{ "LegendOfZelda.Fire", new Rectangle(637, -34, 26, 31)}
        };
        }

        public void goRight()
        {
            weaponIndex++;
        }

        public void goLeft()
        {
            weaponIndex--;
        }

        

                                                              
        public void Update(GameTime gameTime)
        {
            key1Item = inven.key1Item;
            if (sprite1 != null && key1Item != null)
            {
                sprite1 = hudSF.CreateHUDWeaponSprite(key1Item.ToString());
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            pausedInventory.Draw(spriteBatch, new Rectangle(0, -Constants.HUDHeight, Constants.PausedInventoryWidth, Constants.PausedInventoryHeight), Color.White);
            sprite1.Draw(spriteBatch, new Rectangle(212, -34, 26, 31), Color.White);
            selectionSprite.Draw(spriteBatch, new Rectangle((int)selectionPosition.X + (75 * weaponIndex) , (int)selectionPosition.Y, 52, 31), Color.White);
            foreach (IItems weapons in inven.weapons)
            {
                weaponName = weapons.ToString();
                destinationRectangle = pauseMap[weaponName];
                inventorySprites = hudSF.CreateHUDWeaponSprite(weaponName);
                inventorySprites.Draw(spriteBatch, destinationRectangle, Color.White);

            }
            

        }
    }
}
