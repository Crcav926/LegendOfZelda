using LegendOfZelda.LinkMovement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ObjectManagementExamples;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace LegendOfZelda.HUD
{
    public class Health
    {
        private Inventory inven;
        private HUDSpriteFactory hudSF;
        private Dictionary<char, ISprite> HUDHPSprites;
        private int maxHealth;
        private int currentHealth;
        private int totalHPIconCount;
        private int fullHPIconCount;
        private int halfHPIconCount;
        private int emptyHPIconCount;
        private int hpHUDPosX;
        private int hpHUDPosY;
        ISprite sprite;
        private Link link;
        public Health()
        {
            link = Link.Instance;

            this.maxHealth = link.maxHealth;

            totalHPIconCount = this.maxHealth / Constants.PointsPerHP;

            inven = Inventory.Instance;
            
            hudSF = HUDSpriteFactory.Instance;
            HUDHPSprites = new Dictionary<char, ISprite>
        {
            { '0', hudSF.CreateEmptyHP()},
            { '1', hudSF.CreateHalfHP()},
            { '2', hudSF.CreateFullHP()},
        };
    }

        public void Update(GameTime gameTime)
        {
            this.currentHealth = link.currentHealth;
            fullHPIconCount = currentHealth / Constants.PointsPerHP;

            if (currentHealth % 4 != 0) {
                halfHPIconCount = 1;
            } else
            {
                halfHPIconCount = 0;
            }

            emptyHPIconCount = totalHPIconCount - fullHPIconCount - halfHPIconCount;


        }

        public void Draw(SpriteBatch spriteBatch, int pausedOffset)
        {
            hpHUDPosX = Constants.hpHUDPosX;
            hpHUDPosY = Constants.hpHUDPosY + pausedOffset;

            for (int i = 0; i < fullHPIconCount; i++)
            {
                sprite = HUDHPSprites['2'];
                sprite.Draw(spriteBatch, new Rectangle(hpHUDPosX, hpHUDPosY, Constants.HUDHPSpriteDimensionX, Constants.HUDHPSpriteDimensionY), Color.White);
                hpHUDPosX += Constants.HUDNumberSpriteDimensionX;

            }

            for (int j = 0; j < halfHPIconCount; j++)
            {
                sprite = HUDHPSprites['1'];
                sprite.Draw(spriteBatch, new Rectangle(hpHUDPosX, hpHUDPosY, Constants.HUDHPSpriteDimensionX, Constants.HUDHPSpriteDimensionY), Color.White);
                hpHUDPosX += Constants.HUDNumberSpriteDimensionX;
            }

            for (int k = 0; k < emptyHPIconCount; k++)
            {
                sprite = HUDHPSprites['0'];
                sprite.Draw(spriteBatch, new Rectangle(hpHUDPosX, hpHUDPosY, Constants.HUDHPSpriteDimensionX, Constants.HUDHPSpriteDimensionY), Color.White);
                hpHUDPosX += Constants.HUDNumberSpriteDimensionX;
            }
         }
    }
}
