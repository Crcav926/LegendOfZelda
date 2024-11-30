using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ObjectManagementExamples;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda.HUD
{
    public class InventoryCounter
    {

        private Inventory inven;
        private HUDSpriteFactory hudSF;
        private Dictionary<char, ISprite> HUDNumSprites;
        private int numCoins;
        private int coinsHUDPosX;
        private int coinsHUDPosY;

        private int numKeys;
        private int keysHUDPosX;
        private int keysHUDPosY;

        private int numBombs;
        private int bombsHUDPosX;
        private int bombsHUDPosY;

        ISprite sprite;
        public InventoryCounter()
        {
            inven = Inventory.Instance;
            
            hudSF = HUDSpriteFactory.Instance;
            HUDNumSprites = new Dictionary<char, ISprite>
        {
            { '0', hudSF.Create0()},
            { '1', hudSF.Create1()},
            { '2', hudSF.Create2()},
            { '3', hudSF.Create3()},
            { '4', hudSF.Create4()},
            { '5', hudSF.Create5()},
            { '6', hudSF.Create6()},
            { '7', hudSF.Create7()},
            { '8', hudSF.Create8()},
            { '9', hudSF.Create9()}
        };

        

        }
        public void Draw(SpriteBatch spriteBatch, int pausedOffset)
        {
            numCoins = inven.coins;
            numKeys = inven.numKeys;
            numBombs = inven.numBombs;
            string numCoinsStr = numCoins.ToString();
            string numKeysStr = numKeys.ToString();
            string numBombsStr = numBombs.ToString();

            coinsHUDPosX = Constants.coinsHUDPosX;
            coinsHUDPosY = Constants.coinsHUDPosY + pausedOffset;

            sprite = hudSF.CreateX();
            sprite.Draw(spriteBatch, new Rectangle(coinsHUDPosX, coinsHUDPosY, Constants.HUDNumberSpriteDimensionX, Constants.HUDNumberSpriteDimensionY), Color.White);
            foreach (char digit in numCoinsStr)
            {
                coinsHUDPosX += Constants.HUDNumberSpriteDimensionX;
                if (HUDNumSprites.ContainsKey(digit))
                {
                    sprite = HUDNumSprites[digit];
                    sprite.Draw(spriteBatch, new Rectangle(coinsHUDPosX,coinsHUDPosY,Constants.HUDNumberSpriteDimensionX, Constants.HUDNumberSpriteDimensionY), Color.White);
                    
                }
            }

            keysHUDPosX = Constants.keysHUDPosX;
            keysHUDPosY = Constants.keysHUDPosY + pausedOffset;

            sprite = hudSF.CreateX();
            sprite.Draw(spriteBatch, new Rectangle(keysHUDPosX, keysHUDPosY, Constants.HUDNumberSpriteDimensionX, Constants.HUDNumberSpriteDimensionY), Color.White);
            foreach (char digit in numKeysStr)
            {
                keysHUDPosX += Constants.HUDNumberSpriteDimensionX;
                if (HUDNumSprites.ContainsKey(digit))
                {
                    sprite = HUDNumSprites[digit];
                    sprite.Draw(spriteBatch, new Rectangle(keysHUDPosX, keysHUDPosY, Constants.HUDNumberSpriteDimensionX, Constants.HUDNumberSpriteDimensionY), Color.White);

                }
            }

            bombsHUDPosX = Constants.bombsHUDPosX;
            bombsHUDPosY = Constants.bombsHUDPosY + pausedOffset;

            sprite = hudSF.CreateX();
            sprite.Draw(spriteBatch, new Rectangle(bombsHUDPosX, bombsHUDPosY, Constants.HUDNumberSpriteDimensionX, Constants.HUDNumberSpriteDimensionY), Color.White);
            foreach (char digit in numBombsStr)
            {
                bombsHUDPosX += Constants.HUDNumberSpriteDimensionX;
                if (HUDNumSprites.ContainsKey(digit))
                {
                    sprite = HUDNumSprites[digit];
                    sprite.Draw(spriteBatch, new Rectangle(bombsHUDPosX, bombsHUDPosY, Constants.HUDNumberSpriteDimensionX, Constants.HUDNumberSpriteDimensionY), Color.White);

                }
            }


        }
    }
}
